using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Carnet : MonoBehaviour
{
    public TextMeshProUGUI textoResultado; 

    public void SeleccionarHombre()
    {
        Datos.instancia.genero = "Hombre";
        textoResultado.text = "Genero: Hombre";
    }

    public void SeleccionarMujer()
    {
        Datos.instancia.genero = "Mujer";
        textoResultado.text = "Genero: Mujer";
    }

    public void SeleccionarNoBinario()
    {
        Datos.instancia.genero = "No-Binario";
        textoResultado.text = "Genero: No-Binario";
    }
}
