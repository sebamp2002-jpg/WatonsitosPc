using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladrar : MonoBehaviour
{
    private bool ladrando = false;
    private bool listo = false;
    private PerroRuta perro;
    public GameObject Texto;
    //private Animator anim;

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("ladra");
        //perro = other.GetComponent<PerroRuta>();
        //perro.agarrar();
        //ladrando = true;
        //listo = true;
        Debug.Log("Entro al trigger: " + other.gameObject.name + " tag: " + other.tag);

        if (other.CompareTag("Perro") && !listo)
        {
            perro = other.GetComponent<PerroRuta>();
            //anim = other.GetComponentInChildren<Animator>();
            if (perro == null)
            {
                //perro.agarrar();
                //ladrando = true;
                //listo = true;
                //Debug.Log("ladra");
                //Texto.SetActive(true);
                //Debug.LogError("El objeto Perro no tiene PerroRuta!");
                return;
            }
            perro.agarrar();
            ladrando = true;
            listo = true;
            Debug.Log("ladra");
            Texto.SetActive(true);
            //anim.SetTrigger("Ladrar");
        }
    }

    public void Darpremio() 
    {
        if (ladrando && perro != null) 
        {
            Debug.Log("Se calmo");
            ladrando = false;
            perro.Soltar();
            Texto.SetActive(false);
            //anim.ResetTrigger("Ladrar");
        }
    }
}
