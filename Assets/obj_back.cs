using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obj_back : MonoBehaviour
{
    private Stack<ObjectStage> timeBackData = new Stack<ObjectStage>();

    private SpriteRenderer myRenderer;
    private Rigidbody2D rb2D;

    private bool isRewinding = false;
    private int rewindFrameSkip = 2;  // 2 = ËÙ¶È¼õ°ë
    private int rewindCounter = 0;


    void Awake()
    {
        myRenderer = GetComponent<SpriteRenderer>();
        rb2D = GetComponent<Rigidbody2D>();
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
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartRewind();
        }
    }
    void Record()
    {
        

        timeBackData.Push(new ObjectStage(
            transform.position,
            myRenderer != null ? myRenderer.sprite : null,
            transform.localScale.x > 0,
            rb2D != null ? rb2D.velocity : Vector2.zero
        ));
    }

    void Rewind()
    {
        rewindCounter++;

        if (rewindCounter < rewindFrameSkip)
            return;

        rewindCounter = 0;
        if (timeBackData.Count > 0)
        {
            ObjectStage stage = timeBackData.Pop();

            transform.position = stage.Position;

            if (myRenderer != null && stage.Sprite != null)
                myRenderer.sprite = stage.Sprite;

            transform.localScale = new Vector3(stage.IsRight ? 1 : -1, 1, 1);
        }
        else
        {
            StopRewind();
        }
    }

    public void StartRewind()
    {
        if (isRewinding) return;
        if (timeBackData.Count == 0) return;

        isRewinding = true;

        if (rb2D != null)
        {
            rb2D.velocity = Vector2.zero;
            rb2D.simulated = false;
        }
    }

    public void StopRewind()
    {
        isRewinding = false;

        if (rb2D != null)
        {
            rb2D.simulated = true;
        }
    }

    public void ClearRecord()
    {
        timeBackData.Clear();
    }
}
