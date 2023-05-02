using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Cinemachine;


public class Arbol2_V1 : MonoBehaviour
{
    public UnityEvent onHit, onDead, onCaida;
    public int dropValue;
    public Animator animator;
    public HachaPlayer hacha;

    public GameObject sprite1;
    public GameObject sprite2;
    public GameObject sprite3;
    public GameObject sprite4;







    void Hit()
    {
        onHit.Invoke();                             // por cada golpe se ejecuta este evento
    }

    void Muere()
    {

        onDead.Invoke();
    Invoke("SegundoIntento", 0.5f);
        sprite1.SetActive(false);
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



    public void SegundoIntento()
    {
 
            // Si ya se ha acertado el primer golpe, se elige aleatoriamente en qué casilla aparecerá el segundo sprite
            int randomIndex = Random.Range(0, 3);
            switch (randomIndex)
            {
                case 0:
                    // El segundo sprite aparecerá en la casilla 1
                    sprite2.SetActive(true);
                    break;
                case 1:
                    // El segundo sprite aparecerá en la casilla 2
                    sprite3.SetActive(true);
                    break;
                case 2:
                    // El segundo sprite aparecerá en la casilla 3
                    sprite4.SetActive(true);
                    break;
            }
    }
}
