using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cicek : MonoBehaviour
{
    bool icinde;
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.tag == "Player")
        {
            if(icinde == false)
            {
                GetComponent<Animator>().SetBool("sallaniyor", true);
                icinde = true;
                Invoke("kapa", 1);
            }
           
        } 
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        icinde = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Invoke("kapa", 1);
        icinde = false;
    }

    void kapa()
    {
        GetComponent<Animator>().SetBool("sallaniyor", false);

    }
}
