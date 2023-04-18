using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HachaPlayer : MonoBehaviour
{
              
    public Animator animator;          
           
    public bool golpear;


    private void Update()
    {

            Golpear();

    }

    void Golpear()
    {
        if (Input.GetButtonDown("Fire1"))
        {

            //if (hacha.hpHacha.valor > 1)                           
                animator.Play("GolpeMedio");
            //else
                //animator.Play("HachaRota");
        }
    }


}
