using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerroCaca : MonoBehaviour
{
    public GameObject Caca;
    private bool cacaSuelo = false;
    private bool Hizo = false;
    private PerroRuta perro;
    public GameObject Texto;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Perro") && !cacaSuelo && !Hizo) 
        {
            perro = other.GetComponent<PerroRuta>();
            perro.agarrar();
            Caca.SetActive(true);
            cacaSuelo = true;
            Hizo = true;
            Texto.SetActive(true);
        }
    }

    public void Limpiar() 
    {
        if (cacaSuelo) 
        {
            Caca.SetActive(false);
            cacaSuelo = false;
            perro.Soltar();
            Texto.SetActive(false);
        }
    }
}
