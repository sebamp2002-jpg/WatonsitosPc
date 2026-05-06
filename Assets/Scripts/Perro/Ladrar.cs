using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladrar : MonoBehaviour
{
    private bool ladrando = false;
    private bool listo = false;
    private PerroRuta perro;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("ladra");
        perro = other.GetComponent<PerroRuta>();
        perro.agarrar();
        ladrando = true;
        listo = true;
    }

    public void Darpremio() 
    {
        if (ladrando) 
        {
            Debug.Log("Se calmo");
            ladrando = false;
            perro.Soltar();
        }
    }
}
