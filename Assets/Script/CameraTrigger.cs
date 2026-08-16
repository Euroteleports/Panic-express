using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    [SerializeField] private GameObject cameraToActivate;

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
                }

                Debug.Log(cameraActive.name + " est active !");
            }

            cameraActive.SetActive(false);

            cameraToActivate.SetActive(true);
        }
    }
}
