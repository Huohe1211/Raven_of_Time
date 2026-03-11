using System.Collections.Generic;
using UnityEngine;

public class ActiveRecorder : MonoBehaviour
{
    public List<GameObject> targets = new List<GameObject>();

    private Dictionary<GameObject, Stack<bool>> activeHistory = new Dictionary<GameObject, Stack<bool>>();

    private bool isRewinding = false;

    void Start()
    {
        // 为每个目标创建一个历史栈
        foreach (GameObject obj in targets)
        {
            activeHistory[obj] = new Stack<bool>();
        }
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

    void Record()
    {
        foreach (GameObject obj in targets)
        {
            if (obj == null) continue;

            activeHistory[obj].Push(obj.activeSelf);
        }
    }

    void Rewind()
    {
        foreach (GameObject obj in targets)
        {
            if (obj == null) continue;

            if (activeHistory[obj].Count > 0)
            {
                bool state = activeHistory[obj].Pop();

                if (obj.activeSelf != state)
                {
                    obj.SetActive(state);
                }
            }
        }
    }

    public void StartRewind()
    {
        isRewinding = true;
    }

    public void StopRewind()
    {
        isRewinding = false;
    }
}