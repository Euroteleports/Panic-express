using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSmashTrigger : MonoBehaviour
{
    public GameObject solidWall;     // Le mur de base
    public GameObject brokenWall;    // Les débris (optionnel)
    public GameObject enemy;         // Le monstre
    public float enemySpeed = 3f;    // Sa vitesse de course
    
    private Transform playerTransform;
    private bool isChasing = false;
    public GameObject Camera1;
    public GameObject Camera2;

    void OnTriggerEnter(Collider other)
    {
        // Si c'est le joueur ET qu'il a la clef ET qu'on n'a pas déjà lancé l'event
        if (other.CompareTag("Player") && FinalKey.hasFinalKey && !isChasing)
        {
            playerTransform = other.transform;
            
            // On casse le mur !
            if (solidWall != null) solidWall.SetActive(false);
            if (brokenWall != null) brokenWall.SetActive(true);
            
            // On fait spawner le monstre
            if (enemy != null) enemy.SetActive(true);
            
            isChasing = true; // On lance la poursuite
            Debug.Log("LE MUR EST DÉTRUIT ! FUYEZ !");
            Camera1.SetActive(false);
            Camera2.SetActive(false);
        }
    }

    void Update()
    {
        // Logique de poursuite "Game Jam" (ultra simple et efficace)
        if (isChasing && playerTransform != null && enemy != null)
        {
            // Le monstre regarde le joueur (mais on bloque l'axe Y pour qu'il ne se penche pas en avant)
            Vector3 lookPosition = new Vector3(playerTransform.position.x, enemy.transform.position.y, playerTransform.position.z);
            enemy.transform.LookAt(lookPosition);
            
            // Le monstre avance tout droit vers le joueur
            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, playerTransform.position, enemySpeed * Time.deltaTime);
        }
    }
}
