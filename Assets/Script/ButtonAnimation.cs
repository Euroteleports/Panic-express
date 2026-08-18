using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Animator animator;

    public void OnPointerEnter(PointerEventData eventData)
    {
        animator.SetTrigger("Premier");
        animator.ResetTrigger("Repli");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        animator.SetTrigger("Repli");
    }
}
