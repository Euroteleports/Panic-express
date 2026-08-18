using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private MenuController controller;
    [SerializeField] private bool isPlayButton;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (isPlayButton)
        {
            controller.PlayHover();
        }
        else
        {
            controller.QuitHover();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (isPlayButton)
        {
            controller.PlayExit();
        }
        else
        {
            controller.QuitExit();
        }
    }
}
