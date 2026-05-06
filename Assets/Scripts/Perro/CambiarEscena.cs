using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    public string NombreEscena;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Perro"))
        {
            SceneManager.LoadScene(NombreEscena);
        }
    }
}
