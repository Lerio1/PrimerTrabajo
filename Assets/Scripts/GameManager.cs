using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public UnityEvent onGameStart, onGameOver, onGameRestart;
    public static GameManager gm;

    public IntVariable madera;
    public LibreriaPrefab arboles;
    public Transform spawnPoint;
    public Transform parentArbol;
    public int initialValue;
    public GameObject[] arbolesPrefabs;
    public GameObject ardillaImage;
    public GameObject le�adorImage;
    public string Victory;

    public MoveBackground[] moveBackgrounds;

    private void Awake()
    {
        gm = this;
        {
            initialValue = madera.valor;
            madera.valor = 3;
        }
    }

    public void OnGameStart()
    {
        onGameStart.Invoke();
    }

    public void OnGameOver()
    {
        onGameOver.Invoke();
    }

    public void OnGameRestart()
    {
        onGameRestart.Invoke();
    }

    public void AgregarMadera(int _cantidad)
    {
        if (madera.valor < 5)
        {
            madera.valor += _cantidad;
        }
    }
    private void Update()
    {
        // Verificar si las im�genes se superponen
        RectTransform ardillaRect = ardillaImage.GetComponent<RectTransform>();
        RectTransform le�adorRect = le�adorImage.GetComponent<RectTransform>();
        if (RectTransformUtility.RectangleContainsScreenPoint(ardillaRect, le�adorRect.position))
        {
            // Cambiar la escena del juego
            SceneManager.LoadScene(Victory);
           // Debug.Log("Si funciona");
        }
    }

    public void SpawnearArbol()
    {
        Vector3 posicionDelOtroArbol = spawnPoint.position;

        // Elegir un �ndice de �rbol al azar
        int indiceAleatorio = Random.Range(0, arbolesPrefabs.Length);

        // Instanciar el �rbol seleccionado
        GameObject arbolElegido = Instantiate(arbolesPrefabs[indiceAleatorio], posicionDelOtroArbol, Quaternion.identity);
        arbolElegido.SetActive(true);
        arbolElegido.transform.parent = parentArbol;

        StartCoroutine(MoverArbolYFondo());
        // Mueve el icono del le�ador una distancia espec�fica
        GameObject.Find("IconoLe�ador").GetComponent<MoverLe�ador>().MoverLenador();
    }

    IEnumerator MoverArbolYFondo()
    {
        // Esperar 0.2 segundos antes de mover el �rbol
        yield return new WaitForSeconds(0.2f);

        // Mover el �rbol hacia la izquierda
        Vector3 direccion = new Vector3(-10f, 0f, 0f);
        parentArbol.transform.position += direccion;

        // Esperar 0.3 segundos antes de empezar a mover el fondo
        yield return new WaitForSeconds(0f);

        // Mover el fondo durante 0.5 segundos
        float tiempoMoverFondo = 0.5f;
        float tiempoTranscurrido = 0f;
        while (tiempoTranscurrido < tiempoMoverFondo)
        {
            foreach (MoveBackground mb in moveBackgrounds)
            {
                mb.MoverFondo();
            }
            tiempoTranscurrido += Time.deltaTime;
            yield return null;
        }
    }
}