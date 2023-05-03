using UnityEngine;
using UnityEngine.SceneManagement;

public class ArdillaScript : MonoBehaviour
{
    [SerializeField] private float velocidad = 1f;
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private Vector2 limiteDerecho;
    public string GameOver;

    private void Start()
    {
        InvokeRepeating("MoverArdilla", 0f, 0.02f); // Llama a la función "MoverArdilla" cada 0.02 segundos
    }

    private void MoverArdilla()
    {
        // Mueve la ardilla hacia la derecha
        rectTransform.anchoredPosition += Vector2.right * velocidad;

        // Comprueba si la ardilla ha llegado al límite derecho de la barra de progreso
        if (rectTransform.anchoredPosition.x >= limiteDerecho.x)
        {
            // Detiene la repetición de la función InvokeRepeating
            CancelInvoke("MoverArdilla");
            SceneManager.LoadScene(GameOver);
        }
    }
}
