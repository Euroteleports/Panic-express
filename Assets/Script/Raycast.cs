using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
private Ray _ray;
    private RaycastHit _hit;
    public Transform Cam;
    public bool estVu = false;

    // VARIABLE POUR STOCKER LA HAUTEUR INITIALE
    private float _hauteurInitiale;

    void Start()
    {
        // Au lancement du jeu, on mémorise la vraie hauteur de ta caméra
        if (Cam != null)
        {
            _hauteurInitiale = Cam.transform.position.y;
        }
    }

    void Update()
    {
        _ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(_ray.origin, _ray.direction * 100f, Color.red);
        
        if (Physics.Raycast(_ray, out _hit, 100f))
        {
            if (_hit.collider.CompareTag("Respawn"))
            {
                estVu = true;
            } 
            else
            {
                estVu = false;
            }
        }
        else
        {
            estVu = false;
        }

        // --- DEPLACEMENT ---
        Vector3 nouvellePos = Cam.transform.position;

        if (estVu)
        {
            nouvellePos.y = 4f; // La hauteur quand elle se baisse
        } 
        else 
        {
            // Au lieu d'un chiffre fixe, on lui redonne sa VRAIE hauteur de départ
            nouvellePos.y = _hauteurInitiale; 
        }

        Cam.transform.position = nouvellePos;
    }
}


/* Donc l'objectif etant de detecter le tag de l'observateur, je creer donc un raycact qui se tyraduit par
   "Physics.Raycast()" en parametre on met sa position, la ou il regarde (d'ou le "forward").
   Puis on vient chercher le tag, classico-classique.*/