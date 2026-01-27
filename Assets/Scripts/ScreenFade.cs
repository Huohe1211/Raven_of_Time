using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEditor.Search;

public class ScreenFade : MonoBehaviour
{
    public float fadeInTime = 0.3f;
    public float stayTime = 0.2f;
    public float fadeOutTime = 0.4f;

    Image img;
    public void Init()
    {
        Show();
    }
    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
    void Awake()
    {
        img = GetComponent<Image>();
        img.color = new Color(0, 0, 0, 0);
    }

    void Start()
    {
        Show();
        GameEventSystem.I.OnPlayerDead += PlayFade;
    }

    void OnDestroy()
    {
        if (GameEventSystem.I != null)
            GameEventSystem.I.OnPlayerDead -= PlayFade;
       
    }

    void PlayFade(Vector3 pos)
    {
        StopAllCoroutines();
        StartCoroutine(FadeRoutine());
    }

    IEnumerator FadeRoutine()
    {

        // ½¥ÈëºÚ
        yield return Fade(0f, 1f, fadeInTime);

        // Í£¶Ù
        yield return new WaitForSeconds(stayTime);

        // ½¥³ö
        yield return Fade(1f, 0f, fadeOutTime);
    }

    IEnumerator Fade(float from, float to, float time)
    {
        float t = 0f;
        while (t < time)
        {
            t += Time.deltaTime;
            float a = Mathf.Lerp(from, to, t / time);
            img.color = new Color(0, 0, 0, a);
            yield return null;
        }

        img.color = new Color(0, 0, 0, to);
    }
}
