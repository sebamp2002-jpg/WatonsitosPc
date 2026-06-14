using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamientoCuerda : MonoBehaviour
{
    public float TiempoAgitar = 4f, TiempoMirar = 2f, VelocidadGiro = 5f, sensibilidad = 0.06f;
    private float tiempo = 0f;
    private Vector3 posAnteriorMano;
    private bool agitando = false, Secuencia = false;
    private CuerdaRuta cuerda;
    private RutaJugador jugador;
    private Transform mano;

    void Start()
    {
        cuerda = GetComponent<CuerdaRuta>();
        jugador = FindAnyObjectByType<RutaJugador>();
        mano = cuerda.Mano;
        posAnteriorMano = mano.position;
    }


    void Update()
    {
        if (Secuencia)
        {
            return;
        }
        if (cuerda.Conect() == null)
        {
            return;
        }
        
        float movimiento = Vector3.Distance(mano.position, posAnteriorMano);
        posAnteriorMano = mano.position;

        if (movimiento > sensibilidad) 
        {
            tiempo += Time.deltaTime;
            if (tiempo >= TiempoAgitar)
            {
                tiempo = 0f;
                StartCoroutine(SecuenciaVuelta());
            }
        }
        else
        {
            tiempo = Mathf.Max(0, tiempo - Time.deltaTime);
        }
    }

    IEnumerator SecuenciaVuelta()
    {
        Secuencia = true;

        Transform perroTransform = cuerda.Conect();
        PerroRuta perro = perroTransform.GetComponent<PerroRuta>();

        Vector3 destinoPerro = perro.agente.destination;
        Vector3 destinoJugador = jugador.agente.destination;

        perro.agarrar();
        jugador.SoltarCuerda();

        Quaternion rotacionInicial = perroTransform.rotation;
        Quaternion rotacionFinal = Quaternion.Euler(0, perroTransform.eulerAngles.y + 180f, 0);
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * VelocidadGiro;
            perroTransform.rotation = Quaternion.Slerp(rotacionInicial, rotacionFinal, t);
            yield return null;
        }

        yield return new WaitForSeconds(TiempoMirar);

        rotacionInicial = perroTransform.rotation;
        rotacionFinal = Quaternion.Euler(0, perroTransform.eulerAngles.y + 180f, 0);
        t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * VelocidadGiro;
            perroTransform.rotation = Quaternion.Slerp(rotacionInicial, rotacionFinal, t);
            yield return null;
        }

        perro.SoltarConDestino(destinoPerro);
        jugador.AgarrarCuerdaConDestino(destinoJugador);

        Secuencia = false;
    }
}
