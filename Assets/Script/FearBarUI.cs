using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FearBarUI : MonoBehaviour
{
    [Tooltip("Glisse ici l'image de ta barre de peur (celle réglée sur Filled)")]
    [SerializeField] private Image fillImage;

    void Update()
    {
        // On vérifie que l'image est bien connectée
        if (fillImage != null)
        {
            // La variable currentFear va de 0 à 100
            // Le fillAmount de l'image attend une valeur entre 0 et 1
            // On divise donc simplement par 100 pour convertir !
            fillImage.fillAmount = FearController.currentFear / 100f;
        }
    }
}
