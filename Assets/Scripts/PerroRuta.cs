using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PerroRuta : MonoBehaviour
{
    public Transform[] puntos; //Las rutas que tomara
    private NavMeshAgent agente;
    private int Actual = 0;
    private bool EnRuta = true;

    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        agente.isStopped = true;
        //MoverOtroPunto();
    }

    
    void Update()
    {
        if (!EnRuta) 
        {
            return;
        }

        if(!agente.pathPending && agente.remainingDistance < 0.5f) 
        {
            //Actual = (Actual + 1) % puntos.Length;
            MoverOtroPunto();
        }
    }

    void MoverOtroPunto() 
    {
        if (puntos.Length == 0) 
        { 
            return; 
        }
        agente.destination = puntos[Actual].position;
        Actual = (Actual + 1) % puntos.Length;
    }

    public void agarrar() 
    {
        EnRuta = false;
        agente.isStopped = true;
    }

    public void Soltar() 
    {
        Actual = 0;
        EnRuta = true;
        agente.isStopped = false;
        MoverOtroPunto();
    }
}
