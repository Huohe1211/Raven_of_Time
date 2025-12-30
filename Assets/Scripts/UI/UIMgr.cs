using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMgr : MonoBehaviour
{
    public static UIMgr I;

    public UI_Loading ui_Loading;
    public UI_PnlX ui_PnlX;

    private void Awake()
    {
        I = this;

        ui_Loading.Init();
        ui_PnlX.Init();



    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
