using DG.Tweening;
using UnityEngine;

public class reset: MonoBehaviour
{
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private Rigidbody2D rb;
    public Elevator elevator;
    bool initialActiveState;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        initialPosition = transform.position;
        initialRotation = transform.rotation;
        initialActiveState = gameObject.activeSelf;
         Debug.Log(gameObject.name + " ³õÊ¼×´Ì¬¼ÇÂ¼ = " + initialActiveState);
    }

    public void ResetState()
    {
        gameObject.SetActive(true);

        DOVirtual.DelayedCall(1.4f, () =>
        {
            transform.position = initialPosition;
            transform.rotation = initialRotation;
            gameObject.SetActive(initialActiveState);
            if (rb != null)
            {
                rb.velocity = Vector2.zero;
                rb.angularVelocity = 0f;
            }
        });


    }
}
