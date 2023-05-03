using UnityEngine.SceneManagement;
using UnityEngine;

public class CargarEscena : MonoBehaviour
{
    public string nombreDeLaEscenaACargar;

    public void CargarEscenaOnClick()
    {
        SceneManager.LoadScene(nombreDeLaEscenaACargar);
    }
}
