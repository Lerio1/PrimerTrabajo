using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
    private void Awake()
    {
        gm = this;
        {
            initialValue = madera.valor;
            madera.valor = 5;
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

    IEnumerator MoverDespuesDeEspera(float espera, Vector3 direccion)
    {
        yield return new WaitForSeconds(espera);
        parentArbol.transform.position += direccion;
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
        StartCoroutine(MoverDespuesDeEspera(0.2f, new Vector3(-10f, 0f, 0f)));
    }
}
