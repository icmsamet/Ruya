using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenBoxes : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Top") { GetComponent<MeshRenderer>().enabled = true; }
    }
}
