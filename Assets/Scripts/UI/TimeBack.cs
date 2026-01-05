using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.IK;

public class TimeBack : MonoBehaviour
{
    private SpriteRenderer ghostRenderer;
    public GameObject ghostPrefab; // 用于回放的残影物体
    private GameObject currentGhost;
    private Stack<ObjectStage> timeBackData = new Stack<ObjectStage>();
    private SpriteRenderer myRenderer;
    private Rigidbody2D rb2D;
    private Rigidbody2D ghostRb;
    private bool isRewinding = false;
    private ObjectStage currentTarget;
    private Vector3 startPos;
    
    // Start is called before the first frame update
    void Start()
    {

        myRenderer = GetComponent<SpriteRenderer>();
        rb2D = GetComponent<Rigidbody2D>();

    }
    void Record()
    {
        // 限制记录长度（例如只记5秒，约300帧），防止内存溢出
        if (timeBackData.Count > 300)
        {
            // 这里可以做一些移除旧数据的处理，或者简单停止增加
        }

        timeBackData.Push(new ObjectStage(
            transform.position,
            myRenderer.sprite,
            transform.localScale.x > 0, // 假设你用scale控制朝向
            rb2D.velocity
        ));
    }
    void StartRewind()
    {
        if (timeBackData.Count == 0) return;

        isRewinding = true;

        // 生成残影
        if (ghostPrefab != null)
        {
            currentGhost = Instantiate(ghostPrefab, transform.position, Quaternion.identity);
            ghostRenderer = currentGhost.GetComponent<SpriteRenderer>();

            // 重要：确保残影是运动学的，否则它会受重力掉下去
            var ghostRb = currentGhost.GetComponent<Rigidbody2D>();
            if (ghostRb != null) ghostRb.isKinematic = true;
        }
    }
    void Rewind()
    {
        if (timeBackData.Count > 0 && currentGhost != null)
        {
            ObjectStage stage = timeBackData.Pop();

            // 使用物理移动而非直接修改坐标，保证碰撞生效
            if (ghostRb != null)
            {
                ghostRb.MovePosition(stage.Position);
            }
            else
            {
                currentGhost.transform.position = stage.Position;
            }

            if (ghostRenderer != null) ghostRenderer.sprite = stage.Sprite;
            currentGhost.transform.localScale = new Vector3(stage.IsRight ? 1 : -1, 1, 1);
        }
        else
        {
            StopRewind();
        }
    }
    void StopRewind()
    {
        isRewinding = false;
        // 如果你希望重播完后残影消失，取消下面注释
         if (currentGhost != null) Destroy(currentGhost); 
    }
    void FixedUpdate()
    {
        if (isRewinding)
        {
            Rewind();
        }
        else
        {
            Record();
        }
        // Update is called once per frame
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) StartRewind();
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("R键已按下！当前记录帧数: " + timeBackData.Count);
            
        }
    }
}
