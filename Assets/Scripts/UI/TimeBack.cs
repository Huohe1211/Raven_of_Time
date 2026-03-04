using DG.Tweening;
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
    [SerializeField] private float ghostCooldown;  // 冷却时间
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private float lastGhostTime = -999f;
    private int rewindFrameSkip = 2;  // 2 = 速度减半
    private int rewindCounter = 0;
    private bool isPreparingRewind = false;
    [SerializeField] private float rewindDelay = 3f; // 起手动画时间
    private Vector3 rewindStartPosition;
    private Quaternion rewindStartRotation;
    public GameObject TimeBackPrefab;

    public ScreenFade screenFade;
    // Start is called before the first frame update
    void Start()
    {
        
        initialPosition = transform.position;
        initialRotation = transform.rotation;
        
        myRenderer = GetComponent<SpriteRenderer>();
        rb2D = GetComponent<Rigidbody2D>();

    }
    void Record()
    {
        timeBackData.Push(new ObjectStage(
            transform.position,
            myRenderer.sprite,
            transform.localScale.x > 0, 
            rb2D.velocity
        ));
    }
    void StartRewind()
    {
        if (isRewinding) return;
        if (timeBackData.Count == 0) return;
        isPreparingRewind = true;
        rewindStartPosition = transform.position;
        rewindStartRotation = transform.rotation;

        transform.position = initialPosition;
            transform.rotation = initialRotation;

        GameObject fx = Instantiate(TimeBackPrefab, transform.position, Quaternion.identity);
        var ps = fx.GetComponent<ParticleSystem>();
        if (ps != null)
        {
            ps.Play();
        }
        Destroy(fx, 0.7f);
        screenFade.PlayFade(transform.position);
        StartCoroutine(BeginRewindAfterDelay());
        
    }
    IEnumerator BeginRewindAfterDelay()
    {

        // ⭐ 记录按下回溯那一刻的位置
 
        yield return new WaitForSeconds(rewindDelay);

        isPreparingRewind = false;
        isRewinding = true;

        // ⭐ 在“原始位置”生成影子
        if (ghostPrefab != null)
        {
            currentGhost = Instantiate(ghostPrefab, rewindStartPosition, rewindStartRotation);

            ghostRenderer = currentGhost.GetComponent<SpriteRenderer>();
            ghostRb = currentGhost.GetComponent<Rigidbody2D>();

            if (ghostRb != null)
                ghostRb.isKinematic = true;
        }

        // ⭐ 再把本体传送回初始点

    }
    void Rewind()
    {
        rewindCounter++;

        if (rewindCounter < rewindFrameSkip)
            return;

        rewindCounter = 0;
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
            if (isPreparingRewind)
                return;
            Record();
        }
        // Update is called once per frame
        
    }
    void Update()
    {
        if (isPreparingRewind)
            return;
        if (isRewinding)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                if (Time.time - lastGhostTime >= ghostCooldown)
                {
                    SpawnVisualGhost();
                    lastGhostTime = Time.time;
                }
            }
            return;
        }

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
    void SpawnVisualGhost()
    {
        if (ghostPrefab == null) return;
        if (currentGhost == null) return;
        GameObject ghost = Instantiate(
        ghostPrefab,
        currentGhost.transform.position,   // ⭐ 用影子位置
        Quaternion.identity
    );

        // ⭐ 关闭碰撞
        Collider2D col = ghost.GetComponent<Collider2D>();
        if (col != null)
            col.enabled = false;

        // ⭐ 关闭刚体
        Rigidbody2D rb = ghost.GetComponent<Rigidbody2D>();
        if (rb != null)
            rb.simulated = false;

        // ⭐ 淡出
        SpriteRenderer sr = ghost.GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            sr.DOFade(0f, 1.2f).OnComplete(() =>
            {
                Destroy(ghost);
            });
        }
    }
    public void ForceRecordStart()
    {
        timeBackData.Clear();

        timeBackData.Push(new ObjectStage(
            transform.position,
            myRenderer.sprite,
            transform.localScale.x > 0,
            Vector2.zero
        ));
    }
    

}
