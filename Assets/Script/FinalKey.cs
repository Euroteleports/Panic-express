using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalKey : MonoBehaviour
{
    public static bool hasFinalKey = false;

    [SerializeField] private GameObject doorToOpen;
    [SerializeField] private GameObject colliderFin;
    [SerializeField] private GameObject clef;

    private AudioSource audioSource;
    private bool isPlayerNear = false;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    void OnTriggerEnter(Collider other)
    {
      if(other.CompareTag("Player"))
      {
        isPlayerNear = true;
      }   
    }
        

    void OnTriggerExit(Collider other)
    {
      if(other.CompareTag("Player"))
      {
        isPlayerNear = false;
      }   
    }
        
        
    void Update()
    {
        if (isPlayerNear == true && Input.GetKeyDown(KeyCode.Space))
        {
            hasFinalKey = true;
            Debug.Log("Clef finale récupérée !");

            //Son de clef
            audioSource.Play();

            //Destrcution de la clef
            Destroy(clef);

            //Desactivation des objets qui bloque le chemin
            doorToOpen.SetActive(false);

            //Activation du collider de fin
            colliderFin.SetActive(true);

            //Temps d'attende avant l'autodestruction
            StartCoroutine(Autodestruction());    
        }
    }
    

    IEnumerator Autodestruction()
    {
        //Commande pour créer un délais
        yield return new WaitForSeconds(0.5f);
        //Destruction du collider
        Destroy(gameObject);
        
    }
}
