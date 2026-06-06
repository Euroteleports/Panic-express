using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
Ray _ray;
private RaycastHit _hit;
public GameObject Cam;



  void Update()
  {

    //C'est pour l'optimisation
    _ray = new Ray(transform.position, transform.forward);

    // Trace le rayon
    Debug.DrawRay(_ray.origin, _ray.direction * 100f, Color.red);
    
    if(Physics.Raycast(_ray, out _hit, 100f))
    {
       if(_hit.collider.CompareTag("Respawn"))
       {
        Debug.Log("Observateur !");
        Vector3 positionActuelle = Cam.transform.position;
        positionActuelle.y = 4f; // Par exemple, monte à 10 unités de hauteur
        Cam.transform.position = positionActuelle;
       }
    }
  }
}

/* Donc l'objectif etant de detecter le tag de l'observateur, je creer donc un raycact qui se tyraduit par
   "Physics.Raycast()" en parametre on met sa position, la ou il regarde (d'ou le "forward").
   Puis on vient chercher le tag, classico-classique.*/