using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FearBig : MonoBehaviour
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
            Debug.Log("Joueur dans la grande zone");

            fearController.isPlayerInFearBig = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Joueur sort de la grande zone");

            fearController.isPlayerInFearBig = false;
        }
    }
}
