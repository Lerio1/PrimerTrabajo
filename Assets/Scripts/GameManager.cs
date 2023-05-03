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
    public GameObject leñadorImage;
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
        // Verificar si las imágenes se superponen
        RectTransform ardillaRect = ardillaImage.GetComponent<RectTransform>();
        RectTransform leñadorRect = leñadorImage.GetComponent<RectTransform>();
        if (RectTransformUtility.RectangleContainsScreenPoint(ardillaRect, leñadorRect.position))
        {
            // Cambiar la escena del juego
            SceneManager.LoadScene(Victory);
           // Debug.Log("Si funciona");
        }
    }

    public void SpawnearArbol()
    {
        Vector3 posicionDelOtroArbol = spawnPoint.position;

        // Elegir un índice de árbol al azar
        int indiceAleatorio = Random.Range(0, arbolesPrefabs.Length);

        // Instanciar el árbol seleccionado
        GameObject arbolElegido = Instantiate(arbolesPrefabs[indiceAleatorio], posicionDelOtroArbol, Quaternion.identity);
        arbolElegido.SetActive(true);
        arbolElegido.transform.parent = parentArbol;

        StartCoroutine(MoverArbolYFondo());
        // Mueve el icono del leñador una distancia específica
        GameObject.Find("IconoLeñador").GetComponent<MoverLeñador>().MoverLenador();
    }

    IEnumerator MoverArbolYFondo()
    {
        // Esperar 0.2 segundos antes de mover el árbol
        yield return new WaitForSeconds(0.2f);

        // Mover el árbol hacia la izquierda
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