using UnityEngine;
using System.Collections;
using DG.Tweening;
public class RavenDeath : MonoBehaviour
{
    SpriteRenderer sr;
    Color originalColor;
    public float respawnDelay = 2f;

    Vector3 startPos;
    public GameObject deathFxPrefab;
    Rigidbody2D rb;
    bool isDead = false;
    public GameObject visualRoot;
    public GameObject pickupFXPrefab;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
        startPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
        
        GameEventSystem.I.OnPlayerDead += Die;
    }

    void OnDestroy()
    {
        GameEventSystem.I.OnPlayerDead -= Die;
    }

    void Die(Vector3 pos)
    {
        if (isDead) return;
        
        isDead = true;

        Debug.Log("Raven die");

        // 停止物理
        rb.velocity = Vector2.zero;
        rb.simulated = false;

        // 播死亡动画
        if (deathFxPrefab != null)
        {
            GameObject fx = Instantiate(deathFxPrefab, transform.position, Quaternion.identity);
            var ps = fx.GetComponent<ParticleSystem>();
            if (ps != null)
            {
                ps.Play();
            }
            Destroy(fx, 0.7f);
        }
        GameObject ffx = Instantiate(pickupFXPrefab, transform.position, Quaternion.identity);
        var pps = ffx.GetComponent<ParticleSystem>();
       
            pps.Play();
        
        // 禁用操作脚本（你自己的）

        GetComponent<RavenAction>().enabled = false;

        Invoke(nameof(HideVisual), 1f);
        Invoke(nameof(Respawn), respawnDelay);
        TimeBack tb = GetComponent<TimeBack>();
        if (tb != null)
        {
            tb.enabled = false;
            tb.ResetTimeBackAfter(20f);
            tb.ResetTimeBack();

        }
        StartCoroutine(Flash());
        IEnumerator Flash()
        {
            for (int i = 0; i < 5; i++)
            {
                sr.color = new Color(1, 1, 1, 0.3f);
                yield return new WaitForSeconds(0.08f);
                sr.color = Color.white;
                yield return new WaitForSeconds(0.05f);
            }
            
        }
        Camera.main.DOShakePosition(0.7f,new Vector3(0,0.13f,0),10,0);

    }
    
    void HideVisual()
    {
        visualRoot.SetActive(false);
    }
    void Respawn()
    {
        Debug.Log("Raven respawn");

        // 回到起点
        transform.position = startPos;

        // 恢复显示
        visualRoot.SetActive(true);

        // 恢复物理
        rb.simulated = true;

        // 恢复控制
        GetComponent<RavenAction>().enabled = true;

        isDead = false;
    }
}
