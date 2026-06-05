using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chute : MonoBehaviour
{
   private AudioSource Audiosource;
   private BoxCollider Boxcollider;

   void Start()
   {
    Audiosource = GetComponent<AudioSource>();
    Boxcollider = GetComponent<BoxCollider>();
   }

   void OnTriggerEnter(Collider other)
   {
    if(other.CompareTag("Player"))
    { 
      Audiosource.Play();
    }
  }

  void OnTriggerExit(Collider other)
  {
    if(other.CompareTag("Player"))
    {
      Destroy(Boxcollider);
    }
  }
}
