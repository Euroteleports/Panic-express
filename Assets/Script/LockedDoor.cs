using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    [Tooltip("Glisse ici l'obstacle ou la porte à faire disparaître")]
    [SerializeField] private GameObject doorToOpen;

    private bool isPlayerNear = false;
    private AudioSource audioSource;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
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
        // Si le joueur est devant et appuie sur Espace
        if (isPlayerNear && Input.GetKeyDown(KeyCode.Space))
        {
            // On interroge directement la variable statique du pied de biche !
            if (CrowbarItem.hasCrowbar)
            {
                audioSource.Play();

                doorToOpen.SetActive(false);

                Debug.Log("Porte forcée avec succès !");

                StartCoroutine(Delais());
            }
        }
    }


    IEnumerator Delais()
    {
        yield return new WaitForSeconds(0.25f);
        Destroy(gameObject);
    }
}
