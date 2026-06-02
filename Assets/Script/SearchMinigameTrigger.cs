using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchMinigameTrigger : MonoBehaviour
{
   public TankController playerController;
    public GameObject currentCCTVCamera;
    public GameObject minigameCamera;
    public GameObject armMinigameRoot;

    private bool isPlayerNear = false;

    void OnTriggerEnter(Collider other)
    {

        
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
          
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) isPlayerNear = false;
    }

    void Update()
    {
        if (isPlayerNear)
        {
         
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
             
                playerController.enabled = false; 
                currentCCTVCamera.SetActive(false);
                minigameCamera.SetActive(true);
                armMinigameRoot.SetActive(true);
                gameObject.SetActive(false);
            }
        }
    }
}
