using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carMovement1 : MonoBehaviour
{
    public float MotoForce;         // Moc obrotu tylnych kół
    public float SteerForce;        // kąt skrętu przednich kół
    public float BreakForce;        // Hamulec przednich kół
    public float ZADBreakForce;     // Hamulec tylnych kół

    public float MaxSpeed;          // Maksymalna prędkość samochodu(pojazdu)

    public WheelCollider WheelColliderPL;
    public WheelCollider WheelColliderPP;
    public WheelCollider WheelColliderTL;
    public WheelCollider WheelColliderTP;

    public Transform PLTransform;
    public Transform PPTransform;
    public Transform TLTransform;
    public Transform TPTransform;

    public GameObject PPL;
    public GameObject PPP;

    Vector3 TPL, TPP;

    void Update()
    { 
        float v = Input.GetAxis("Vertical") * MotoForce;       // Przyspieszenie koła 
        float h = Input.GetAxis("Horizontal") * SteerForce;    // Kąt obrotu przednich kół

        PLTransform.Rotate(WheelColliderPL.rpm / 60 * 360 * Time.deltaTime, 0.0f, 0.0f);
        PPTransform.Rotate(WheelColliderPP.rpm / 60 * 360 * Time.deltaTime, 0.0f, 0.0f);
        TLTransform.Rotate(WheelColliderTL.rpm / 60 * 360 * Time.deltaTime, 0.0f, 0.0f);
        TPTransform.Rotate(WheelColliderTP.rpm / 60 * 360 * Time.deltaTime, 0.0f, 0.0f);

        WheelColliderPL.motorTorque = v * MaxSpeed;
        WheelColliderPP.motorTorque = v * MaxSpeed;
        WheelColliderTL.motorTorque = v * MaxSpeed;
        WheelColliderTP.motorTorque = v * MaxSpeed;

        WheelColliderPL.steerAngle = h;
        WheelColliderPP.steerAngle = h;

        if (Input.GetKey(KeyCode.Space))                // Hamulec na space
        {
            WheelColliderPL.brakeTorque = BreakForce;
            WheelColliderPP.brakeTorque = BreakForce;
            WheelColliderTL.brakeTorque = ZADBreakForce;
            WheelColliderTP.brakeTorque = ZADBreakForce;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            WheelColliderPL.brakeTorque = 0;
            WheelColliderPP.brakeTorque = 0;
            WheelColliderTL.brakeTorque = 0;
            WheelColliderTP.brakeTorque = 0;
        }

        TPL = PLTransform.localEulerAngles;                 // skrecenie collaidera koła
        TPL.y = WheelColliderPL.steerAngle;                 // skrecenie modelu koła
        PLTransform.transform.localEulerAngles = TPL;


        TPP = PPTransform.localEulerAngles;                 // skrecenie collaidera koła
        TPP.y = WheelColliderPP.steerAngle;                 // skrecenie modelu koła
        PPTransform.transform.localEulerAngles = TPP;

        if (Input.GetKey(KeyCode.Z))                    // Jeżeli pojazd przywróci się na dach to proste przewracanie się na koła na 180
        {
            transform.Rotate(new Vector3(180, 0, 0));
        }
        
        if (Input.GetKey(KeyCode.X))                    // Jeżeli pojazd przywróci się na bok to proste przewracanie się na koła na 90
        {
            transform.Rotate(new Vector3(0, 0, 90));
        }

    }
}
