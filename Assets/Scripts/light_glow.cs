using UnityEngine;
using UnityEngine.Rendering.Universal;

public class light_glow : MonoBehaviour
{
    public Light2D light2D;
    public float speed = 1f;
    public float minIntensity = 0.5f;
    public float maxIntensity = 1.2f;

    void Start()
    {
        light2D = GetComponent<Light2D>();
    }

    void Update()
    {
        
        if (light2D != null)
        {
            float t = Mathf.Pow((Mathf.Sin(Time.time * speed) + 1f) / 2f, 1.5f);
            light2D.intensity = Mathf.Lerp(minIntensity, maxIntensity, t);
            light2D.pointLightOuterRadius = Mathf.Lerp(0.8f, 1.1f, t);
        }
    }
}
