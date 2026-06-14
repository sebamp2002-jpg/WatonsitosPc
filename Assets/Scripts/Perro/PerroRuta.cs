using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PerroRuta : MonoBehaviour
{
    public Transform[] puntos; //Las rutas que tomara
    public NavMeshAgent agente;
    public int Actual = 0;
    public bool EnRuta = true;
    //private Animator anim;


    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        //anim = GetComponent<Animator>();
        agente.isStopped = true;
        agente.updateRotation = false;
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

        //if(agente.hasPath && agente.velocity.magnitude < 0.1f) 
        //{
        //agente.isStopped = false;
        //agente.destination = puntos[Actual].position;
        //}

        if (!agente.pathPending && agente.remainingDistance < 0.5f)
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
        agente.velocity = Vector3.zero;
        agente.ResetPath();
        //anim.SetBool("Caminando",false);
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX |
                                            RigidbodyConstraints.FreezeRotationZ |
                                            RigidbodyConstraints.FreezePosition;
    }

    public void Soltar()
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX |
                                            RigidbodyConstraints.FreezeRotationZ;

        //Actual = 0;
        EnRuta = true;
        agente.isStopped = false;
        //MoverOtroPunto();

        agente.destination = puntos[Actual].position;
        //agente.ResetPath();
        //anim.SetBool("Caminando", true);
    }

    public void SoltarConDestino(Vector3 destino)
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX |
                                                RigidbodyConstraints.FreezeRotationZ;
        EnRuta = true;
        agente.isStopped = false;
        agente.destination = destino;
    }


}
