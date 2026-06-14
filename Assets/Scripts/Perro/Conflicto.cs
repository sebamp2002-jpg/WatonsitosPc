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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            cuerda.distanciaActual -= Resistencia;
            cuerda.distanciaActual = Mathf.Clamp(cuerda.distanciaActual, cuerda.DistMin, cuerda.DistMax);
        }

        float porcentaje = 1f -((cuerda.distanciaActual - cuerda.DistMin) / (cuerda.DistMax - cuerda.DistMin));
        porcentaje = Mathf.Clamp01(porcentaje);
        SliderResist.value = porcentaje * SliderResist.maxValue;


        if (SliderResist.value >= SliderResist.maxValue)
        {
            PerroGana();
        }

        if(cuerda.distanciaActual <= cuerda.DistMin + 0.5f) 
        {
            JugadorGana();
        }

        void PerroGana() 
        {
            activo = false;
            SliderResist.gameObject.SetActive(false);
            jugador.AgarrarCuerda();
        }
        void JugadorGana() 
        {
            activo = false;
            SliderResist.gameObject.SetActive(false);
            perro.Soltar();
            jugador.AgarrarCuerda();
            //GetComponent<Collider>().enabled = false;
        }
    }
}
