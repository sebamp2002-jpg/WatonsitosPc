using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Ladrar : MonoBehaviour
{
    private bool ladrando = false;
    private bool listo = false;
    private PerroRuta perro;
    private RutaJugador Jugador;
    private Animator anim;
    public DarPremio prueba;

    //private Animator anim;

    void Start()
    {
        Jugador = FindAnyObjectByType<RutaJugador>();
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("ladra");
        //perro = other.GetComponent<PerroRuta>();
        //perro.agarrar();
        //ladrando = true;
        //listo = true;
        //Debug.Log("Entro al trigger: " + other.gameObject.name + " tag: " + other.tag);

        if (other.CompareTag("Perro") && !listo)
        {
            perro = other.GetComponent<PerroRuta>();
            //anim = other.GetComponentInChildren<Animator>();
            if (perro == null)
            {
                return;
            }
            anim = other.GetComponentInChildren<Animator>();

            perro.agarrar();
            Jugador.SoltarCuerda();
            ladrando = true;
            listo = true;
            prueba.IniciarPrueba(this);

            if (anim != null)
            {
                anim.SetBool("Caminando", false);
                anim.SetTrigger("Ladrar");
            }
        }
    }

    public void Darpremio()
    {
        if (ladrando && perro != null)
        {
            Debug.Log("Se calmo");
            ladrando = false;
            listo = false;
             

        }

        if(anim != null) 
        {
            anim.SetTrigger("Premio");
        }
        perro.Soltar();
        Jugador.AgarrarCuerda();
        if (anim != null)
        {
            anim.SetBool("Caminando", true);
        }
        GetComponent<Collider>().enabled = false;
    }

    void ComienzaJugador() 
    {
        Jugador.AgarrarCuerda();
    }
}
