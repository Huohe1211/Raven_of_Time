using DG.Tweening;
using UnityEngine;

public class BreakGround : MonoBehaviour
{
    public Sprite brokenSprite;

    private SpriteRenderer sr;
    private bool isBroken = false;

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
            Destroy(gameObject, 1f); 

        }
    }
}
