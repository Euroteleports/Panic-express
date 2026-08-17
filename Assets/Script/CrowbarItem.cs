using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowbarItem : MonoBehaviour
{
    [SerializeField] private GameObject olivia;
    [SerializeField] private GameObject currentCCTVCamera;
    [SerializeField] private GameObject minigameCamera;
    [SerializeField] private GameObject armMinigameRoot;
    [SerializeField] private GameObject Crowbar;

    public static bool hasCrowbar = false;

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
        if (Input.GetKeyDown(KeyCode.Space) && isPlayerNear == true)
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
