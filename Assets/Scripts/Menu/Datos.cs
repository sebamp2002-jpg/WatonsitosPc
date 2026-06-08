using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Datos : MonoBehaviour
{
    public static Datos instancia;
    public string genero = "";

    void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
