using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Daño : MonoBehaviour
{
    public float dañoAlPerro = 10f;
    public float tiempoEntreDaño = 1f;

    private float tiempoActual;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Perro"))
        {
            tiempoActual += Time.deltaTime;

            if (tiempoActual >= tiempoEntreDaño)
            {
                Barradevida vida = other.GetComponent<Barradevida>();

                if (vida != null)
                {
                    vida.RecibirDaño(dañoAlPerro);
                }

                tiempoActual = 0;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Perro"))
        {
            tiempoActual = 0;
        }
    }
}
