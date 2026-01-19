using UnityEngine;

public class CoinEventDebugListener : MonoBehaviour
{
    void Start()
    {
        Debug.Log("CoinEventDebugListener START");

        if (EventSystem.I == null)
        {
            Debug.LogError("EventSystem.I is NULL in listener");
            return;
        }

        EventSystem.I.OnCoinCollected += OnCoin;
        Debug.Log("CoinEventDebugListener SUBSCRIBED");
    }

    void OnDestroy()
    {
        if (EventSystem.I != null)
            EventSystem.I.OnCoinCollected -= OnCoin;
    }

    void OnCoin(Vector3 pos, int value)
    {
        Debug.Log("EVENT RECEIVED! value = " + value);
    }
}
