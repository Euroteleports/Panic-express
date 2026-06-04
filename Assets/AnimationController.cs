using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isRunningHash;

    float velocity = 0.0f;
    [SerializeField] float acceleration = 0.1f;
    [SerializeField] float decceleration = 0.5f;
    int VelocityHash;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("is walking");
        isRunningHash = Animator.StringToHash("is running");

        VelocityHash = Animator.StringToHash("Velocity");
    }

    // Update is called once per frame
    void Update()
    {
        bool isRunning = animator.GetBool(isRunningHash);
        bool isWalking = animator.GetBool(isWalkingHash);
        bool forwardPressed = Input.GetKey("w");
        bool runPressed = Input.GetKey("left shift");

        if (/*!isWalking && */ forwardPressed && velocity < 1.0f)
        {
            velocity += Time.deltaTime * acceleration;
            //animator.SetBool(isWalkingHash, true);
        }

        if (/*isWalking && */ !forwardPressed && velocity > 0.0f)
        {
            velocity -= Time.deltaTime * decceleration;
            //animator.SetBool(isWalkingHash, false);
        }

        if (/*!isWalking && */!forwardPressed && velocity < 0.0f)
        {
            velocity = 0.0f;
            //animator.SetBool(isWalkingHash, false);
        }


        /*if (!isRunning && (forwardPressed && runPressed))
        {
            animator.SetBool(isRunningHash, true);
        }

         if (isRunning && (!forwardPressed || !runPressed))
        {
            animator.SetBool(isRunningHash, false);
        }*/

        animator.SetFloat(VelocityHash, velocity);
    }
}
