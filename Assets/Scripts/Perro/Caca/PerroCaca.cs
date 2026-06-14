using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerroCaca : MonoBehaviour
{
    public GameObject Caca; //Imagen
    private bool Hizo = false;
    private PerroRuta perro;
    private RutaJugador Player;
    private Animator anim;
    

    void Start()
    {
        Player = FindAnyObjectByType<RutaJugador>();
        if (Caca != null)
        {
            Caca.SetActive(false);
        }        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Perro") && !Hizo) 
        {
            perro = other.GetComponent<PerroRuta>();
            if(perro == null) 
            {
                perro = other.GetComponent<PerroRuta>();
            }
            if(perro == null) 
            {
                return;
            }
            anim = other.GetComponentInChildren<Animator>();

            perro.agarrar();
            Player.SoltarCuerda();
            Player.agente.isStopped = true;
            Player.agente.velocity = Vector3.zero;
            Player.agente.ResetPath();
            Hizo = true;
            //Imagen.SetActive(true);
            if(Caca != null) 
            {
                Caca.SetActive(true);
            }

            if (anim != null)
            {
                anim.SetBool("Caminando", false);
                anim.SetTrigger("Premio"); 
            }
        }
    }

    public void Limpiar() 
    {
        if (!Hizo) 
        {
            return;
        }

        if(Caca != null) 
        {
            Caca.SetActive(false);
        }
        if(perro != null) 
        {
            perro.Soltar();
        }
        if(Player != null) 
        {
            Player.CuerdaSinVuelta();
        }

        if (anim != null)
        {
            anim.SetBool("Caminando", true);
        }

        Hizo = false;
        GetComponent<Collider>().enabled = false;
    }
}
