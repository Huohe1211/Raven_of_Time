using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystem : MonoBehaviour
{
    
    
    // Start is called before the first frame update
    public static EventSystem I;
    
    private void Awake()
    {
        if (I == null)
            I = this;
        else
            Destroy(gameObject);
    }
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
