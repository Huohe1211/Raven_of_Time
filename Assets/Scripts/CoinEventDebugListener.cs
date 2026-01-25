using UnityEngine;

public class CoinEventDebugListener : MonoBehaviour
{
    void Start()
    {
        Debug.Log("CoinEventDebugListener START");

        if (GameEventSystem.I == null)
        {
            Debug.LogError("EventSystem.I is NULL in listener");
            return;
        }

        GameEventSystem.I.OnCoinCollected += OnCoin;
        Debug.Log("CoinEventDebugListener SUBSCRIBED");
    }

    void OnDestroy()
    {
        if (GameEventSystem.I != null)
            GameEventSystem.I.OnCoinCollected -= OnCoin;
    }

    void OnCoin(Vector3 pos, int value)
    {
        Debug.Log("EVENT RECEIVED! value = " + value);
    }
}
