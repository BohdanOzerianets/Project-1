using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carMovementAndroid : MonoBehaviour
{
    public void PrzodW()
    {
        transform.Translate(Vector3.forward / 1);
    }

    public void TyłS()
    {
        transform.Translate(Vector3.back / 1);
    }

    public void LewoA()
    {
        transform.Rotate(0, (float)-1, 0);
    }

    public void PrawoD()
    {
        transform.Rotate(0, (float)1, 0);
    }

    public void D90()
    {
        transform.Rotate(new Vector3(0, 0, 90));
    }

    public void D180()
    {
        transform.Rotate(new Vector3(180, 0, 0));
    }
}
