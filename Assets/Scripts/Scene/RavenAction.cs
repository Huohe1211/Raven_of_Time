using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class RavenAction : MonoBehaviour
{
    public float ravenMoveSpeed;
    public Rigidbody2D ravenRB;
    public Collider2D ravenColl;
    public float ravenJumpSpeed;
    public Transform foot;
    public bool grounded;
    public LayerMask ground;
    
    // Start is called before the first frame update
    void Start()
    {
        ravenColl =GetComponent<Collider2D>();
        ravenRB=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        playerMove();
        playerJump();
        grounded = Physics2D.OverlapCircle(foot.position,0.1f,ground);
    }
    void playerMove()
    {
        float horizontalNum = Input.GetAxis("Horizontal");
        double faceNum= Input.GetAxisRaw("Horizontal");
        ravenRB.velocity = new Vector2(ravenMoveSpeed * horizontalNum,ravenRB.velocity.y);
        if (faceNum!=0)
        {
            transform.localScale = new Vector3((float)(1 * faceNum), transform.localScale.y, transform.localScale.z);
        }
        
    }
    void playerJump()
    {
        float verticalNum = Input.GetAxis("Vertical");
        if (grounded)
        {
            if (Input.GetButton("Jump"))
            {
                ravenRB.velocity = new Vector2(ravenRB.velocity.x, ravenJumpSpeed);
            }
        }
    }
}
