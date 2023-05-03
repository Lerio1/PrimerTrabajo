using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ComprarHacha : MonoBehaviour
{
    public IntVariable playerWood;
    public GameManager gameManager;
    public HachaPlayer hachaPlayer;
    public int axeCost = 3;
    public Animator animator;
    public AudioSource audioSource;
    public GameObject primeraOpcion;
    public GameObject segundaOpcion;
    public GameObject terceraOpcion;
    public AudioClip wrongSound;
    public AudioClip register;

    public void Comprar()
    {
        if (hachaPlayer.hasAxe)
        {
            Debug.Log("Ya tienes un hacha");
            primeraOpcion.GetComponent<Animator>().Play("Awake");
            primeraOpcion.GetComponent<AudioSource>().PlayOneShot(wrongSound);

        }
        else if (playerWood.valor < axeCost)
        {
            Debug.Log("No tienes suficiente madera para comprar un hacha");
            // Aquí puedes hacer que se muestre un mensaje de error o que se llame a una función que muestre un mensaje de game over
            segundaOpcion.GetComponent<Animator>().Play("Awake");
            primeraOpcion.GetComponent<AudioSource>().PlayOneShot(wrongSound);
        }

        else
        {
            playerWood.valor -= axeCost;
            hachaPlayer.HachaComprada(); // Cambiar el estado del hacha del player
            animator.Play("NewIdle");
            Debug.Log("Has comprado un hacha");
            terceraOpcion.GetComponent<AudioSource>().PlayOneShot(register);
        }
    }

   // public void RomperHacha()
   // {
     //   hachaPlayer.HachaRota(); // Cambiar el estado del hacha del player
    //    Debug.Log("Tu hacha se ha roto");
   // }
}