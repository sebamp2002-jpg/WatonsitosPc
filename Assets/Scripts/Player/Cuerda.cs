using JetBrains.Annotations;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Cuerda : MonoBehaviour
{
    public float DistMax = 6, DistMin = 2, Velo = 3, RaycastDist = 5;
    private bool DetectarPerro = false;
    private Transform Conectado = null;
    public Transform Mano;
    private float distanciaActual;
    public LayerMask Layer;
    private LineRenderer cuerda;

    private void Start()
    {
        cuerda = gameObject.AddComponent<LineRenderer>();
        cuerda.startWidth = 0.05f;
        cuerda.endWidth = 0.05f;
        cuerda.positionCount = 2;
        cuerda.enabled = false;
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
            Vector3 direccion = (Conectado.position - Mano.position).normalized;
            Conectado.position = Mano.position + direccion * distanciaActual;

            cuerda.enabled = true;
            cuerda.SetPosition(0, Mano.position);
            cuerda.SetPosition(1, Conectado.position);
        }else 
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


                    DetectarPerro = true;
                    Conectado = toca.collider.transform;
                    distanciaActual = Mathf.Clamp(
                    Vector3.Distance(transform.position, Conectado.position),
                    DistMin, DistMax);
                    Conectado.GetComponent<PerroRuta>().Soltar(); //Codigo PerroRuta
                }                                                      //Debug.Log("Perro agarrado!");

                else
                { 
                    Conectado.GetComponent<PerroRuta>().agarrar(); //Codigo PerroRuta
                    DetectarPerro = false;
                    Conectado = null;
                    //Debug.Log("Perro suelto!");
                    
                }    
            }
        }
    }

    //adelante
    //if (scroll > 0f) 
    //{
    // Vector3 escala = transform.localScale;
    // escala.z = Mathf.Clamp(escala.z + Velo * Time.deltaTime, DistMin, DistMax);
    // transform.localScale = escala;
    //}

    //atras
    //if (scroll < 0f)
    //{
    //Vector3 escala = transform.localScale;
    //escala.z = Mathf.Clamp(escala.z - Velo * Time.deltaTime, DistMin, DistMax);
    //transform.localScale = escala;
    //}
}
