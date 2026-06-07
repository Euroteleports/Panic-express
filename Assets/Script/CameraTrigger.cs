using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    public GameObject cameraToActivate;
    public CharacterController cc;
    public GameObject CamExt;

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

           /*if (cameraToActivate == CamExt)
        {
            // On ne fait la transition QUE si on va vers l'extérieur
            cc.enabled = false;
           // StartCoroutine(Transition());
            Debug.Log("oui");
        }*/
            // On allume uniquement la caméra liée à cette zone
            cameraToActivate.SetActive(true);
            
            
        }
    }/*
        // cc.enabled = false;
       //     StartCoroutine(Transition());
    IEnumerator Transition()
    {
        
        //Mettre fon noird
        
        yield return new WaitForSeconds(2f);
        
        //Mettre son de pas

        //remttre le Character COntroller
        //cc.enabled = true;
    }*/
    }


