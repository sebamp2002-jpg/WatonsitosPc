using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punto : MonoBehaviour
{
    public GameObject ImagenDestino;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            ImagenDestino.SetActive(false);
            gameObject.SetActive(false);
            Debug.Log("Listo");
        }
    }
}
