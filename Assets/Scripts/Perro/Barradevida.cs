using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barradevida : MonoBehaviour
{
    public Image barra; 
    public float vidaActual; 
    public float vidaMaxima;

    private void Update() 
    {    
        barra.fillAmount = vidaActual / vidaMaxima; 
    }

    public void RecibirDaño(float daño)
    {
        vidaActual -= daño; 
        if (vidaActual < 0) 
            vidaActual = 0;
        if (vidaActual==0)
        {
            Debug.Log("Perro muerto");
        }
    }




}
