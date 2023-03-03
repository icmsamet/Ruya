using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YerdeMiCheck : MonoBehaviour
{
    Control control;
    public ParticleSystem efekt;

    private void Start()
    {
        control = GameObject.Find("Karakter").GetComponent<Control>();
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Zemin" || collision.tag == "Pickable")
        {
            control.yerdeMi = true;
        }

        if(collision.tag == "Zemin")
        {
            efekt.Play();

        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "Zemin" || collision.tag == "Pickable")
        {
            control.yerdeMi = false;
        }
    }
}
