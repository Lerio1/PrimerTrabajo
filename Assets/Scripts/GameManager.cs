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
    private void Awake()
    {
        gm = this;
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
        madera.valor += _cantidad;
    }

    public void SpawnearArbol()
    {
        Vector3 posicionDelOtroArbol = spawnPoint.position;
       // posicionDelOtroArbol.x += Random.Range(0, 0);

        GameObject elOtroArbolito = Instantiate(arboles.prefab, posicionDelOtroArbol, Quaternion.identity);
        elOtroArbolito.SetActive(true);

       // elOtroArbolito.transform.localScale = Vector3.one * Random.Range(.7f, 1.5f);

       // elOtroArbolito.GetComponent<Arbol>().ResetearHp();
       elOtroArbolito.transform.parent = parentArbol;
    }
}
