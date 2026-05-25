using UnityEngine;

public class Player : MonoBehaviour
{
    //Movimiento player
    private float Caminar = 10, Correr = 18, Rotacion = 40;
    public float Normal;
    private Rigidbody rb;
    public Transform player;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        movimiento();
    }


    void movimiento()
    {
        float Vertical = Input.GetAxis("Vertical");
        float Horizontal = Input.GetAxis("Horizontal");

        transform.Rotate(0, Horizontal * Rotacion * Time.deltaTime, 0);

        Vector3 mover = player.right * -Vertical; //+ player.forward * Horizontal

        if (Input.GetKey(KeyCode.LeftShift))
        {
            //Debug.Log("Correr");
            Normal = Correr;
        }
        else
        {
            //Debug.Log("caminar");
            Normal = Caminar;
        }
        rb.MovePosition(transform.position + mover * Normal * Time.deltaTime);
    }


}
