using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalKey : MonoBehaviour
{
   // Notre variable magique accessible de partout
    public static bool hasFinalKey = false; 
    
    [Tooltip("La porte qui doit disparaître quand on prend la clef")]
    public GameObject doorToOpen; 
    public GameObject doorToOpens; 

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hasFinalKey = true;
            Debug.Log("Clef finale récupérée !");
            
            // On ouvre la porte (en la désactivant)
            if (doorToOpen != null)
            {
                doorToOpen.SetActive(false);
            }

            // On détruit la clef de la scène
            Destroy(gameObject);
            Destroy(gameObject);
        }
    }
}
