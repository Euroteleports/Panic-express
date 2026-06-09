using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public float moveSpeed;
    public float rotationSpeed;
    private CharacterController controller;

    private AudioSource audioSource;

    int walking;
    int running;
    int turning;
    float velocity;
    [SerializeField] private Animator animator;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        audioSource = GetComponent<AudioSource>();

        walking = Animator.StringToHash("is walking");
        running = Animator.StringToHash("is running");
        turning = Animator.StringToHash("is turning");

        velocity = Animator.StringToHash("is velocity");
    }

    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

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
           
            if (animator != null)
            {
                animator.speed = -1.5f;
                animator.SetBool(walking, true);
            }

            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            animator.SetBool(walking, false);
            audioSource.Stop();
        }

        /*if (horizontalInput != 0)
        {
            Debug.Log("Turning");
            if (animator != null)
            {
                animator.SetBool(turning, true);
            }

            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            animator.SetBool(turning, false);
            audioSource.Stop();
        }*/
    }
}
