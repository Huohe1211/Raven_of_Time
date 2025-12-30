using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_PnlX : MonoBehaviour
{
    public RectTransform pnl_X;
    public TextMeshProUGUI text;


    public void Init() 
    {
        pnl_X.anchoredPosition = new Vector2(25.1354f, 64f);
    }


    public void AnimShowPnl_X() 
    {
        DOTween.Sequence()
            .AppendInterval(3f)
            .Append(pnl_X.DOAnchorPosY(-54f,1f));
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
