using UnityEngine;

public class Camara : MonoBehaviour
{
    private float Sensibilidad = 200;
    public Transform Player;
    private float rotaHORI = 10;
    private float rotaVER = 10;

    void Start()
    {
        //Cursor.lockstate = CursorLockMode.Locked;   
    }
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * Sensibilidad * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * Sensibilidad * Time.deltaTime;

        rotaHORI += mouseX;
        rotaVER -= mouseY;

        rotaVER = Mathf.Clamp(rotaVER, -90, 90);

        transform.localRotation = Quaternion.Euler(rotaVER, 0, 0);
        Player.rotation = Quaternion.Euler(0, rotaHORI, 0);
        //transform.Rotate(Vector3.up * mouseX);
    }
}
