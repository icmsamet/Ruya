using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamera : MonoBehaviour
{
    public Transform hedef;
    public Vector3 konum;
    public float hiz;

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, hedef.position, hiz) + konum;
    }



}
