using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RutaJugador : MonoBehaviour
{
    public Transform[] Puntos;
    private NavMeshAgent agente;
    private int Ahora = 0;

    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        agente.isStopped = false;
        MoverOtroPunto();
    }

    void Update()
    {
        if(!agente.pathPending && agente.remainingDistance < 0.5f) 
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

 // public void IniciarRuta()
 // {
 //     agente.isStopped = false;
 //     agente.destination = Puntos[Ahora].position;
 // }

}
