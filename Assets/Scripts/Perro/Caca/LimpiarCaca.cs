using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LimpiarCaca : MonoBehaviour
{
    public float distancia = 3f;
    public LayerMask Caca;
    public Slider slider;
    public float Sube = 1f;
    public float Baja = 4f;

    private GameObject cacaObj = null;

    void Update()
    {
        if(cacaObj != null && slider.value > 0) 
        {
            slider.value -= Baja * Time.deltaTime;
            if (slider.value < 0)
            {
                slider.value = 0;
            }
        }
        //if(Input.GetKeyDown(KeyCode.E)) 
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if(Physics.Raycast(transform.position, transform.forward,out hit,distancia, Caca)) 
            {
                Debug.Log("Toca");
                if (hit.collider.CompareTag("Caca")) 
                {
                    cacaObj = hit.collider.gameObject;
                    slider.gameObject.SetActive(true);
                    slider.value += Sube;

                    if (slider.value >= 100f)
                    {

                        FindAnyObjectByType<PerroCaca>().Limpiar();
                        Destroy(cacaObj);
                        slider.value = 0;
                        slider.gameObject.SetActive(false);
                        cacaObj = null;
                        //Debug.Log("Funciona");
                    }
                }
            }
            else 
            {
                Debug.Log("Nada");
                if(slider.value > 0) 
                {
                    slider.value -= Baja;
                }
            }
        }
    }

}
