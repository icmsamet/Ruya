using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoDCheckGround : MonoBehaviour
{
    TwoDControl control;

    private void Start()
    {
        control = GameObject.Find("2DKarakter").GetComponent<TwoDControl>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Zemin" || collision.tag == "Pickable")
        {
            control.yerdeMi = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Zemin" || collision.tag == "Pickable")
        {
            control.yerdeMi = false;
        }
    }
}
