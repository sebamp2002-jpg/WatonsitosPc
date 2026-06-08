using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void CambiarEscena(string nombre) 
    {
        SceneManager.LoadScene(nombre);
    }

    public void Salida() 
    {
        Application.Quit();
    }
}
