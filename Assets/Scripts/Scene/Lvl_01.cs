using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Lvl_01 : MonoBehaviour
{
    public GameObject coin_00;
    public GameObject coin_01;
    public GameObject coin_02;
    public RavenDeath ravendeath;
    public void Init() 
    {
        Hide();


    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ravendeath.isDead==true)
        {
            coin_00.SetActive(true);
            coin_01.SetActive(false);
            coin_02.SetActive(false);

        }
    }
}
