using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockFall : MonoBehaviour
{
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private Rigidbody2D rb;

    public GameObject dustPrefab;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Camera.main.DOShakePosition(0.7f, 0.2f, 10, 0);
            // 撞地后销毁自己
            GameObject fx = Instantiate(dustPrefab, transform.position, Quaternion.identity);
            var ps = fx.GetComponent<ParticleSystem>();
            ps.Play();
            gameObject.SetActive(false);
        }
        
        
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
