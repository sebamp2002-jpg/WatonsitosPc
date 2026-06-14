using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerroAgua : MonoBehaviour
{
    private bool activo = false;
    private PerroRuta perro;
    private RutaJugador jugador;
    private Animator anim;

    void Start()
    {
        jugador = FindAnyObjectByType<RutaJugador>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Perro") && !activo)
        {
            perro = other.GetComponentInParent<PerroRuta>();
            if (perro == null) perro = other.GetComponent<PerroRuta>();
            if (perro == null) return;

            anim = other.GetComponentInChildren<Animator>();

            perro.agarrar();
            jugador.SoltarCuerda();
            jugador.agente.isStopped = true;
            jugador.agente.velocity = Vector3.zero;
            jugador.agente.ResetPath();
            activo = true;

            Debug.Log("Perro cansado, dale agua");
        }
    }

    public void DarAgua()
    {
        if (!activo) return;

        if (perro != null) 
        {
            perro.Soltar();
        }

        if (jugador != null) 
        {
            jugador.CuerdaSinVuelta();
        } 
        if (anim != null) 
        {
            anim.SetBool("Caminando", true);
        }

        activo = false;
        GetComponent<Collider>().enabled = false;
        Debug.Log("Agua dada, siguen");
    }
}
