using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Conflicto : MonoBehaviour
{
    public Transform Atraccion;
    //public float Distancia = 2f, VeloSlider = 10f;
    public Slider SliderResist;

    private bool activo = false, Usado = false;
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
            SliderResist.value = 0;
            SliderResist.gameObject.SetActive(true);
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
        //ve la distancia del jugador
        //float distancia = Vector3.Distance(jugador.transform.position, perro.transform.position);

        //float minReal = cuerda.DistMin - 1f;
        float porcentaje = 1 - ((cuerda.distanciaActual - cuerda.DistMin) / (cuerda.DistMax - cuerda.DistMin));
        porcentaje = Mathf.Clamp01(porcentaje);
        SliderResist.value = porcentaje * SliderResist.maxValue;

        //float distMax = cuerda.DistMax;
        //float distMin = cuerda.DistMin;

        //SliderResist.value = Mathf.InverseLerp(distMax, distMin, distancia) * SliderResist.maxValue;

        if (SliderResist.value >= SliderResist.maxValue)
        {
            activo = false;
            SliderResist.gameObject.SetActive(false);
            perro.Soltar();
            jugador.AgarrarCuerda();
        }
    }
}
