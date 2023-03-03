using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Control : MonoBehaviour
{
    [Header("Karakter Özellikleri")]
    [Range(0, 10)]

    public float hiz;
    public float ziplamaGucu;
    public int kacKereZiplayacak;
    //
    private Rigidbody rig;
    private int kacKereZipladi;
    [SerializeField]    
    public Animator animator,gecisAnim;
    public bool yerdeMi;
    public bool ziplayabilir;
    public float horizontalMove;


    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        if (Input.GetKey(KeyCode.W)) {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, 1.2996f);
            Walk(); 
        }
        else
        {
            animator.SetBool("run", false);
        }

        if (Input.GetKeyDown(KeyCode.Space)) { Zipla(); }


        if (kacKereZipladi >= kacKereZiplayacak -1) { ziplayabilir = false; }
        if (yerdeMi) { ziplayabilir = true; kacKereZipladi = 0;}

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Game");
        }
    }

    void Zipla()
    {
        if (kacKereZipladi <= 0 && yerdeMi == true && ziplayabilir == true)
        {
            rig.AddForce(Vector2.up * ziplamaGucu);

            kacKereZipladi += 1;
        }
        if (kacKereZipladi < kacKereZiplayacak -1 && ziplayabilir == true && yerdeMi == false)
        {
            rig.AddForce(Vector2.up * ziplamaGucu);
            kacKereZipladi += 1;
        }
    }
    void Walk()
    {
        animator.SetBool("run", true);
        if (horizontalMove > 0) { transform.Rotate(0, hiz*4, 0); }
        if (horizontalMove < 0) { transform.Rotate(0, hiz*-4, 0); }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "set2d")
        {
            GameObject.Find("Manager").GetComponent<Manaer>().SetTwoD();
        }
        if (other.tag == "zipzip")
        {
            rig.AddForce(Vector3.up * 500);
        }
        if (other.tag == "kanal")
        {
            SceneManager.LoadScene("Game");        
        }


    }
    

    

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "su")
        {
            rig.AddForce(Vector2.right * 75);
        }
    }
}
