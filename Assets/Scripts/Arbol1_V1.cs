using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Cinemachine;


public class Arbol1_V1 : MonoBehaviour
{
    public UnityEvent onHit, onDead, onCaida;
    public int dropValue;
    public Animator animator;
    public HachaPlayer hacha;









    void Hit()
    {
        onHit.Invoke();                             // por cada golpe se ejecuta este evento
    }

    void Muere()
    {

        onDead.Invoke();
    }

    void Caer()
    {
        //SpawnearElOtroArbol();
        //agregar madera a inventario
        GameManager.gm.AgregarMadera(dropValue);
        onCaida.Invoke();                           // este evento se manda a llamar desde la animación de caida
        GameManager.gm.SpawnearArbol();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("hacha"))
        {
            Muere();
                                            
        }
        else
        {
            Hit();
        }
    }
    public void RomperHacha()
    {
        hacha.hasAxe = false; // Cambiar el valor del bool en el script "ComprarHacha"
        Debug.Log("Tu hacha se ha roto");
    }




}

    //void SpawnearElOtroArbol()
    // {
    // spawnear el otro arbol
    // obtener la posicion donde se va a spawnear
    // randomizar la posicion
    // randomizar la escala
    // randomizar su rotacion

    //   Vector3 posicionDelOtroArbol = transform.position;
    // posicionDelOtroArbol.x += Random.Range(0, 0);

    // GameObject elOtroArbolito = Instantiate(prefabArbol, posicionDelOtroArbol, Quaternion.identity);
    // elOtroArbolito.SetActive(true);

    //  elOtroArbolito.transform.localScale = Vector3.one * Random.Range(.7f, 1.5f);

    //elOtroArbolito.GetComponent<Arbol>().ResetearHp();

    //}