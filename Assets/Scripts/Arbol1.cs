using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Cinemachine;
using TMPro;

public class Arbol1 : MonoBehaviour
{
    public int hp;
    public UnityEvent onHit, onDead, onCaida;
    public TextMeshPro textoDaño;
    public int dropValue;

    public GameObject prefabArbol;



    public void ResetearHp()
    {
        hp = 1;
        // random opcional

    }

    public void RecibirDaño(int _daño)
    {

        MostrarTextoDaño(_daño);

        hp -= _daño;            //restar daño
        if (hp < 1)             // si no tengo hp ejecutar Muere sino ejecutar Hit
        {
            Muere();           
        } 
        else
        {
            Hit();
        }
    }

    void Hit()
    {
        onHit.Invoke();                             // por cada golpe se ejecuta este evento
    }

    void Muere()
    {
        onDead.Invoke();                            // cuando se queda sin hp se ejecuta este evento
    }

    void Caida()
    {
        SpawnearElOtroArbol();
        //agregar madera a inventario
        GameManager.gm.AgregarMadera(dropValue);
        onCaida.Invoke();                           // este evento se manda a llamar desde la animación de caida
    }

    void MostrarTextoDaño(int cantidad)
    {
        textoDaño.gameObject.SetActive(false);      // apagar texto para que se resetee la animación
        textoDaño.text = cantidad.ToString();       // actualizar la cantidad de daño en el texto
        textoDaño.gameObject.SetActive(true);       // prender el texto para que muestre cuanto se le quito
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("hacha"))
        {

            int daño = collision.GetComponent<Hacha>().dañoHacha.valor;     //obtiene el daño del hacha
            collision.GetComponent<Hacha>().Golpeo();                       // ejecuta la funcion Golpeo dentro del hacha
            RecibirDaño(daño);                                              // Aplica daño al arbol
        }
    }


    void SpawnearElOtroArbol()
    {
        // spawnear el otro arbol
        // obtener la posicion donde se va a spawnear
        // randomizar la posicion
        // randomizar la escala
        // randomizar su rotacion

        Vector3 posicionDelOtroArbol = transform.position;
        posicionDelOtroArbol.x += Random.Range(3 , 8);

        GameObject elOtroArbolito =  Instantiate(prefabArbol, posicionDelOtroArbol, Quaternion.identity);
        elOtroArbolito.SetActive(true);

        elOtroArbolito.transform.localScale = Vector3.one * Random.Range(.7f, 1.5f);

        elOtroArbolito.GetComponent<Arbol>().ResetearHp();

    }
}
