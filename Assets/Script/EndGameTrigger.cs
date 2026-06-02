using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameTrigger : MonoBehaviour
{
   [Tooltip("Le Canvas qui contient ton texte de fin")]
    public GameObject endScreenCanvas; 
    
    [Tooltip("Temps en secondes avant le crash du jeu")]
    public float delayBeforeQuit = 3f;

    void OnTriggerEnter(Collider other)
    {
        // On vérifie que c'est le joueur ET qu'il possède bien la clef finale
        if (other.CompareTag("Player") && FinalKey.hasFinalKey)
        {
            Debug.Log("FIN DU PROTO ! Lancement de la séquence d'arrêt...");
            
            // Affiche l'écran de fin
            if (endScreenCanvas != null)
            {
                endScreenCanvas.SetActive(true);
            }
            
            // On lance le minuteur vers le Alt+F4
            StartCoroutine(CrashGameRoutine());
        }
        else if (other.CompareTag("Player") && !FinalKey.hasFinalKey)
        {
            // Petit feedback si le joueur essaie de fuir sans la clef
            Debug.Log("La porte est fermée à clef... Je ne peux pas partir.");
        }
    }

    IEnumerator CrashGameRoutine()
    {
        // On gèle le temps (le monstre s'arrête net derrière nous)
        Time.timeScale = 0f; 

        // On attend quelques secondes en temps réel (vu qu'on a gelé le temps du jeu)
        yield return new WaitForSecondsRealtime(delayBeforeQuit);

        Debug.Log("BOOM ! Alt+F4 !");

        // Ferme le jeu une fois compilé (.exe)
        Application.Quit();

        // Stoppe le mode Play directement dans l'éditeur Unity pour tes tests
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
