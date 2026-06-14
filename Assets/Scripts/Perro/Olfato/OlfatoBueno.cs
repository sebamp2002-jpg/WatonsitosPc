using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OlfatoBueno : MonoBehaviour
{
    public float TiempoEspera = 4f;
    private bool olfateando = false;
    private float Tiempo = 0;
    private PerroRuta ruta;
    private RutaJugador Jugador;
    private Animator anim;

    void Start()
    {
        Jugador = FindAnyObjectByType<RutaJugador>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Perro") && !olfateando)
        {
            ruta = other.GetComponentInParent<PerroRuta>();
            if (ruta == null) ruta = other.GetComponent<PerroRuta>();
            if (ruta == null) return;

            anim = other.GetComponentInChildren<Animator>();

            ruta.agarrar();
            Jugador.SoltarCuerda();
            Jugador.agente.isStopped = true;
            Jugador.agente.velocity = Vector3.zero;
            Jugador.agente.ResetPath();
            olfateando = true;

            if (anim != null)
            {
                anim.SetBool("Caminando", false);
                anim.SetTrigger("Oler");
            }

            Debug.Log("Olfato bueno");
        }
    }

    void Update()
    {
        if (!olfateando) return;

        Tiempo += Time.deltaTime;
        if (Tiempo >= TiempoEspera)
            Terminar();
    }

    void Terminar()
    {
        if (ruta != null) ruta.Soltar();
        if (Jugador != null) Jugador.CuerdaSinVuelta();

        olfateando = false;
        Tiempo = 0;

        if (anim != null) anim.SetBool("Caminando", true);

        GetComponent<Collider>().enabled = false;
        Debug.Log("Termino olfato bueno");
    }
}
