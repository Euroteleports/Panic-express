using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BooCam : MonoBehaviour
{
    public bool booVisionActive = false;
    public bool noBooVision = false;

    [SerializeField] private GameObject[] allCams;
    [SerializeField] private GameObject camBoo;
    [SerializeField] private GameObject decorOnlyBoo;

    private GameObject[] allBooEnemys;
    private GameObject cameraActive;


    void Start()
    {
        allBooEnemys = GameObject.FindGameObjectsWithTag("BooEnemy");
        foreach (GameObject enemy in allBooEnemys)
        {
            enemy.SetActive(false);
        }
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && noBooVision == false)
        {
            if (!camBoo.activeSelf)
            {
                ActivateBooVision();
            }
            else
            {
                DeactivateBooVision();
            }
        }
    }


    public void ActivateBooVision()
    {
        booVisionActive = true;

        camBoo.SetActive(true);

        decorOnlyBoo.SetActive(true);

        foreach (GameObject enemy in allBooEnemys)
        {
            enemy.SetActive(true);
        }

        foreach (GameObject cam in allCams)
        {
            Camera cameraComponent = cam.GetComponent<Camera>();
            cameraComponent.enabled = false;

            AudioListener audioComponent = cam.GetComponent<AudioListener>();
            audioComponent.enabled = false;
        }

        Debug.Log("Camera Boo Activé !");
    }


    public void DeactivateBooVision()
    {
        booVisionActive = false;

        camBoo.SetActive(false);

        decorOnlyBoo.SetActive(false);

        foreach (GameObject enemy in allBooEnemys)
        {
            enemy.SetActive(false);
        }

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
