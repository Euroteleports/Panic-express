using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BooCam : MonoBehaviour
{
    [SerializeField] private GameObject[] allCams;
    [SerializeField] private GameObject camBoo;
    [SerializeField] private GameObject decorOnlyBoo;
    private GameObject cameraActive;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (!camBoo.activeSelf)
            {
                camBoo.SetActive(true);

                decorOnlyBoo.SetActive(true);

                foreach (GameObject cam in allCams)
                {
                    Camera cameraComponent = cam.GetComponent<Camera>();
                    cameraComponent.enabled = false;

                    AudioListener audioComponent = cam.GetComponent<AudioListener>();
                    audioComponent.enabled = false;
                }

                Debug.Log("Camera Boo Activé !");
            }
            else
            {
                camBoo.SetActive(false);

                decorOnlyBoo.SetActive(false);

                foreach (GameObject cam in allCams)
                {
                    Camera cameraComponent = cam.GetComponent<Camera>();
                    cameraComponent.enabled = true;

                    AudioListener audioComponent = cam.GetComponent<AudioListener>();
                    audioComponent.enabled = true;
                }

                Debug.Log("Camera Boo Désactivé !");
            }
        }
    }
}
