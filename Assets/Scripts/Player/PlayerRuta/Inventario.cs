using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{
    public GameObject PanelInventario;
    public MoverCuerda Cuerda;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            bool abierto = !PanelInventario.activeSelf;
            PanelInventario.SetActive(abierto);
            Time.timeScale = abierto ? 0f : 1f; //pausa el juego
        }
    }
}
