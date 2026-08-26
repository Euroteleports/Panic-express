using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchMinigameTrigger : MonoBehaviour
{
    [SerializeField] private GameObject currentCCTVCamera;
    [SerializeField] private GameObject minigameCamera;

    private bool isPlayerNear = false;
    private GameObject[] allCams;
    private GameObject cameraActive;
    private BooCam booCam;
    private GameObject olivia;


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;

            booCam = other.GetComponent<BooCam>();

            olivia = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
        }
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isPlayerNear == true && booCam.booVisionActive == false)
        {
            isPlayerNear = false;

            if (booCam.booVisionActive == true)
            {
                booCam.DeactivateBooVision();
                Debug.Log("BooVision est active !");
            }

            booCam.noBooVision = true;

            allCams = GameObject.FindGameObjectsWithTag("CCTV");

            foreach (GameObject cam in allCams)
            {
                if (cam.activeSelf)
                {
                    cameraActive = cam;
                }

                Debug.Log(cameraActive.name + " est active !");
            }

            olivia.SetActive(false);
            cameraActive.SetActive(false);
            minigameCamera.SetActive(true);

            Destroy(gameObject);
        }
    }
}
