using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RutaJugador : MonoBehaviour
{
    public Transform[] Puntos;
    private NavMeshAgent agente;
    private int Ahora = 0;
    private bool EnRuta = false;

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
        if (!agente.pathPending && agente.remainingDistance < 0.5f) 
        {
            MoverOtroPunto();
        }
        
    }

    void MoverOtroPunto()
    {
        if (Puntos.Length == 0)
        {
            return;
        }
        agente.destination = Puntos[Ahora].position;
        Ahora = (Ahora + 1) % Puntos.Length;
    }
    //nuevo

    public void AgarrarCuerda() 
    {
        EnRuta = true;
        agente.isStopped = false;
        MoverOtroPunto();
    }

    public void SoltarCuerda() 
    {
        EnRuta = false;
        agente.isStopped = true;
    }
    


}
