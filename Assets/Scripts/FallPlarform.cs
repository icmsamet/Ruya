using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallPlarform : MonoBehaviour
{
    private Vector3 lastPosition;
    public bool isPlaying,onGround;
    private void Start()
    {
        lastPosition = transform.position;
        isPlaying = false;
    }

    private void Update()
    {
        if (onGround)
        {
            transform.position = Vector3.MoveTowards(transform.position, lastPosition, .013f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && isPlaying == false)
        {
            StartCoroutine(Fall());
            isPlaying = true;
            Debug.Log("ustunde");
        }
    }

    IEnumerator Fall()
    {
        yield return new WaitForSeconds(3);
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().isKinematic = false;
        yield return new WaitForSeconds(2);
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().isKinematic = true;
        onGround = true;
        yield return new WaitForSeconds(4);
        isPlaying = false;
        onGround = false;
    }
}
