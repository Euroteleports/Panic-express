using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPatrol : MonoBehaviour
{
    [Header("Déplacements")]
    [Tooltip("Glisse ici tes points de patrouille (Empty GameObjects)")]
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float moveSpeed = 0.325f;

    private int currentWaypointIndex = 0;


    void Update()
    {
        Patrol();
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
}
