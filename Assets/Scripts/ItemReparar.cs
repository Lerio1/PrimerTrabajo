using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemReparar : MonoBehaviour
{
    public int reparacion = 50;
    public AudioClip sonidoReparacion;

    private void OnTriggerEnter2D(Collider2D elOtroCollider)
    {

        if(elOtroCollider.CompareTag("Player"))
        {
            elOtroCollider.gameObject.GetComponent<Player>().hacha.RepararHacha(reparacion);
            
            AudioManager.manager.ReproducirSonidoFx(sonidoReparacion);

            Destroy(gameObject);
        }

    }
}
