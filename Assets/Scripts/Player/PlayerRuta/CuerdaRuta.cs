using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuerdaRuta : MonoBehaviour
{
    public float DistMax = 7, DistMin = 3, Velo = 3, RaycastDist = 8, distanciaActual;
    private bool DetectarPerro = false;
    private Transform Conectado = null;
    public Transform Mano;
    public LayerMask Layer;
    private LineRenderer cuerda;
    private RutaJugador rutaPlayer;

    void Start()
    {
        cuerda = gameObject.AddComponent<LineRenderer>();
        cuerda.startWidth = 0.05f;
        cuerda.endWidth = 0.05f;
        cuerda.positionCount = 2;
        cuerda.enabled = false;
        rutaPlayer = FindAnyObjectByType<RutaJugador>();

        
    }

    void Update()
    {
        if (Mano == null)
        {
            Debug.LogError("falta la mano");
            return;
        }
        RayCast();

        if (DetectarPerro && Conectado != null)
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            if (scroll != 0)
            {
                distanciaActual += scroll * Velo;
                distanciaActual = Mathf.Clamp(distanciaActual, DistMin, DistMax);
            }
            //Vector3 direccion = (Conectado.position - Mano.position).normalized;
            //Conectado.position = Mano.position + direccion * distanciaActual;
            PerroRuta ruta = Conectado.GetComponent<PerroRuta>();
            if (ruta != null)
            {
                Vector3 direccion = (Conectado.position - Mano.position).normalized;
                Conectado.position = Mano.position + direccion * distanciaActual;
            }
            cuerda.enabled = true;
            cuerda.SetPosition(0, Mano.position);
            cuerda.SetPosition(1, Conectado.position);
        }
        else
        {
            cuerda.enabled = false;
        }

    }

    void RayCast()
    {
        RaycastHit toca;
        Vector3 origen = transform.position;
        Vector3 direccion = transform.forward;

        if (Input.GetKeyDown(KeyCode.G))
        {
            if (!DetectarPerro)
            {
                if (Physics.Raycast(origen, direccion, out toca, RaycastDist, Layer))
                {
                    //Debug.DrawRay(transform.position, transform.forward * RaycastDist, Color.red);

                    DetectarPerro = true;
                    Conectado = toca.collider.transform;
                    distanciaActual = Mathf.Clamp(
                    Vector3.Distance(transform.position, Conectado.position),
                    DistMin, DistMax);
                    Conectado.GetComponent<PerroRuta>().Soltar();
                    rutaPlayer.AgarrarCuerda();

                    Animator anim = Conectado.GetComponentInChildren<Animator>();
                    if(anim != null) 
                    {
                        anim.SetBool("Caminando", true);
                    }
                }
                else
                {
                    Debug.Log("Nada");
                }
            }
            //else
            //{
                //if (Conectado != null)
                //{
                    //PerroRuta ruta = Conectado.GetComponent<PerroRuta>();
                    //if (!ruta.EnRuta)
                    //{
                        //ruta.agarrar();
                        //DetectarPerro = false;
                        //Conectado = null;
                        //rutaPlayer.SoltarCuerda();

                        //Animator anim = Conectado.GetComponentInChildren<Animator>();
                        //if (anim != null) 
                        //{
                            //anim.SetBool("Caminando", false);
                        //}

                    ///}
                    
                //}
            //}

        }
    }
}
