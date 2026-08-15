using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BooCam : MonoBehaviour
{
    [SerializeField] private GameObject camBoo;
    private GameObject cameraActive;
    private GameObject[] allCams;

    public bool booVision;


    void Start()
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
    }

    void Update()
    {



        if (Input.GetKeyDown(KeyCode.LeftShift))
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

            if (!camBoo.activeSelf)
            {
                camBoo.SetActive(true);
                booVision = true;

                cameraActive.SetActive(false);

                Debug.Log("Camera Boo Désactivé !");
            }
            else
            {
                camBoo.SetActive(false);
                booVision = false;

                cameraActive.SetActive(true);

                Debug.Log("Camera Boo Activé !");
            }
        }
    }
}
