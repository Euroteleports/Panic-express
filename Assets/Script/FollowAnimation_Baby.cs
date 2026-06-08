using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAnimation_Baby : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private Transform babyTransform;
    private Transform ChestTransform;

    private int walking;

    void Start()
    {
        babyTransform = GetComponent<Transform>();
        ChestTransform = animator.GetBoneTransform(HumanBodyBones.Chest);

        walking = Animator.StringToHash("is walking");
    }

    void Update()
    {
        babyTransform.SetParent(ChestTransform);
        bool isWalking = animator.GetBool(walking);

        if (ChestTransform != null)
        {
            Debug.Log("Bone trouvable !");

            if (isWalking)
            {
                Debug.Log("test !");
                
            }
        }
        else
        {
            Debug.Log("Bone introuvable !");
        }
    }
}