using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public GameObject agua, premio, bolsa, celular;
    private GameObject itemActual = null;

    public void Mostrar(GameObject item)
    {
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
