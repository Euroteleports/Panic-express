using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalkerCamera : MonoBehaviour
{
    [Tooltip("Glisse ici ton personnage principal")]
    public Transform target; 
    
    [Tooltip("Plus c'est bas, plus le voyeur met du temps à tourner la tête")]
    public float rotationSpeed = 2f; 

    void LateUpdate()
    {
        if (target != null)
        {
            // 1. On trouve la direction entre la caméra et le joueur
            Vector3 directionToPlayer = target.position - transform.position;
            
            // 2. On calcule la rotation exacte pour regarder le joueur
            Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);
            
            // 3. On tourne la caméra avec un effet de lissage (Slerp) pour faire "humain"
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
