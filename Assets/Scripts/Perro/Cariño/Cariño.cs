using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cariño : MonoBehaviour
{
    public float Giro = 5f;
    public DarCariño prueba;
    private bool activo = false;
    private PerroRuta perro;
    private RutaJugador Player;
    private Animator anim;

    void Start()
    {
        Player = FindAnyObjectByType<RutaJugador>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Perro") && !activo)
        {
            perro = other.GetComponentInParent<PerroRuta>();
            if (perro == null) perro = other.GetComponent<PerroRuta>();
            if (perro == null) return;

            anim = other.GetComponentInChildren<Animator>();
            perro.agarrar();
            Player.SoltarCuerda();
            activo = true;

            StartCoroutine(SecuenciaCarino());
        }
    }

    IEnumerator SecuenciaCarino()
    {
        // gira 180 para mirarte
        Quaternion rotInicial = perro.transform.rotation;
        Quaternion rotFinal = Quaternion.Euler(0, perro.transform.eulerAngles.y + 180f, 0);
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * Giro;
            perro.transform.rotation = Quaternion.Slerp(rotInicial, rotFinal, t);
            yield return null;
        }

        prueba.IniciarPrueba(this);
    }

    public void pruebaCariño()
    {
        StartCoroutine(TerminarCarino());
    }

    IEnumerator TerminarCarino()
    {
        // gira 180 de vuelta
        Quaternion rotInicial = perro.transform.rotation;
        Quaternion rotFinal = Quaternion.Euler(0, perro.transform.eulerAngles.y + 180f, 0);
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * Giro;
            perro.transform.rotation = Quaternion.Slerp(rotInicial, rotFinal, t);
            yield return null;
        }

        if (anim != null) anim.SetBool("Caminando", true);
        perro.Soltar();
        Player.CuerdaSinVuelta();
        activo = false;
        GetComponent<Collider>().enabled = false;
    }
}
