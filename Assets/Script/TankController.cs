using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public float moveSpeed = 4f;
    public float rotationSpeed = 150f;
    private AudioSource Audiosource;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Audiosource = GetComponent<AudioSource>();
    }

    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        // Gère la rotation (Gauche / Droite)
        float turn = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        transform.Rotate(0, turn, 0);

        // Gère l'avancée (Haut / Bas)
        float move = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        
        
        // Applique le mouvement en prenant en compte la gravité basique
        Vector3 movement = transform.forward * move;
        movement.y -= 9.81f * Time.deltaTime; 

         

        controller.Move(movement);

if (verticalInput != 0)
    {
        if (!Audiosource.isPlaying)
        {
            Audiosource.Play();
        }
    }
    else
    {
        Audiosource.Stop();
    }


    }
}
