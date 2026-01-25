using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCoin : MonoBehaviour
{
    public GameObject pickupFXPrefab;

    private void OnEnable()
    {
        //Debug.Log("FXListener OnEnable");
        //if (GameEventSystem.I != null)
        //{
        //    GameEventSystem.I.OnCoinCollected += PlayFX;
        //    Debug.Log("FXListener subscribed");
        //}
       // else
        //{
         //  Debug.LogError("FXListener: EventSystem.I is NULL");
        //}
    }

    private void OnDisable()
    {
        if (GameEventSystem.I != null)
            GameEventSystem.I.OnCoinCollected -= PlayFX;
    }

    void PlayFX(Vector3 pos, int value)
    {
        Debug.Log("FX Listener received event!");
        GameObject fx = Instantiate(
            pickupFXPrefab,
            pos,
            Quaternion.identity
        );
        var ps = fx.GetComponent<ParticleSystem>();
        if (ps != null)
        {
            ps.Play();
            Debug.Log("FXListener subscribed");
        }
        Destroy(fx, 3f);
    }
    void Start()
    {
        if (GameEventSystem.I != null)
        {
            GameEventSystem.I.OnCoinCollected += PlayFX;
            Debug.Log("FXListener subscribed");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
