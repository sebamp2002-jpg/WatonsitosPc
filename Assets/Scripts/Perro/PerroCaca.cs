using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerroCaca : MonoBehaviour
{
    public GameObject Caca;
    private bool cacaSuelo = false;
    private bool Hizo = false;
    private PerroRuta perro;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Perro") && !cacaSuelo && !Hizo) 
        {
            perro = other.GetComponent<PerroRuta>();
            perro.agarrar();
            Caca.SetActive(true);
            cacaSuelo = true;
            Hizo = true;
        }
    }

    public void Limpiar() 
    {
        if (cacaSuelo) 
        {
            Caca.SetActive(false);
            cacaSuelo = false;
            perro.Soltar();
        }
    }
}
