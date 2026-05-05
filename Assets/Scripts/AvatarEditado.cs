using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarEditado : MonoBehaviour
{
    public static AvatarEditado instancia;
    public string avatar = "hombre";
    public Color colorpiel = Color.white;

    private void Awake()
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
