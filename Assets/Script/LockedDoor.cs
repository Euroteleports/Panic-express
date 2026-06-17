using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    [Tooltip("Glisse ici l'obstacle ou la porte à faire disparaître")]
    public GameObject doorModel; 

    private bool isPlayerNear = false;
    private AudioSource Audiosource;
    public GameObject Colliders;
    private Collider Lui;

    void Start()
    {
        Audiosource = GetComponent<AudioSource>();
        Lui = GetComponent<Collider>();
    }

    // Détection du joueur
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) isPlayerNear = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) isPlayerNear = false;
    }

    void Update()
    {
        // Si le joueur est devant et appuie sur Espace
        if (isPlayerNear && Input.GetKeyDown(KeyCode.Space))
        {
            // On interroge directement la variable statique du pied de biche !
            if (CrowbarItem.hasCrowbar)
            {
                Debug.Log("Porte forcée avec succès !");
                
                // On libère le passage (on désactive le modèle pour aller vite)
                doorModel.SetActive(false);
                
                // On désactive ce trigger pour ne plus pouvoir interagir dans le vide
               // gameObject.SetActive(false); 
            
                Audiosource.Play();
                StartCoroutine(Delais());
        
                 
        }
    }
}

IEnumerator Delais()
    {
      yield return new WaitForSeconds(0.2f);
      Colliders.SetActive(false);
      Lui.enabled = false;
    }
}
