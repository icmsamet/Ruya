using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoDControl : MonoBehaviour
{
    public float speed;
    public float ziplamaGucu;
    Rigidbody2D rig;
    public int kacKereZiplayacak;
    //
    private int kacKereZipladi;
    [SerializeField]
    public Animator animator;
    public bool yerdeMi;
    public bool ziplayabilir;
    public float horizontalMove;
    public Barlar barlar;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

   
    void Update()
    {
        if (kacKereZipladi >= kacKereZiplayacak - 1) { ziplayabilir = false; }
        if (yerdeMi) { ziplayabilir = true; kacKereZipladi = 0; }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
        {
            Zipla();
        }
    }

    private void FixedUpdate()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");

        rig.velocity = new Vector2(horizontalMove * speed, rig.velocity.y);

        if (horizontalMove > 0) { animator.SetBool("iswalking", true); animator.SetBool("idle", false); gameObject.transform.localScale = new Vector3(-1, 1, 1); }
        if (horizontalMove < 0) { animator.SetBool("iswalking", true); animator.SetBool("idle", false); gameObject.transform.localScale = new Vector3(1, 1, 1); }
        if (horizontalMove == 0) { animator.SetBool("iswalking", false); animator.SetBool("idle", true); }
    }

    void Zipla()
    {
        if (kacKereZipladi <= 0 && yerdeMi == true && ziplayabilir == true)
        {
            rig.AddForce(Vector2.up * ziplamaGucu);

            kacKereZipladi += 1;
        }
        if (kacKereZipladi < kacKereZiplayacak - 1 && ziplayabilir == true && yerdeMi == false)
        {
            rig.AddForce(Vector2.up * ziplamaGucu);
            kacKereZipladi += 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "2ddead")
        {
            transform.position = new Vector3(7.704422f, 8.26830006f, 493.092407f);
        }
        if (collision.tag == "set3d")
        {
            GameObject.Find("Manager").GetComponent<Manaer>().setThreeD();
        }
        if (collision.tag == "kalp")
        {
            barlar.kalp += 20;
            Destroy(collision.gameObject);
        }
    }
}
