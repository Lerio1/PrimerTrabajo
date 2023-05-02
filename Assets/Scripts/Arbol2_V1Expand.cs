using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Arbol2_V1Expand : MonoBehaviour
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

    //void Caer()
    //{
      //  GameManager.gm.SpawnearArbol();
        //SpawnearElOtroArbol();
        //agregar madera a inventario
        // GameManager.gm.AgregarMadera(dropValue);
        //onCaida.Invoke();                           // este evento se manda a llamar desde la animación de caida

//    }


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