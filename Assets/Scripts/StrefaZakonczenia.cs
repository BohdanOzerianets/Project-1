using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrefaZakonczenia : MonoBehaviour
{
    public GameObject text; 

    void Start()
    {
        
    }

    void Update()
    {
 

    }

    public void Exit() //  Wyjście z gry!
    {
        Application.Quit();
    }
    void OnTriggerEnter (Collider coll) // Obszar zakonczenia gry
    {
        if ( coll.gameObject.name == "Samochód") // kiedy samochód dojedzie do tego obszar, łącza się następne rzeczy jak text, debug.log i wyłączy się skrypt poruszania samochodu.
        {
            Debug.Log("Witam dotarles(as) do konca! Twoja rodzinna w bezpieczenstwie"); 
            text.SetActive(true);                                                    // Wyświetlany napis o zakończeniu gry
            coll.gameObject.GetComponent<carMovement1>().enabled = false;            // Wyłaczamy skrypt poruszania
        }
        
    }
}
