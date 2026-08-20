using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FearSmall : MonoBehaviour
{
    private FearController fearController;


    void Start()
    {
        fearController = GetComponentInParent<FearController>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            fearController.isPlayerInFearSmall = true;

            Debug.Log("Joueur dans la petite zone");
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            fearController.isPlayerInFearSmall = false;

            Debug.Log("Joueur sort de la petite zone");
        }
    }
}
