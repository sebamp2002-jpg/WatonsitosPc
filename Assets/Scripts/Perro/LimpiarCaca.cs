using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LimpiarCaca : MonoBehaviour
{
    public Slider slider;
    public float velocidad = 50f;
    private bool cerca = false;
    private PerroCaca Ahora = null;
    private GameObject cacaObj = null;

    void Update()
    {
        if(cerca && Ahora != null) 
        {
            if (Input.GetKey(KeyCode.E)) 
            {
                slider.gameObject.SetActive(true);
                slider.value += velocidad * Time.deltaTime;

                if(slider.value >= slider.maxValue) 
                {
                    Ahora.Limpiar();
                    if(cacaObj != null) 
                    {
                        Destroy(cacaObj);
                    }
                    slider.value = 0;
                    slider.gameObject.SetActive(false);
                    cerca = false;
                    Ahora = null;
                }
            }
            else 
            {
                slider.value = 0;
                slider.gameObject.SetActive(false);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Caca")) 
        {
            cacaObj = other.gameObject;
            Ahora = other.GetComponent<PerroCaca>();
            if (Ahora != null)
            {
                cerca = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Caca")) 
        {
            cerca = false;
            Ahora = null;
            cacaObj = null;
            slider.value = 0;
            slider.gameObject.SetActive(false);
        }
    }
}
