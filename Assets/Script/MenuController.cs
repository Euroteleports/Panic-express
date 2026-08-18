using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void PlayHover()
    {
        animator.SetTrigger("onPlay");
    }

    public void PlayExit()
    {
        animator.ResetTrigger("onPlay");
    }

    public void QuitHover()
    {
        animator.SetTrigger("onQuit");
    }

    public void QuitExit()
    {
        animator.ResetTrigger("onQuit");
    }
}
