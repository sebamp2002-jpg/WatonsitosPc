using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RutaJugador : MonoBehaviour
{
    public GameObject[] Puntos;
    private int Ahora = 0;
    private bool AhoraRuta = false;

    void Start()
    {
        foreach (GameObject punto in Puntos) 
        {
            punto.SetActive(false);
        }
    }

    public void IniciarPlayer() 
    {
        AhoraRuta = true;
        Ahora = 0;
        Puntos[Ahora].SetActive(true);
    }

    public void SiguientePlayer() 
    {
        Puntos[Ahora].SetActive(false);
        Ahora++;

        if(Ahora < Puntos.Length) 
        {
            Puntos[Ahora].SetActive(true);
        }
        else 
        {
            AhoraRuta = false;
        }
    }
}
