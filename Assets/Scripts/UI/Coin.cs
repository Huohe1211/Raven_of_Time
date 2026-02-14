using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    bool initialActiveState;
    private int coinValue = 1;
    public GameObject nextCoin;
    
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "raven") 
        {
            //[1]Raven body flashing.
            
                //[2]Change the value on the coin Pnl.
                int result = UIMgr.I.ui_PnlX.GetCoinValue()+coinValue;
            if (nextCoin != null)
            {
                nextCoin.SetActive(true);
            }
            if (GameEventSystem.I != null)
            {
                GameEventSystem.I.OnCoinCollected?.Invoke(
                    transform.position,
                    coinValue
                );
            }
            else
            {
                Debug.LogError("EventSystem.I is NULL!");
            }
            UIMgr.I.ui_PnlX.SetCoinValue(result);
            gameObject.SetActive(false);
            
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
