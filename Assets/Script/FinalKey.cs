using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalKey : MonoBehaviour
{
    public static bool hasFinalKey = false; 
    public GameObject doorToOpen; 
    public GameObject doorToOpens; 
    public GameObject clef;
    private AudioSource Audiosource;
    public GameObject collider;
    private bool Booestla = false;

    void Start()
    {
        Audiosource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
      if(other.CompareTag("Player"))
      {
        Booestla = true;
      }   
    }
        
    void OnTriggerExit(Collider other)
    {
      if(other.CompareTag("Player"))
      {
        Booestla = false;
      }   
    }
        
        
    void Update()
    {
        if (Booestla == true && Input.GetKeyDown(KeyCode.Space))
        {
            hasFinalKey = true;
            Debug.Log("Clef finale récupérée !");
            
            // On ouvre la porte (en la désactivant)
            if (doorToOpen != null)
            {
                doorToOpen.SetActive(false);
            }

            //Detrction des objets qui bloque le chemin
           doorToOpen.SetActive(false);
           doorToOpens.SetActive(false);

            //Destrcution de la clef
            Destroy(clef);

            // Son de clef
             Audiosource.Play();
             
            //Temps d'attende avant l'autodestruction
            StartCoroutine(Autodestruction());
            
            
            
        }
    }
    

    IEnumerator Autodestruction()
    {
        //Commande pour créer un délais
        yield return new WaitForSeconds(10f);
        //Destruction du collider
        collider.SetActive(false);
        
    }
}
