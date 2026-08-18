using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GhostPatrol : MonoBehaviour
{
    // Variable statique pour la peur
    public static float currentFear = 0f;

    [Header("Déplacements")]
    [Tooltip("Glisse ici tes points de patrouille (Empty GameObjects)")]
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float moveSpeed = 2f;
    [Header("Mécanique de Peur")]
    [Tooltip("Vitesse à laquelle la jauge monte par seconde")]
    [SerializeField] private float fearIncreaseRate = 25f;

    private int currentWaypointIndex = 0;
    private bool isPlayerNear = false;


    void Start()
    {
        // Sécurité : On remet la peur à zéro et le temps à la normale au chargement
        currentFear = 0f; 
        Time.timeScale = 1f;
    }


    void Update()
    {
        Patrol();
        HandleFear();
    }


    void Patrol()
    {
        // S'il n'y a pas de points assignés, il reste sur place
        if (waypoints.Length == 0)
        {
            return;
        }

        Transform target = waypoints[currentWaypointIndex];
        
        // Le fantôme avance vers le point actuel
        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

        // Il regarde dans la direction où il va (en gardant son axe Y droit)
        Vector3 lookPosition = new Vector3(target.position.x, transform.position.y, target.position.z);
        transform.LookAt(lookPosition);

        // S'il est arrivé très près du point, on passe au suivant
        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }


    void HandleFear()
    {
        if (isPlayerNear)
        {
            // La peur augmente progressivement
            currentFear += fearIncreaseRate * Time.deltaTime;
            Debug.Log("Peur : " + Mathf.Round(currentFear) + "%");

            if (currentFear >= 100f)
            {
                Debug.Log("MORT DE PEUR ! On recommence.");
                RestartGame();
            }
        }
        else if (currentFear > 0)
        {
            // Optionnel : la peur redescend doucement quand on sort de la zone
            currentFear -= (fearIncreaseRate / 3) * Time.deltaTime;
            currentFear = Mathf.Clamp(currentFear, 0f, 100f);
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
        }
    }


    void RestartGame()
    {
        // On recharge la scène actuelle depuis le début
        SceneManager.LoadScene(1);
    }
}
