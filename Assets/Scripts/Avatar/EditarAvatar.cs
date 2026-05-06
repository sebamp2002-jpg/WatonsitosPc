using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EditarAvatar : MonoBehaviour
{
    public GameObject Hombre, Mujer, otro;
    void Start()
    {
        MostrarHombre();
    }
    //cambiar genero
    public void MostrarHombre() 
    {
        Hombre.SetActive(true);
        Mujer.SetActive(false);
        otro.SetActive(false);
        AvatarEditado.instancia.avatar = "hombre";

    }
    public void MostrarMujer() 
    {
        Hombre.SetActive(false);
        Mujer.SetActive(true);
        otro.SetActive(false);
        AvatarEditado.instancia.avatar = "mujer";
    }
    public void MostrarOtro() 
    {
        Hombre.SetActive(false);
        Mujer.SetActive(false);
        otro.SetActive(true);
        AvatarEditado.instancia.avatar = "otro";
    }

    //cambiar color piel
    public void ColorClaro() 
    {
        AvatarEditado.instancia.colorpiel = new Color(1f, 0.85f, 0.7f);
        AplicarColor();
    }
    public void ColorMedio() 
    {
        AvatarEditado.instancia.colorpiel = new Color(0.8f, 0.6f, 0.4f);
        AplicarColor();
    }
    public void ColorOscuro() 
    {
        AvatarEditado.instancia.colorpiel = new Color(0.4f, 0.25f, 0.15f);
        AplicarColor();
    }
    public void ColorVioleta() 
    {
        AvatarEditado.instancia.colorpiel = new Color(0.6f, 0.3f, 0.8f);
        AplicarColor();
    }
    public void ColorVerde() 
    {
        AvatarEditado.instancia.colorpiel = Color.green;
        AplicarColor();
    }
    public void ColorAzul()
    {
        AvatarEditado.instancia.colorpiel = Color.blue;
        AplicarColor();
    }

    void AplicarColor() 
    {
        if (Hombre.activeSelf) 
        {
            Hombre.GetComponent<Renderer>().material.color = AvatarEditado.instancia.colorpiel;
        }
    }

    //confirmar cambio
    public void Confirmar(string nombre) 
    {
        SceneManager.LoadScene(nombre);
    }
}
