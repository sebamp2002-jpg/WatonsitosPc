using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Timers;
using UnityEngine;

public class Olfato : MonoBehaviour
{
    public float TiempoEspera = 6f;
    float Tiempo = 0;
    private bool olfateando = false;
    private PerroRuta ruta;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Perro") && !olfateando) 
        {
            ruta = other.GetComponent<PerroRuta>();
            ruta.agarrar();
            olfateando = true;
            Debug.Log("Olfateando");
            //Invoke(TiempoEspera);            
        }
    }

    void Update()
    {
        if (olfateando)
        {
            Tiempo += Time.deltaTime;

            if (Tiempo >= TiempoEspera)
            {
                Terminar();
                Tiempo = 0;
            }
        }
    }

    void Terminar() 
    {
        ruta.Soltar();
        olfateando = false;
        Debug.Log("Termino");
    }
}
