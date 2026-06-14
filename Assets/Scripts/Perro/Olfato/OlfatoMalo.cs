using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OlfatoMalo : MonoBehaviour
{
    private bool olfateando = false;
    private PerroRuta ruta;
    private RutaJugador Jugador;
    private Animator anim;
    private Transform mano;
    private CuerdaRuta cuerda;

    void Start()
    {
        Jugador = FindAnyObjectByType<RutaJugador>();
        cuerda = FindAnyObjectByType<CuerdaRuta>();
        mano = cuerda.Mano;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Perro") && !olfateando)
        {
            ruta = other.GetComponentInParent<PerroRuta>();
            if (ruta == null) ruta = other.GetComponent<PerroRuta>();
            if (ruta == null) return;

            anim = other.GetComponentInChildren<Animator>();

            ruta.agarrar();
            Jugador.SoltarCuerda();
            Jugador.agente.isStopped = true;
            Jugador.agente.velocity = Vector3.zero;
            Jugador.agente.ResetPath();
            olfateando = true;

            if (anim != null)
            {
                anim.SetBool("Caminando", false);
                anim.SetTrigger("Oler");
            }

            Debug.Log("Olfato malo");
        }
    }

    void Update()
    {
        if (!olfateando) return;

        if (DetectarEmpujon())
            Terminar();
    }

    bool DetectarEmpujon()
    {
        if (ruta == null || mano == null) return false;

        Vector3 dirPerro = ruta.transform.position - mano.position;
        float ladoPerro = dirPerro.x;
        float velocidadMano = Input.GetAxis("Mouse X");

        if (ladoPerro > 0 && velocidadMano < -2f)
        {
            Debug.Log("Empujon izquierda!");
            return true;
        }
        else if (ladoPerro < 0 && velocidadMano > 2f)
        {
            Debug.Log("Empujon derecha!");
            return true;
        }

        return false;
    }

    void Terminar()
    {
        if (ruta != null) ruta.Soltar();
        if (Jugador != null) Jugador.CuerdaSinVuelta();

        olfateando = false;

        if (anim != null) anim.SetBool("Caminando", true);

        GetComponent<Collider>().enabled = false;
        Debug.Log("Termino olfato malo");
    }
}
