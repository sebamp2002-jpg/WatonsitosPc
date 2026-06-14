using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Conflicto : MonoBehaviour
{
    public Transform Atraccion;
    public float Fuerza = 1f, Resistencia = 0.5f;
    public int TironesNecesarios = 5;
    //public Slider SliderResist;

    private bool activo = false, Usado = false;
    private int tirones = 0;
    private PerroRuta perro;
    private NavMeshAgent MeshPerro;
    private RutaJugador jugador;
    private CuerdaRuta cuerda;


    void Start()
    {
        jugador = FindAnyObjectByType<RutaJugador>();
        cuerda = FindAnyObjectByType<CuerdaRuta>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Perro") && !Usado)
        {
            perro = other.GetComponent<PerroRuta>();
            MeshPerro = other.GetComponent<NavMeshAgent>();
            perro.agarrar(); 
            jugador.SoltarCuerda(); 
            activo = true;
            Usado = true;
            tirones = 0;
            //SliderResist.value = 0;
            //SliderResist.gameObject.SetActive(true);

            cuerda.distanciaActual = cuerda.DistMax;
            MeshPerro.isStopped = false;
            MeshPerro.destination = Atraccion.position;
        }
    }

    void Update()
    {
        if (!activo || perro == null) 
        {
            return;
        }

        cuerda.distanciaActual += Fuerza * Time.deltaTime;
        cuerda.distanciaActual = Mathf.Clamp(cuerda.distanciaActual, cuerda.DistMin, cuerda.DistMax);

        if (DetectarTiron())
        {
            //cuerda.distanciaActual -= Resistencia;
            //cuerda.distanciaActual = Mathf.Clamp(cuerda.distanciaActual, cuerda.DistMin, cuerda.DistMax);
            tirones++;
            if(tirones >= TironesNecesarios) 
            {
                JugadorGana();
            }
        }

        if(MeshPerro != null && !MeshPerro.pathPending && MeshPerro.remainingDistance < 0.5f) 
        {
            PerroGana();
        }
        //float porcentaje = 1f -((cuerda.distanciaActual - cuerda.DistMin) / (cuerda.DistMax - cuerda.DistMin));
        //porcentaje = Mathf.Clamp01(porcentaje);
        //SliderResist.value = porcentaje * SliderResist.maxValue;


        //if (SliderResist.value >= SliderResist.maxValue)
        //{
            //PerroGana();
        //}

        //if(cuerda.distanciaActual <= cuerda.DistMin + 0.5f) 
        //{
            //JugadorGana();
        //}

        bool DetectarTiron()
        {
            if (perro == null || cuerda.Mano == null) 
            {
                return false; 
            }

            Vector3 dirPerro = perro.transform.position - cuerda.Mano.position;
            float ladoPerro = dirPerro.x;
            float velocidadMano = Input.GetAxis("Mouse X");

            if (ladoPerro > 0 && velocidadMano < -2f)
            {
                Debug.Log("Tiron izquierda!");
                return true;
            }
            else if (ladoPerro < 0 && velocidadMano > 2f)
            {
                Debug.Log("Tiron derecha!");
                return true;
            }

            return false;
        }

        void PerroGana() 
        {
            activo = false;
            cuerda.distanciaActual = cuerda.DistMin;
            //SliderResist.gameObject.SetActive(false);
            jugador.AgarrarCuerda();
        }
        void JugadorGana() 
        {
            activo = false;
            //SliderResist.gameObject.SetActive(false);
            cuerda.distanciaActual = cuerda.DistMin;
            perro.Soltar();
            jugador.AgarrarCuerda();
            //GetComponent<Collider>().enabled = false;
        }
    }
}
