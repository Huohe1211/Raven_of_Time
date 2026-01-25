using UnityEngine;
using System.Collections;

public class RavenFlashOnCoin : MonoBehaviour
{
    SpriteRenderer sr;
    Color originalColor;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;

        if (GameEventSystem.I == null)
        {
            Debug.LogError("EventSystem missing for RavenFlash");
            return;
        }

        GameEventSystem.I.OnCoinCollected += OnCoin;
    }

    void OnDestroy()
    {
        if (GameEventSystem.I != null)
            GameEventSystem.I.OnCoinCollected -= OnCoin;
    }

    void OnCoin(Vector3 pos, int value)
    {
        StartCoroutine(Flash());
    }

    IEnumerator Flash()
    {
        for (int i = 0; i < 2; i++)
        {
            sr.color = new Color(1, 1, 1, 0.3f);
            yield return new WaitForSeconds(0.08f);
            sr.color = Color.white;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
