﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarBottun : MonoBehaviour
{
    [SerializeField]
    private StarButtonBase[] buttons;//☆1ボタン

    [SerializeField]
    private float DECREASE_MAGNI = 3;//確率上昇値の係数
    [SerializeField]
    private float INCREASE_VALUE = 1;//確率上昇値

    /// <summary>
    /// ボタンが押されたときの処理
    /// </summary>
    /// <param name="starNum"></param>
    public void ButtonCommonFunc(int starNum)
    {
        int starNumber = starNum -1;//配列に合わせるための-1
        //会社情報の取得
        CompanyInfomation company = CompanyInfomation.Instance;
        //選択中カードを取得
        ProductCard currentCard = company.GetChosenCard();
        if (currentCard == null) return;

        //カードレビューしたよ！
        currentCard.CardReviewedFunction();
        //音を鳴らす
        AudioManager.Instance.PlaySE(1);
    }
    
}
