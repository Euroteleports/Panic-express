using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private MenuController controller;
    [SerializeField] private bool isPlayButton;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        Time.timeScale = 1f;
    }

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

        audioSource.Play();
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
