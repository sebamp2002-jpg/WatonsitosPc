using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public GameObject agua, premio, bolsa; //Celular
    private GameObject itemActual = null;

    private PerroCaca perrocaca;
    private Ladrar perroladra;

    void Update()
    {
        //PerroCaca
        if(perrocaca == null) 
        {
            perrocaca = FindAnyObjectByType<PerroCaca>();
        }
        //Ladra
        if(perroladra == null) 
        {
            perroladra = FindAnyObjectByType<Ladrar>();
        }
    }

    public void UsarBolsa() 
    {
        if(perrocaca != null)
        {
            perrocaca.Limpiar();
        }
        Ocultar();
    }

    public void UsarPremio() 
    {
        if(perroladra != null) 
        {
            perroladra.Darpremio();
        }
    }
    public void Mostrar(GameObject item)
    {
        if (itemActual == item) 
        {
            Ocultar();
            return;
        }
        if (itemActual != null)
        {
            itemActual.SetActive(false);
        }
        itemActual = item;
        itemActual.SetActive(true);
    }
    public void Ocultar() 
    {
        if(itemActual != null) 
        {
            itemActual.SetActive(false);
            itemActual = null;
        }
    }
}
