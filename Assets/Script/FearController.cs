using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FearController : MonoBehaviour
{
    public static float currentFear = 0f;

    public bool isPlayerInFearSmall = false;
    public bool isPlayerInFearBig = false;

    [SerializeField] private GameObject deathScreen;
    [SerializeField] private AudioClip[] babySoundFear;

    [Header("Mécanique de Peur")]
    [Tooltip("Vitesse à laquelle la jauge monte par seconde")]
    [SerializeField] private float fearSmallIncreaseRate = 20f;
    [SerializeField] private float fearBigIncreaseRate = 50f;
    [SerializeField] private float fearDecreaseRate = 3.5f;
    [SerializeField] private float timeToBabySoundAgain = 4f;


    private AudioSource audioSource;
    private bool babyFearSoundAgain = true;
    private bool playerDead = false;


    void Start()
    {
        // Sécurité : On remet la peur à zéro et le temps à la normale au chargement
        currentFear = 0f;
        Time.timeScale = 1f;
        audioSource = GetComponent<AudioSource>();
    }


    void Update()
    {
        if (!playerDead)
        {
            BabyFearSound();
            HandleFear();
        }
    }


    void HandleFear()
    {
        if (isPlayerInFearSmall == true)
        {
            // La peur augmente progressivement
            currentFear += fearSmallIncreaseRate * Time.deltaTime;
            Debug.Log("Peur : " + Mathf.Round(currentFear) + "%");

            if (currentFear >= 100f)
            {
                DeathByFear();
            }
        }
        else if (isPlayerInFearBig == true)
        {
            // La peur augmente plus vite 
            currentFear += fearBigIncreaseRate * Time.deltaTime;
            Debug.Log("Peur : " + Mathf.Round(currentFear) + "%");

            if (currentFear >= 100f)
            {
                DeathByFear();
            }
        }
        else if (currentFear > 0)
        {
            // La peur redescend doucement quand on sort de la zone
            currentFear -= (fearSmallIncreaseRate / fearDecreaseRate) * Time.deltaTime;
            currentFear = Mathf.Clamp(currentFear, 0f, 100f);
        }
    }


    public void DeathByFear()
    {
        Debug.Log("MORT DE PEUR ! On recommence.");
        Time.timeScale = 0f;
        deathScreen.SetActive(true);
        currentFear = 0;
        playerDead = true;
    }


    void BabyFearSound()
    {
        if (isPlayerInFearSmall && babyFearSoundAgain || isPlayerInFearBig && babyFearSoundAgain)
        {
            SonAleatoires();
            StartCoroutine(TimeToBabySoundAgain());
            babyFearSoundAgain = false;
        }
    }


    void SonAleatoires()
    {
        int IndexAleatoire = Random.Range(0, babySoundFear.Length);

        audioSource.clip = babySoundFear[IndexAleatoire];
        audioSource.Play();
    }


    IEnumerator TimeToBabySoundAgain()
    {
        yield return new WaitForSeconds(timeToBabySoundAgain);
        Debug.Log("pleur");
        babyFearSoundAgain = true;
    }
}
