using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HachaPlayer : MonoBehaviour
{
    public Animator animator;
    public ComprarHacha comprarHacha;

    public bool hasAxe = true;

    private void Update()
    {
        if (hasAxe)
        {
            Golpear();
            Golpear2();
            Golpear3();
        }
        else
        {

            // Desactivar las funciones de golpe
            // Mostrar el sprite de "comprar hacha"
        }
    }

    void Golpear()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            animator.Play("GolpeMedio");
        }
    }

    void Golpear2()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            animator.Play("GolpeAlto");
        }
    }

    void Golpear3()
    {
        if (Input.GetButtonDown("Fire3"))
        {
            animator.Play("GolpeBajo");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Romper"))
        {
            HachaRota();
            animator.Play("HachaRota");

        }
    }

    // Este método se llama cuando se rompe el hacha
    public void HachaRota()
    {
        hasAxe = false;
    }

    // Este método se llama cuando se compra un hacha
    public void HachaComprada()
    {
        hasAxe = true;
    }
}