using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerroCaca : MonoBehaviour
{
    public GameObject Caca, Imagen;
    private bool Hizo = false;
    private PerroRuta perro;
    private RutaJugador Player;
    private Animator anim;
    

    void Start()
    {
        Player = FindAnyObjectByType<RutaJugador>();
        Caca.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Perro") && !Hizo) 
        {
            perro = other.GetComponent<PerroRuta>();
            anim = other.GetComponentInChildren<Animator>();

            perro.agarrar();
            Player.SoltarCuerda();
            Caca.SetActive(true);
            Hizo = true;
            Imagen.SetActive(true);

            if (anim != null)
            {
                anim.SetBool("Caminando", false);
                anim.SetTrigger("Premio"); 
            }
        }
    }

    public void Limpiar() 
    {
        if (Hizo) 
        {
            Caca.SetActive(false);
            Imagen.SetActive(false);
            Hizo = false;
            perro.Soltar();
            Player.AgarrarCuerda();
            GetComponent<Collider>().enabled = false; 
            if (anim != null)
            {
                anim.SetBool("Caminando", true);
            }
        }
    }
}
