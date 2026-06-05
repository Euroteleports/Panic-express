using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiperArm : MonoBehaviour
{
    public float swingSpeed = 100f;
    public float maxAngle = 60f; // Il ne pourra pas aller plus loin que 60 degrés à gauche ou à droite
    private AudioSource Audiosource;
    
    private float currentAngle = 0f;

    void Start()
    {
        Audiosource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // On récupère les touches Q/D ou les flèches Gauche/Droite
        float input = Input.GetAxis("Horizontal"); 
        
        // On calcule le nouvel angle
        currentAngle += input * swingSpeed * Time.deltaTime;
        
        // On bloque l'angle pour ne pas faire des tours complets (le fameux essuie-glace)
        currentAngle = Mathf.Clamp(currentAngle, -maxAngle, maxAngle);
        
        // On applique la rotation (ici sur l'axe Z, modifie si ton bras est orienté différemment)
        transform.localRotation = Quaternion.Euler(0, 0, currentAngle);

       /* if(horizontalInput != 0)
        {
            AudioSource.Play();
        }else
        {
            AudioSource.Stop();
        }*/
    }
}
