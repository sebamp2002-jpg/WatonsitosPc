using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarPremio : MonoBehaviour
{
    private Ladrar Activado = null;


    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Activado = FindAnyObjectByType<Ladrar>();
            if(Activado != null) 
            {
                Activado.Darpremio();
            }
        }
    }
}
