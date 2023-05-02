using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RomperHacha : MonoBehaviour
{
    public Animator animator;
    public HachaPlayer hacha;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Romper"))
        {
            HachaRota();
            animator.Play("HachaRota");

        }
    }

    public void HachaRota()
    {
        hacha.hasAxe = false;
    }
}
