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
    private List<TagOfCard> cardTag;//商品についているタグ

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
    /// Getter & Setter
    /// </summary>
    public KindOfCard CardKind { get { return this.kind; }set { this.kind = value; } }        // 商品の種類　取得＆設定
    public string CardName { get { return this.cardName; } set { this.cardName = value; } }   // カードの名前　取得＆設定
    public List<TagOfCard> CardTags { get { return this.cardTag; }set { this.cardTag = value; } }     // カードについてるタグ　取得＆設定
    public UnityEngine.Events.UnityEvent CardEffects { get { return this.boughtEvents; }set { this.boughtEvents = value; } }    // カードの効果スクリプト 取得＆設定
    public string CardEffectText { get { return this.cardEffectText; }set { this.cardEffectText = value; } } // カードの効果説明文　取得＆設定
    public int Stock { get { return this.stock; }set { this.stock = value; } }  // 商品の在庫数 取得＆設定
    public string MouseOver { get { return this.mouseOverText; } set { this.mouseOverText = value; } }  // マウスが上に乗った時表示される文字列　取得＆設定
    public float FirstSellInADay { get { return this.firstSellInADay; }set { this.firstSellInADay = value; } }  // 一日当たり売れる量の初期値　取得＆設定
    public float FirstAmountOfIncrease { get { return this.firstAmountOfIncrease; } set { this.firstAmountOfIncrease = value; } }   //評価した時sellInADay増加量の初期値　取得＆設定
    public float FirstAmountOfDecrease { get { return this.firstAmountOfDecrease; } set { this.firstAmountOfDecrease = value; } }   // 評価した時sellInADay減少量の初期値　取得＆設定


    public void Func()
    {
        Debug.Log("うれました");

    }



}
