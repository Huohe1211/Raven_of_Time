using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


/// <summary>
/// The Pnl above the scene to present the value of the Coin.
/// </summary>
public class UI_PnlX : MonoBehaviour
{
    public RectTransform pnl_X;
    public TextMeshProUGUI txt_Coin;
    public RavenDeath ravendeath;

    public void Init()
    {
        pnl_X.anchoredPosition = new Vector2(25.1354f, 64f);
    }


    public void AnimShowPnl_X()
    {
        DOTween.Sequence()
            .AppendInterval(3f)
            .Append(pnl_X.DOAnchorPosY(-54f, 1f));
    }

    /// <summary>
    /// Set Coin value.
    /// </summary>
    /// <param name="targetValue">The result value.</param>
    public void SetCoinValue(int targetValue)
    {
        if (targetValue < 0)
        {
            txt_Coin.text = 0.ToString();
        }

        txt_Coin.text = targetValue.ToString();

    }
    public int GetCoinValue() 
    {
        return Convert.ToInt32(txt_Coin.text);
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ravendeath.isDead==true)
        {
            txt_Coin.text = 0.ToString();
        }
    }
}
