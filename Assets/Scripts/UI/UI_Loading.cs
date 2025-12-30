using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Loading : MonoBehaviour
{
    public Button btn_NewGame;
    public Button btn_Continue;
    public Button btn_Exit;

    
    public void Init()
    {
        Show();

        btn_NewGame.onClick.AddListener(()=>
        {
            Hide();
            GameMgr.I.lvl_01.Show();


            //Tempt===TODO
            UIMgr.I.ui_PnlX.AnimShowPnl_X();
            
        });

    }

    public void Show() 
    {
        gameObject.SetActive(true);    
    }
    public void Hide() 
    {
        gameObject.SetActive(false);
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
