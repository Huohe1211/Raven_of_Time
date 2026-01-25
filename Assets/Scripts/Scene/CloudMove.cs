using UnityEngine;

public class CloudMove : MonoBehaviour
{
    public float speed = 0.5f;
    public float resetX = -12f;
    public float startX = 12f;

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x < resetX)
        {
            float randomY = Random.Range(2f, 6f);
            transform.position = new Vector3(startX, randomY, transform.position.z);
        }
    }
}