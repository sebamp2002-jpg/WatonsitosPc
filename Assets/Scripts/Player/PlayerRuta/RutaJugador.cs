using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RutaJugador : MonoBehaviour
{
    public Transform[] Puntos;
    public NavMeshAgent agente;
    public int Ahora = 0;
    private bool EnRuta = false;

    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        agente.isStopped = true;
        //MoverOtroPunto();
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX |
                                            RigidbodyConstraints.FreezeRotationZ |
                                            RigidbodyConstraints.FreezePosition;
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
        if (!agente.isOnNavMesh) 
        {
            return;
        }
        if(Puntos.Length == 0) 
        {
            return;
        }
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX |
                                            RigidbodyConstraints.FreezeRotationZ;

        EnRuta = true;
        agente.isStopped = false;

        if(Ahora > 0) 
        {
            Ahora--;
        }
        agente.destination = Puntos[Ahora].position;
        //MoverOtroPunto();

    }

    public void CuerdaSinVuelta() 
    {
        if (!agente.isOnNavMesh) 
        {
            return;
        }
        if (Puntos.Length == 0)
        {
            return;
        }
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX |
                                               RigidbodyConstraints.FreezeRotationZ;
        EnRuta = true;
        agente.isStopped = false;
        agente.destination = Puntos[Ahora].position;
    }

    public void SoltarCuerda() 
    {
        EnRuta = false;
        agente.isStopped = true;
        agente.velocity = Vector3.zero;
        agente.ResetPath();

        //Para que no rote cuando se detenga
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX |
                                            RigidbodyConstraints.FreezeRotationZ |
                                            RigidbodyConstraints.FreezePosition;
    }

    public void AgarrarCuerdaConDestino(Vector3 destino)
    {
        if (!agente.isOnNavMesh) return;

        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX |
                                                RigidbodyConstraints.FreezeRotationZ;
        EnRuta = true;
        agente.isStopped = false;
        agente.destination = destino;
    }



}
