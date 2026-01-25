using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.IK;

public class TimeBack : MonoBehaviour
{
    private SpriteRenderer ghostRenderer;
    public GameObject ghostPrefab; // ���ڻطŵĲ�Ӱ����
    private GameObject currentGhost;
    private Stack<ObjectStage> timeBackData = new Stack<ObjectStage>();
    private SpriteRenderer myRenderer;
    private Rigidbody2D rb2D;
    private Rigidbody2D ghostRb;
    private bool isRewinding = false;
    private ObjectStage currentTarget;
    private Vector3 startPos;
    private bool hasUsed=false;
    // Start is called before the first frame update
    void Start()
    {

        myRenderer = GetComponent<SpriteRenderer>();
        rb2D = GetComponent<Rigidbody2D>();

    }
    void Record()
    {
        
        if (timeBackData.Count > 300)
        {
      
        }

        timeBackData.Push(new ObjectStage(
            transform.position,
            myRenderer.sprite,
            transform.localScale.x > 0, 
            rb2D.velocity
        ));
    }
    void StartRewind()
    {
        if (timeBackData.Count == 0) return;

        isRewinding = true;

        // ���ɲ�Ӱ
        if (ghostPrefab != null)
        {
            currentGhost = Instantiate(ghostPrefab, transform.position, Quaternion.identity);
            ghostRenderer = currentGhost.GetComponent<SpriteRenderer>();
           
          
            var ghostRb = currentGhost.GetComponent<Rigidbody2D>();
            if (ghostRb != null) ghostRb.isKinematic = true;
        }
    }
    void Rewind()
    {
        if (timeBackData.Count > 0 && currentGhost != null)
        {
            ObjectStage stage = timeBackData.Pop();

            
            if (ghostRb != null)
            {
                ghostRb.MovePosition(stage.Position);
            }
            else
            {
                currentGhost.transform.position = stage.Position;
            }

            if (ghostRenderer != null) //ghostRenderer.sprite = stage.Sprite;
            currentGhost.transform.localScale = new Vector3(stage.IsRight ? 1 : -1, 1, 1);
        }
        else
        {
            StopRewind();
        }
    }
    public void ResetTimeBackAfter(float delay)
{
    StartCoroutine(ResetAfterDelay(delay));

}

IEnumerator ResetAfterDelay(float delay)
{
    yield return new WaitForSeconds(delay);
    ResetTimeBack();
}
    public void ResetTimeBack()
    {
        // 停止回溯
        isRewinding = false;

        // 清空记录
        timeBackData.Clear();

        // 使用次数还原
        hasUsed = false;

        // 清理残影
        if (currentGhost != null)
        {
            Destroy(currentGhost);
            currentGhost = null;
        }

        Debug.Log("TimeBack reset after death");
        this.enabled = true;
    }
    void StopRewind()
    {
        isRewinding = false;
        hasUsed = true;
       
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
        
        if (!hasUsed && Input.GetKeyDown(KeyCode.R))
        {
            StartRewind();
            Debug.Log("start" + timeBackData.Count);
            
        }
        
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Debug.Log("not enough");
            }
        }
    }
}
