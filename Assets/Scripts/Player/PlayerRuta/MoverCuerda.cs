using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverCuerda : MonoBehaviour
{
    public float Distancia = 2f;
    public float LimiteX = 2f, LimiteY = 1f;
    //public float BorderX = 0.5f, BorderY = 0.3f;
    public UnityEngine.Camera cam;
    public RectTransform Panel;

    void Update()
    {
        if(Time.timeScale == 0) 
        {
            return;
        }

        Vector3[] esquinas = new Vector3[4];
        Panel.GetWorldCorners(esquinas);
       
        float minX = esquinas[0].x;
        float maxX = esquinas[2].x;
        float minY = esquinas[0].y;
        float maxY = esquinas[2].y;
        
        Vector3 mousePantalla = Input.mousePosition;
        mousePantalla.x = Mathf.Clamp(mousePantalla.x, minX, maxX);
        mousePantalla.y = Mathf.Clamp(mousePantalla.y, minY, maxY);

        float mouseX = (mousePantalla.x / Screen.width) * 2f - 1f;
        float mouseY = (mousePantalla.y / Screen.height) * 2f - 1f;

        Vector3 centro = cam.transform.position + cam.transform.forward * Distancia;
        Vector3 derecha = cam.transform.right * mouseX * LimiteX;
        Vector3 arriba = cam.transform.up * mouseY * LimiteY;

        transform.position = centro + derecha + arriba;
    }
}
