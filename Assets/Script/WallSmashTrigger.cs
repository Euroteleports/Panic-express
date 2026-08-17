using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSmashTrigger : MonoBehaviour
{
    [SerializeField] private GameObject solidWall;     // Le mur de base
    [SerializeField] private GameObject brokenWall;    // Les débris (optionnel)
    [SerializeField] private GameObject enemy;         // Le monstre
    [SerializeField] private float enemySpeed = 3f;    // Sa vitesse de course
    [SerializeField] private float startChase = 2f;
    [SerializeField] private GameObject Camera1;
    [SerializeField] private GameObject Camera2;
    [SerializeField] private GameObject Camera3;

    private AudioSource audioSource;
    private Transform playerTransform;
    private bool isChasing = false;
    private bool canMove = false;
    private BooCam booCam;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    void OnTriggerEnter(Collider other)
    {
        // Si c'est le joueur ET qu'il a la clef ET qu'on n'a pas déjà lancé l'event
        if (other.CompareTag("Player") && FinalKey.hasFinalKey && !isChasing)
        {
            booCam = other.GetComponent<BooCam>();

            if (booCam.booVisionActive == true)
            {
                booCam.DeactivateBooVision();
                Debug.Log("BooVision est active !");
            }

            booCam.noBooVision = true;

            isChasing = true;

            playerTransform = other.transform;
            
             // On fait spawner le monstre
            if (enemy != null)
            { 
                enemy.SetActive(true);
            }

            Debug.Log("LE MUR EST DÉTRUIT ! FUYEZ !");

            Camera1.SetActive(false);

            Camera2.SetActive(false);

            Camera3.SetActive(true);

            StartCoroutine(Delais());
        }
    }

    void Update()
    {
        // Logique de poursuite "Game Jam" (ultra simple et efficace)
        if (isChasing && canMove && playerTransform != null && enemy != null)
        {
            // Le monstre regarde le joueur (mais on bloque l'axe Y pour qu'il ne se penche pas en avant)
            Vector3 lookPosition = new Vector3(playerTransform.position.x, enemy.transform.position.y, playerTransform.position.z);
            enemy.transform.LookAt(lookPosition);
            
            // Le monstre avance tout droit vers le joueur
            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, playerTransform.position, enemySpeed * Time.deltaTime);
        }
    }

    IEnumerator Delais()
    {
        //Commande pour créer un délais
        yield return new WaitForSeconds(startChase);
        // On casse le mur !
        if (solidWall != null)
        {
            solidWall.SetActive(false);
        }

        if (brokenWall != null)
        {
            brokenWall.SetActive(true);
        }

        audioSource.Play();
            
        canMove = true;
    }
}
