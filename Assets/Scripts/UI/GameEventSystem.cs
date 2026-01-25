using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventSystem : MonoBehaviour
{
    
    
    // Start is called before the first frame update
    public static GameEventSystem I;

    public void Init() 
    {

        //if (I == null)

            I = this;
           
        //if (I == null)

        //    I = this;
    }

    //private void Awake()
    //{
        
    //    if (I == null)

    //        I = this;
        
    //}
    public Action<Vector3,int> OnCoinCollected;
    public Action<Vector3> OnPlayerDead;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
