using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialogo : MonoBehaviour
{
    public GameObject PanelDialogo, Imagen;
    public TextMeshProUGUI Texto;
    public string[] Lineas;
    private int LineaActual = 0;
    private bool hablando = false, Cerca = false;

    private RutaJugador jugador;

    void Start()
    {
        jugador = FindAnyObjectByType<RutaJugador>();
    }

    void Update()
    {
        if(Cerca && Input.GetKeyDown(KeyCode.E)) 
        {
            if (!hablando) 
            {
                Inicia();
            }
            else 
            {
                Siguiente();
            }
        }
    }
    void Inicia() 
    {
        hablando = true;
        LineaActual = 0;
        PanelDialogo.SetActive(true);
        Texto.text = Lineas[LineaActual];

        Imagen.SetActive(false);
        jugador.SoltarCuerda();
    }

    void Siguiente() 
    {
        LineaActual++;
        if(LineaActual < Lineas.Length) 
        {
            Texto.text = Lineas[LineaActual];
        }
        else 
        {
            Terminar();
        }
    }

    void Terminar() 
    {
        hablando = false;
        PanelDialogo.SetActive(false);
        LineaActual = 0;
        jugador.AgarrarCuerda();
        //Debug.Log("Encargo Recibido!");
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            Cerca = true;

            Imagen.SetActive(true); 
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            Cerca = false;
            PanelDialogo.SetActive(false);
            hablando = false;

            Imagen.SetActive(false);
        }
        
    }
}
