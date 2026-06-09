using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerroCaca : MonoBehaviour
{
    public GameObject Caca, Imagen;
    private bool Hizo = false;
    private PerroRuta perro;
    private RutaJugador Player;
    public Transform Spawn;

    void Start()
    {
        Player = FindAnyObjectByType<RutaJugador>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Perro") && !Hizo) 
        {
            perro = other.GetComponent<PerroRuta>();
            perro.agarrar();
            Player.SoltarCuerda();
            Instantiate(Caca, new Vector3(Spawn.position.x, Spawn.position.y + 1f, Spawn.position.z), Quaternion.identity);
            Hizo = true;
            Imagen.SetActive(true);
        }
    }

    public void Limpiar() 
    {
        if (Hizo) 
        {
            Imagen.SetActive(false);
            Hizo = false;
            perro.Soltar();
            Player.AgarrarCuerda();
        }
    }
}
