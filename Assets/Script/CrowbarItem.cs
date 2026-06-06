using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowbarItem : MonoBehaviour
{
   public TankController playerController;
    public GameObject currentCCTVCamera; 
    public GameObject minigameCamera; 
    public GameObject armMinigameRoot; 
    private AudioSource Audiosource;
    public GameObject Crowbar;

    void Start()
    {
        Audiosource = GetComponent<AudioSource>();
    }

    // Ta variable statique globale
    public static bool hasCrowbar = false; 
    private bool isPlayerNear = false;

        void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand")) isPlayerNear = true;
    }

     void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hand")) isPlayerNear = false;
    }

    void Update()
    {
        // On vérifie que c'est bien la main qui touche
        if (/*other.CompareTag("Hand") &&*/ Input.GetKeyDown(KeyCode.Space) && isPlayerNear == true)
        {
            hasCrowbar = true; // L'inventaire est mis à jour !
            Debug.Log("Pied de biche récupéré !");


            // On ferme le mini-jeu
            minigameCamera.SetActive(false);
            armMinigameRoot.SetActive(false);
            
            // On libère le joueur
            currentCCTVCamera.SetActive(true);
            playerController.enabled = true;

            // On détruit l'objet physique
            //Destroy(gameObject);
            Crowbar.SetActive(false);
            
            Audiosource.Play();
         
        }
    }
}
