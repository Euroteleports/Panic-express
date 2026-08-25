using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestApparition : MonoBehaviour
{
    [SerializeField] private float duree = 1f;

    private Renderer rend;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        StartCoroutine(Apparition());
    }

    private IEnumerator Apparition()
    {
        Material material = rend.material;

        Color couleur = material.color;
        couleur.a = 0f;
        material.color = couleur;

        float temps = 0f;

        while (temps < duree)
        {
            temps += Time.deltaTime;

            couleur.a = temps / duree;
            material.color = couleur;

            yield return null;
        }

        couleur.a = 1f;
        material.color = couleur;
    }
}
