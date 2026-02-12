using UnityEngine;
using System.Collections.Generic;

public class TimeManager : MonoBehaviour
{
    private List<IResettable> resettables = new List<IResettable>();

    void Start()
    {
        IResettable[] foundObjects = FindObjectsOfType<MonoBehaviour>(true) as IResettable[];
    }

    void Awake()
    {
        MonoBehaviour[] all = FindObjectsOfType<MonoBehaviour>(true);

        foreach (var obj in all)
        {
            if (obj is IResettable resettable)
            {
                resettables.Add(resettable);
            }
        }
    }

    public void ResetAll()
    {
        foreach (var obj in resettables)
        {
            obj.ResetToInitialState();
        }
    }
}
