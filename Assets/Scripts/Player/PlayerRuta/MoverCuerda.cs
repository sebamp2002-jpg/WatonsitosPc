using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverCuerda : MonoBehaviour
{
    public float Distancia = 4f;    
    public float LimiteX = 2f;     
    public float LimiteY = 1.5f;   
    public UnityEngine.Camera cam;

    void Update()
    {
       
        float mouseX = (Input.mousePosition.x / Screen.width) * 2f - 1f;
        float mouseY = (Input.mousePosition.y / Screen.height) * 2f - 1f;

       
        Vector3 centro = cam.transform.position + cam.transform.forward * Distancia;
        Vector3 derecha = cam.transform.right * mouseX * LimiteX;
        Vector3 arriba = cam.transform.up * mouseY * LimiteY;

        transform.position = centro + derecha + arriba;
    }
}
