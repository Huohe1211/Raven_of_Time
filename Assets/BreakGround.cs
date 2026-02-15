using DG.Tweening;
using UnityEngine;

public class BreakGround : MonoBehaviour
{
    public Sprite brokenSprite;
    public Sprite brokenSprite0;
    private SpriteRenderer sr;
    private bool isBroken = false;
    public RavenDeath ravenDeath;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Rock") && !isBroken)
        {
            isBroken = true;
            sr.sprite = brokenSprite;
            Camera.main.DOShakePosition(0.7f, 0.2f, 10, 0);
            // 如果要彻底消失：
            DOVirtual.DelayedCall(2f, () =>
            {
                gameObject.SetActive(false);
            });

        }
    }
}
