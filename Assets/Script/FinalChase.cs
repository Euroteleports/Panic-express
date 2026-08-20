using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalChase : MonoBehaviour
{
    [SerializeField] private GameObject solidWall;     // Le mur de base
    [SerializeField] private GameObject brokenWall; 
    [SerializeField] private GameObject[] cameraToShutdown;
    [SerializeField] private FearController fearcontroller;


    [SerializeField] private float enemySpeed = 3f;    // Sa vitesse de course
    [SerializeField] private float startChase = 2f;

    private AudioSource audioSource;
    private StalkerCamera stalkercamera;
    private Transform playerTransform;
    private bool isChasing = false;
    private bool canMove = false;
    private BooCam booCam;
    private Collider collider;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        stalkercamera = GetComponent<StalkerCamera>();

        collider = GetComponent<Collider>();
        collider.enabled = false;
    }


    public void StartChase()
    {
        isChasing = true;

        playerTransform = stalkercamera.target;

        Debug.Log("LE MUR EST D�TRUIT ! FUYEZ !");

        foreach (GameObject cam in cameraToShutdown)
        {
            cam.SetActive(false);
        }

        StartCoroutine(Delais());
    }
    

    void Update()
    {
        // Logique de poursuite "Game Jam" (ultra simple et efficace)
        if (isChasing && canMove && playerTransform != null)
        {
            // Le monstre regarde le joueur (mais on bloque l'axe Y pour qu'il ne se penche pas en avant)
            Vector3 lookPosition = new Vector3(playerTransform.position.x, transform.position.y, playerTransform.position.z);
            transform.LookAt(lookPosition);

            // Le monstre avance tout droit vers le joueur
            transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, enemySpeed * Time.deltaTime);
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            fearcontroller.DeathByFear();
        }
    }


    IEnumerator Delais()
    {
        //Commande pour cr�er un d�lais
        yield return new WaitForSeconds(startChase);
        // On casse le mur !
        if (solidWall != null)
        {
            solidWall.SetActive(false);
        }

        GetComponent<Collider>().enabled = true;

        audioSource.Play();

        canMove = true;

        yield return new WaitForSeconds(startChase);

        if (brokenWall != null)
        {
            brokenWall.SetActive(true);
        }
    }
}
