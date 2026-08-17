using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public bool stopPlayer = false;
    public float moveSpeed;
    public float rotationSpeed;
    public AudioClip[] SonsDePas;
    [SerializeField] private Animator animator;

    private CharacterController controller;
    private AudioSource audioSource;

    int walking;
    int running;
    int turning;
    float velocity;


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
        if (stopPlayer == false)
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
                    animator.speed = 1.5f;
                    animator.SetBool(walking, true);
                }

                if (!audioSource.isPlaying)
                {
                    SonAleatoires();
                }
            }
            else
            {
                animator.SetBool(walking, false);
                audioSource.Stop();
            }

            /*if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                Debug.Log("Shift pressé !");
            }*/

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

    void SonAleatoires()
    {
        int IndexAleatoire = Random.Range(0, SonsDePas.Length);

        audioSource.clip = SonsDePas[IndexAleatoire];
        audioSource.Play();
    }
}
