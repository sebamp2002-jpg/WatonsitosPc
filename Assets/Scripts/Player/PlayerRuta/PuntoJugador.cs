using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntoJugador : MonoBehaviour
{
    private RutaJugador ruta;
    
    void Start()
    {
        ruta = FindAnyObjectByType<RutaJugador>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            ruta.SiguientePlayer();
        }
    }

}
