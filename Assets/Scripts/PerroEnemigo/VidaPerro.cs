using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VidaPerro : MonoBehaviour
{
    public int vida = 2;
    public string escenaPerder;

    public void RecibirDaño()
    {
        vida--;
        

        if (vida <= 0)
        {
            SceneManager.LoadScene(escenaPerder);
        }
    }
}
