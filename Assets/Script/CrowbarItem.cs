using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowbarItem : MonoBehaviour
{
    public static bool hasCrowbar = false;

    [SerializeField] private GameObject olivia;
    [SerializeField] private GameObject currentCCTVCamera;
    [SerializeField] private GameObject minigameCamera;
    [SerializeField] private GameObject armMinigameRoot;
    [SerializeField] private GameObject Crowbar;
    [SerializeField] private GameObject Crowbar2;

    private AudioSource audioSource;
    private BooCam booCam;
    private bool isPlayerNear = false;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        booCam = olivia.GetComponent<BooCam>();
    }
    

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            isPlayerNear = true;
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            isPlayerNear = false;
        }
    }


    void Update()
    {
        if (isPlayerNear == true && Input.GetKeyDown(KeyCode.Space))
        {
            // L'inventaire est mis à jour !
            hasCrowbar = true;
            Debug.Log("Pied de biche récupéré !");

            // On joue le son de la récupération du pied de biche
            audioSource.Play();

            // On ferme le mini-jeu
            minigameCamera.SetActive(false);
            armMinigameRoot.SetActive(false);
            
            // On libère le joueur
            currentCCTVCamera.SetActive(true);
            olivia.SetActive(true);

            // On redonne la possibilité de BooVision
            booCam.noBooVision = false;
            Crowbar2.SetActive(true);

            // On commence le decompte avant l'autodestruction
            StartCoroutine(Delais());
        }
    }


    IEnumerator Delais()
    {
        yield return new WaitForSeconds(0.23f);
        Destroy(Crowbar);
        Destroy(gameObject);
    }
}
