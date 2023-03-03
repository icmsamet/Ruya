using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Rendering;

public class Manaer : MonoBehaviour
{

    public GameObject ikiD, ucD,twoDGame;
    public PostProcessVolume volume;
    public Vignette vig = null;
    public GameObject go2d;
    public Barlar obje;
    public PickUpObjects pickup;
    public Text storyText;
    void Start()
    {
        volume.profile.TryGetSettings(out vig);
        
    }

    void Update()
    {
    }

    public void SetTwoD()
    {
        if(obje.yardim >=100 && obje.kedi >=100)
        {
            ucD.SetActive(false);
            ikiD.SetActive(true);
            twoDGame.SetActive(true);
            Camera.main.GetComponent<Kamera>().hedef = ikiD.transform;
            Camera.main.GetComponent<Kamera>().konum = new Vector3(.6f, .4f, -2f);
            Camera.main.transform.rotation = Quaternion.Euler(16f, -20.55f, 0);
            GameObject.Find("isik").transform.rotation = Quaternion.Euler(120, -30, 0);
            vig.intensity.value = 1f;
            pickup.kalpTopla = true;
            pickup.paraTopla = false;
            pickup.mamaTopla = false;
            pickup.gameObject.SetActive(false);
            storyText.text = "He pushed everyone around him and was lonely. This made him very sad. Collect hearts to love himself.";
        }
        else
        {
            Debug.Log("tüm barları doldurmalısın!!");
        }

     
    }

    public void setThreeD()
    {
        ucD.SetActive(true);
        ikiD.SetActive(false);
        twoDGame.SetActive(false);
        Camera.main.GetComponent<Kamera>().hedef = ucD.transform;
        Camera.main.GetComponent<Kamera>().konum = new Vector3(.6f,.55f,-.4f);
        Camera.main.transform.rotation = Quaternion.Euler(15.3f, -53.2f, 0);
        GameObject.Find("isik").transform.rotation = Quaternion.Euler(50, -30, 0);
        vig.intensity.value = .13f;
        Destroy(go2d);
    }
}
