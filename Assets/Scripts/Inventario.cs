using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{
    public GameObject PanelInventario;
    private Items Mano;

    //public GameObject agua, premio, bolsa, celular;
    //private GameObject itemActual = null;
    private bool abierto = false;

    private void Start()
    {
        Mano = FindObjectOfType<Items>();
    }
    private void Update()
    {
        if(Mano == null)
        {
            Mano = FindObjectOfType<Items>();
        }
        if (Input.GetKeyDown((KeyCode.I))) 
        {
            if (abierto) 
            {
                CerrarInventario();
            }
            else 
            {
                AbrirInventario();
            }
        }
    }

    public void AbrirInventario() 
    {
        PanelInventario.SetActive(true);
        abierto = true;
    }
    public void CerrarInventario() 
    {
        PanelInventario.SetActive(false);
        abierto = false;
    }
    //void Mostrar(GameObject item) 
    //{
        //if(itemActual != null) 
        //{
            //itemActual.SetActive(false);
        //}
        //itemActual = item;
        //itemActual.SetActive(true);
        //itemActual.transform.position = Mano.position;
        //itemActual.transform.SetParent(Mano);
        //CerrarInventario();
    //}

    public void Agua() 
    {
        Mano.Mostrar(Mano.agua);
        CerrarInventario();
        //Debug.Log("Agua");
    }
    public void Premio() 
    {
        Mano.Mostrar(Mano.premio);
        CerrarInventario();
        //Debug.Log("Premio");
    }
    public void BolsaBasura() 
    {
        Mano.Mostrar(Mano.bolsa);
        CerrarInventario();
        //Debug.Log("Basura");
    }
    //public void Celular() 
    //{
        //Mano.Mostrar(Mano.celular);
        //CerrarInventario();
        //Debug.Log("Celular");
    //}

}
