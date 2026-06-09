using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogoObligatorio : MonoBehaviour
{
    public GameObject PanelDialogo;
    public TextMeshProUGUI Texto;
    public string[] Lineas;
    private int Actual = 0;
    private bool Hablando, Listo = false;
    private RutaJugador jugador;
    
    void Start()
    {
        jugador = FindAnyObjectByType<RutaJugador>();
        if(jugador == null) 
        {
            Debug.LogError("Nofunciona");
        }
        else 
        {
            Debug.Log("Funciona");
        }
    }

    
    void Update()
    {
        if(Hablando && Input.GetKeyDown(KeyCode.E)) 
        {
            SiguienteObligado();
        }
    }

    void IniciarObligado() 
    {
        Hablando = true;
        Actual = 0;
        PanelDialogo.SetActive(true);
        Texto.text = Lineas[Actual];
        jugador.SoltarCuerda();
    }

    void SiguienteObligado() 
    {
        Actual++;
        if(Actual < Lineas.Length) 
        {
            Texto.text = Lineas[Actual];
        }
        else 
        {
            TerminarObligado();
        }
    }

    void TerminarObligado() 
    {
        Hablando = false;
        Listo = true;
        PanelDialogo.SetActive(false);
        jugador.AgarrarCuerda();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Detecta");
        if(other.CompareTag("Player")&& !Listo) 
        {
            IniciarObligado();
        }
    }
}
