using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{

     void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.gameObject.name);
        GameEventSystem.I.OnPlayerDead?.Invoke(collision.transform.position);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
