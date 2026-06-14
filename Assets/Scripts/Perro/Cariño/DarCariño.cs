using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DarCariño : MonoBehaviour
{
    public Slider SliderMov, SliderProge;
    public float ZonaBuena = 0.15f, velo = 1f;
    public int IntentoMax = 6;
    public GameObject PanelPrueba;
    private float direccion = 1f;
    private bool activado = false;
    private int intentos = 0;
    private Cariño Activado = null;

    public void IniciarPrueba(Cariño c)
    {
        Activado = c;
        activado = true;
        intentos = 0;
        SliderMov.value = 0;
        SliderProge.value = 0;
        PanelPrueba.SetActive(true);
        
    }


    void Update()
    {
        if (!activado)
        {
            return;
        }

        SliderMov.value += direccion * velo * Time.deltaTime;

        if (SliderMov.value >= 1f)
        {
            SliderMov.value = 1f;
            direccion = -1f;
        }
        else if (SliderMov.value <= 0f)
        {
            SliderMov.value = 0f;
            direccion = 1f;
        }

        if (Input.GetMouseButtonDown(0))
        {
            float centro = 0.5f;
            if (SliderMov.value >= centro - ZonaBuena && SliderMov.value <= centro + ZonaBuena)
            {
                intentos++;
                SliderProge.value = (float)intentos / IntentoMax;
                Debug.Log("Carino exitoso");

                if (intentos >= IntentoMax)
                {
                    activado = false;
                    PanelPrueba.SetActive(false);
                    Activado.pruebaCariño();
                }
            }
            else
            {
                intentos = Mathf.Max(0, intentos - 1);
                SliderProge.value = (float)intentos / IntentoMax;
            }
        }
    }
}
