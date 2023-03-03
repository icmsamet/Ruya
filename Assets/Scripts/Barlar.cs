using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barlar : MonoBehaviour
{
    public Image kediBar, yardimBar, kalpBar;
    public float kedi = 20;
    public float yardim = 20;
    public float kalp = 20;


    void Start()
    {
        
    }

    void Update()
    {
        kediBar.fillAmount = kedi / 100;
        yardimBar.fillAmount = yardim / 100;
        kalpBar.fillAmount = kalp / 100;
    }
}
