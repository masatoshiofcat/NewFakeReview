using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
[CreateAssetMenu(fileName = "Card",menuName ="CreateCard")]
public class CardData : ScriptableObject
{

    [SerializeField]
    private Shared.Tags iconTag;//カードの種類　これで画像を変える

    [SerializeField]
    private string cardName;//商品名

    [SerializeField]
    private Shared.Tags[] cardTag;//商品についているタグ

    [SerializeField]
    private UnityEngine.Events.UnityEvent boughtEvents = new UnityEngine.Events.UnityEvent();

    [SerializeField]
    private float EaseOfSell;//商品の売れやすさ係数

    [SerializeField]
    private int price;//価格

    [SerializeField,Multiline(3)]
    private string cardEffectText;//カードに書かれる、効果の説明

    [SerializeField,Multiline(3)]
    private string mouseOverText;//マウスが上に乗った時表示されるヒント

    /// <summary>
    /// 商品の種類の取得
    /// </summary>
    /// <returns></returns>
    public Shared.Tags GetKind()
    {
        return this.iconTag;
    }

    /// <summary>
    /// 商品名の取得
    /// </summary>
    /// <returns></returns>
    public String GetCardName()
    {
        return this.cardName;
    }

    /// <summary>
    /// 商品についているタグの取得
    /// </summary>
    /// <returns></returns>
    public Shared.Tags[] GetCardTag()
    {
        return this.cardTag;
    }

    /// <summary>
    /// カードの効果スクリプトの取得
    /// </summary>
    /// <returns></returns>
    public UnityEngine.Events.UnityEvent GetCardEffect()
    {
        return this.boughtEvents;
    }

    /// <summary>
    /// カードの効果説明文の取得
    /// </summary>
    /// <returns></returns>
    public string GetCardEffectText()
    {
        return this.cardEffectText;
    }

    /// <summary>
    /// マウスが上に乗った時表示される文字列の取得
    /// </summary>
    public string GetMouseOverString()
    {
        return this.mouseOverText;
    }

    /// <summary>
    /// 一日当たり売れる量の初期値を返す
    /// </summary>
    /// <returns></returns>
    public float GetEaseOfSell()
    {
        return this.EaseOfSell;
    }

    /// <summary>
    /// 価格を返す
    /// </summary>
    /// <returns></returns>
    public int GetPrice()
    {
        return this.price;
    }


}
