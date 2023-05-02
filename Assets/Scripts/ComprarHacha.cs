using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComprarHacha : MonoBehaviour
{
    public IntVariable playerWood;
    public GameManager gameManager;
    public HachaPlayer hachaPlayer;
    public int axeCost = 3;
    public Animator animator;

    public void Comprar()
    {
        if (hachaPlayer.hasAxe)
        {
            Debug.Log("Ya tienes un hacha");
        }
        else if (playerWood.valor < axeCost)
        {
            Debug.Log("No tienes suficiente madera para comprar un hacha");
            // Aquí puedes hacer que se muestre un mensaje de error o que se llame a una función que muestre un mensaje de game over
        }
        else
        {
            playerWood.valor -= axeCost;
            hachaPlayer.HachaComprada(); // Cambiar el estado del hacha del player
            animator.Play("NewIdle");
            Debug.Log("Has comprado un hacha");
        }
    }

    public void RomperHacha()
    {
        hachaPlayer.HachaRota(); // Cambiar el estado del hacha del player
        Debug.Log("Tu hacha se ha roto");
    }
}