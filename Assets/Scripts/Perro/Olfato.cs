using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class Olfato : MonoBehaviour
{
    public float TiempoEspera = 6f;
    float Tiempo = 0;
    private bool olfateando = false;
    private PerroRuta ruta;
    private RutaJugador Jugador;
    private Animator anim;
    public Slider sliderTiempo;
    //public GameObject Texto;

    void Start()
    {
        Jugador = FindAnyObjectByType<RutaJugador>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Perro") && !olfateando) 
        {
            ruta = other.GetComponent<PerroRuta>();
            anim = other.GetComponent<Animator>();

            ruta.agarrar();
            Jugador.SoltarCuerda();
            olfateando = true;
            sliderTiempo.value = 1;
            sliderTiempo.gameObject.SetActive(true);
            Debug.Log("Olfateando");
            //Texto.SetActive(true);
            //Invoke(TiempoEspera);
            if (anim != null)
            {
                anim.SetBool("Caminando", false);
                anim.SetTrigger("Oler");
            }
        }
    }

    void Update()
    {
        if (olfateando)
        {
            Tiempo += Time.deltaTime;
            sliderTiempo.value = 100 - (Tiempo / TiempoEspera * 100);


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
        sliderTiempo.gameObject.SetActive(false);
        Jugador.AgarrarCuerda();
        olfateando = false;
        GetComponent<Collider>().enabled = false;

        if (anim != null)
        {
            anim.SetBool("Caminando", true);
        }
        Debug.Log("Termino");
        //Texto.SetActive(false);
    }
}
