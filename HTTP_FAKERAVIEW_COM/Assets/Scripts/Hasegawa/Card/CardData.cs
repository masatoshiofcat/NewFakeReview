using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
[CreateAssetMenu(fileName = "Card",menuName ="CreateCard")]
public class CardData : ScriptableObject
{
    //カードの種類。主にこれによってイラストが変わる
    public enum KindOfCard
    {
        BOOK,
        DISC, //CDやDVDがこれにあたる
        HOBBY //主に玩具
    }

    //カードのタグ。
    public enum TagOfCard
    {
        NARD, //オタク
        YOUNG, //若者
    }

    [SerializeField]
    private KindOfCard kind;//カードの種類

    [SerializeField]
    private string cardName;//商品名

    [SerializeField]
    private TagOfCard[] cardTag;//商品についているタグ

    [SerializeField]
    private UnityEngine.Events.UnityEvent boughtEvents = new UnityEngine.Events.UnityEvent();

    [SerializeField]
    private string cardEffectText;//カードに書かれる、効果の説明

    [SerializeField]
    private int stock; //在庫数

    [SerializeField]
    private string mouseOverText;//マウスが上に乗った時表示されるヒント

    [SerializeField]
    private float firstSellInADay;//一日当たり売れる量の初期値
    [SerializeField]
    private float firstAmountOfIncrease = 1.02f;//評価した時sellInADay増加量の初期値
    [SerializeField]
    private float firstAmountOfDecrease = 0.98f;//評価した時sellInADay減少量の初期値


    /// <summary>
    /// 商品の種類の取得
    /// </summary>
    /// <returns></returns>
    public KindOfCard GetKind()
    {
        return this.kind;
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
    public TagOfCard[] GetCardTag()
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
    /// 商品の在庫数の取得
    /// </summary>
    /// <returns></returns>
    public int GetStock()
    {
        return this.stock;
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
    public float GetFirstSellInADay()
    {
        return this.firstSellInADay;
    }

    /// <summary>
    /// //評価した時sellInADay増加量の初期値
    /// </summary>
    /// <returns></returns>
    public float GetFirstAmountOfIncrease()
    {
        return this.firstAmountOfIncrease;
    }

    /// <summary>
    /// 評価した時sellInADay減少量の初期値
    /// </summary>
    public float GetFirstAmountOfDecrease()
    {
        return this.firstAmountOfDecrease;
    }

    public void Func()
    {
        Debug.Log("うれました");

    }


}
