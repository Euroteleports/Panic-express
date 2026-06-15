using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
   
    public GameObject cameraToActivate;





    void OnTriggerEnter(Collider other)

    {

        // On vérifie que c'est bien le joueur qui entre dans la zone

        if (other.CompareTag("Player"))

        {

            // On cherche toutes les caméras de la scène et on les éteint

            GameObject[] allCams = GameObject.FindGameObjectsWithTag("CCTV");

            foreach(GameObject cam in allCams)

            {

                cam.SetActive(false);

            }



         

            cameraToActivate.SetActive(true);

           

         

           

           


           

           

        }

    }

        // cc.enabled = false;

       //     StartCoroutine(Transition());

    
}
