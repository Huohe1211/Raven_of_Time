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
        // ���Ƽ�¼���ȣ�����ֻ��5�룬Լ300֡������ֹ�ڴ����
        if (timeBackData.Count > 300)
        {
            // ���������һЩ�Ƴ������ݵĴ�������߼�ֹͣ����
        }

        timeBackData.Push(new ObjectStage(
            transform.position,
            myRenderer.sprite,
            transform.localScale.x > 0, // ��������scale���Ƴ���
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
            Debug.Log("��ʼ���ݣ�����Ψһ��һ�λ��ᣡ");
            // ��Ҫ��ȷ����Ӱ���˶�ѧ�ģ�������������������ȥ
            var ghostRb = currentGhost.GetComponent<Rigidbody2D>();
            if (ghostRb != null) ghostRb.isKinematic = true;
        }
    }
    void Rewind()
    {
        if (timeBackData.Count > 0 && currentGhost != null)
        {
            ObjectStage stage = timeBackData.Pop();

            // ʹ�������ƶ�����ֱ���޸����꣬��֤��ײ��Ч
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
    void StopRewind()
    {
        isRewinding = false;
        hasUsed = true;
        // �����ϣ���ز�����Ӱ��ʧ��ȡ������ע��
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
            Debug.Log("R���Ѱ��£���ǰ��¼֡��:你好 " + timeBackData.Count);
            
        }
        
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Debug.Log("�����Ѻľ����������ó���...");
            }
        }
    }
}
