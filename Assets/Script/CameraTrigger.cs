using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    public GameObject cameraToActivate;

    private GameObject[] allCams;
    private GameObject cameraActive;


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        { 
            allCams = GameObject.FindGameObjectsWithTag("CCTV");

            foreach (GameObject cam in allCams)
            {
                if (cam.activeSelf)
                {
                    cameraActive = cam;
                    Debug.Log(cameraActive.name + " est active !");
                }
            }

            cameraActive.SetActive(false);

            cameraToActivate.SetActive(true);

            cameraActive = cameraToActivate;
        }


        // On vérifie que c'est bien le joueur qui entre dans la zone
        //if (other.CompareTag("Player"))
        //{
        //    // On cherche toutes les caméras de la scène et on les éteint
        //    GameObject[] allCams = GameObject.FindGameObjectsWithTag("CCTV");

        //    foreach (GameObject cam in allCams)
        //    {
        //        cam.SetActive(false);
        //    }

        //    cameraToActivate.SetActive(true);
        //}
    }
}
