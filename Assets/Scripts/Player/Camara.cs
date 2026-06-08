using UnityEngine;

public class Camara : MonoBehaviour
{
    private float Sensibilidad = 200;
    private float rotaHORI = 0;
    private float rotaVER = 0;

    
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * Sensibilidad * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * Sensibilidad * Time.deltaTime;

        rotaHORI += mouseX;
        rotaVER -= mouseY;

        rotaHORI = Mathf.Clamp(rotaHORI, -90, 90);
        rotaVER = Mathf.Clamp(rotaVER, -90, 90);

        
        transform.rotation = Quaternion.Euler(rotaVER, rotaHORI, 0);
        //transform.Rotate(Vector3.up * mouseX);
    }
}
