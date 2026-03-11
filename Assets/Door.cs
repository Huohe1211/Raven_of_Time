using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        if (UIMgr.I.ui_PnlX.GetCoinValue() >= 3)
        {
            OpenDoor();
        }
    }

    void OpenDoor()
    {
        gameObject.SetActive(true);
    }
}
