using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PickUpObjects : MonoBehaviour
{
    public bool isCarrying;
    public Transform handPos;
    public bool kalpTopla, paraTopla, mamaTopla,paraTamam,mamaTamam;
    public Text collectText,pickText,storyText;
    public Barlar barlar;
    public GameObject cat;
    public AudioSource sfx;
    public AudioClip[] ac;
    void Start()
    {
        paraTopla = true;
        pickText.gameObject.SetActive(false);
        StartCoroutine(giris());
    }

    IEnumerator giris()
    {
        yield return new WaitForSeconds(4.5f);
        storyText.text = "Gather food or coin to feed the homeless.";
    }

    IEnumerator twodBaslat()
    {
        storyText.text = "Follow the path and go to pub";
        yield return new WaitForSeconds(0);


    }

    void Update()
    {
        if (isCarrying && Input.GetMouseButtonDown(1)) { StartCoroutine(Drop()); }
        if (paraTopla) { collectText.text = "Collect: Coin and Hotdog"; }
        if (kalpTopla) { collectText.text = "Collect: Heart"; }
        if (mamaTopla) { collectText.text = "Collect: Fish"; }

        if (isCarrying) { pickText.text = "Drop(RightClick)"; }
        if (!isCarrying) { pickText.text = "Pick(LeftClick)"; }

        if(barlar.yardim >= 100 && !paraTamam)
        {
            storyText.text = "Go to homeless to feed him";
        }
        if (barlar.kedi >= 100 && !mamaTamam)
        {
            storyText.text = "Find the cat and feed it";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Pickable")
        {
            pickText.gameObject.SetActive(false);
        }
    }


    IEnumerator kediBaslat()
    {
        storyText.text = "Then scared an animal and chased it from street to street all day.";
        yield return new WaitForSeconds(4);
        storyText.text = "the cat was so scared that it was hiding from the boy.";
        yield return new WaitForSeconds(4);
        storyText.text = "Gather fish to earn it's affection.";
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Pickable")
        {
            pickText.gameObject.SetActive(true);
        }

        if (other.tag == "Pickable" && !isCarrying && Input.GetMouseButtonDown(0))
        {
            Debug.Log("girdi");
            other.GetComponent<Rigidbody>().useGravity = false;
            other.GetComponent<Rigidbody>().isKinematic = true;
            other.transform.position = handPos.position;
            other.transform.parent = handPos;
            Debug.Log("basti");
            isCarrying = true;

        }

        if(other.tag == "gofish")
        {
            if (barlar.kedi >= 100)
            {
                Destroy(other.gameObject);
                StartCoroutine(twodBaslat());
                mamaTamam = true;
                sfx.PlayOneShot(ac[0], 1);
            }
        }
        if (other.tag == "gocoin")
        {
            if(barlar.yardim >= 100)
            {
                Destroy(other.gameObject);
                cat.SetActive(true);
                paraTamam = true;
                StartCoroutine(kediBaslat());
                sfx.PlayOneShot(ac[0], 1);
            }
        }
        if (other.tag == "kedi")
        {
            sfx.PlayOneShot(ac[1], 1);
            if (!mamaTopla && !paraTamam)
            {
                GameObject.Find("Canvas").GetComponent<Barlar>().yardim -= 20;
               
            }
            else
            {
                GameObject.Find("Canvas").GetComponent<Barlar>().kedi += 20;
            }
            Destroy(other.gameObject);
        }
        if (other.tag == "coin")
        {
            sfx.PlayOneShot(ac[1], 1);
            if (!paraTopla && !mamaTamam)
            {
                GameObject.Find("Canvas").GetComponent<Barlar>().kedi -= 20;
            }
            else
            {
                GameObject.Find("Canvas").GetComponent<Barlar>().yardim += 20;
            }
            Destroy(other.gameObject);
        }
        if (other.tag == "yemek" && !mamaTamam)
        {
            sfx.PlayOneShot(ac[1], 1);
            if (!paraTopla)
            {
                GameObject.Find("Canvas").GetComponent<Barlar>().kedi -= 20;
            }
            else
            {
                GameObject.Find("Canvas").GetComponent<Barlar>().yardim += 20;
            }
            Destroy(other.gameObject);
        }
    }


    IEnumerator Drop()
    {
        yield return new WaitForSeconds(0);
        handPos.transform.GetChild(0).GetComponent<Rigidbody>().useGravity = true;
        handPos.transform.GetChild(0).GetComponent<Rigidbody>().isKinematic = false;
        handPos.transform.GetChild(0).transform.parent = null;
        isCarrying = false;
    }
}
