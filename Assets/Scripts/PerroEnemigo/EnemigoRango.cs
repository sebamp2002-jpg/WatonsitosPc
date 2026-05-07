using System.Numerics;
using UnityEngine;
using UnityEngine.AI;

public class EnemigoRango : MonoBehaviour
{
    public NavMeshAgent Enemigo;
    public float Velocidad;
    public bool Persiguiendo;
    public float Rango;
    public float Distancia;

    public Transform Objetivo;

    // PATRULLA
    public float RadioPatrulla = 10f;
    public float TiempoEspera = 3f;

    private UnityEngine.Vector3 PuntoPatrulla;
    private float TiempoActual;
    private bool TieneDestino = false;

    private void Update()
    {
        Distancia = UnityEngine.Vector3.Distance(Enemigo.transform.position, Objetivo.position);
        if (Distancia < Rango)
        {
            Persiguiendo = true;
        }
        else if (Distancia > Rango + 3)
        {
            Persiguiendo = false;
        }

        if (Persiguiendo == false)
        {
            Enemigo.speed = 0;

            // PATRULLA
            Enemigo.speed = Velocidad / 2;

            if (!TieneDestino)
            {
                GenerarPuntoAleatorio();
            }

            if (TieneDestino && !Enemigo.pathPending && Enemigo.remainingDistance < 1f)
            {
                TiempoActual += Time.deltaTime;

                if (TiempoActual >= TiempoEspera)
                {
                    TieneDestino = false;
                    TiempoActual = 0;
                }
            }
        }
        else if (Persiguiendo == true)
        {
            TieneDestino = false;
            Enemigo.speed = Velocidad;
            Enemigo.SetDestination(Objetivo.position);
        }
    }

    void GenerarPuntoAleatorio()
    {
        UnityEngine.Vector3 randomDirection = Random.insideUnitSphere * RadioPatrulla;
        randomDirection += transform.position;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDirection, out hit, RadioPatrulla, 1))
        {
            PuntoPatrulla = hit.position;
            TieneDestino = true;
            Enemigo.SetDestination(PuntoPatrulla);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(Enemigo.transform.position, Rango);
    }

}
