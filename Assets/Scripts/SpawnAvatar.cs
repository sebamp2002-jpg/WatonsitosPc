using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAvatar : MonoBehaviour
{
    public GameObject Hombre;
    public GameObject Mujer;
    public GameObject Otro;

    void Start()
    {
        
        //Debug.Log("spawn");
        GameObject personaje;
        //Personaje
        if (AvatarEditado.instancia.avatar == "mujer") 
        {
            personaje = Instantiate(Mujer, transform.position, Quaternion.identity);
        }
        else if(AvatarEditado.instancia.avatar == "otro")
        {
            personaje = Instantiate(Otro, transform.position, Quaternion.identity);
        }
        else 
        {
            personaje = Instantiate(Hombre, transform.position, Quaternion.identity);
        }


        //camara
        //Camera.main.transform.SetParent(personaje.transform);
        //Camera.main.transform.localPosition = new Vector3(0, 2, -4);
        //Camera.main.transform.localRotation = Quaternion.Euler(15, 0, 0);
    }

}
