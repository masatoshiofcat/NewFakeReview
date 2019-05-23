
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// 商品カードのクラス
/// </summary>
public class CardBase : MonoBehaviour
{


    [SerializeField]
    protected Text nameText; //商品名を書くためのTextオブジェクト

    [SerializeField]
    protected Text effectText;//商品効果を書くためのTextオブジェクト

    [SerializeField]
    protected Text mouseOverText;//マウスがアイコンの上に乗った時表示されるヒントを書くためのオブジェクト

    [SerializeField]
    protected SpriteRenderer cardIcon;//アイコン画像を変更するためのオブジェクト

    [SerializeField]
    protected Color selectedColor;//選択中の色

    [SerializeField]
    protected LerpSprite soldOutImage;//売り切れの時表示する画像

    protected UnityEngine.Events.UnityEvent boughtEvent;//商品が買われたときの効果を記述したクラス

    protected int price;//価格
    protected float easeOfSell;//この商品の売れやすさ


    // Start is called before the first frame update
    private void Start()
    {
    }

    /// <summary>
    /// 更新処理
    /// </summary>
    private void Update()
    {

    }

    /// <summary>
    /// カード情報を初期化設定するための関数
    /// </summary>
    /// <param name="nameText"></param>商品名
    /// <param name="effectText"></param>カードの効果説明
    /// <param name="maxStock"></param>カードの在庫数
    /// <param name="effect"></param>カードの効果を記述したクラス
    /// <param name="tex"></param>アイコン画像
    public void CardInitialize(string nameText,string effectText,string mouseText,UnityEngine.Events.UnityEvent effect,Sprite tex,
        float easeOfSell,int price)
    {
        this.SetNameText(nameText);
        this.SetPrice(price);

        //売れたら利益がいくら増えるを記述しておく
        this.effectText.text = "・売れると" + this.price + "円の利益\n";
        this.AddCardEffectText(effectText);
        this.SetMouseOverText(mouseText);
        this.SetCardEffect(effect);
        this.SetCardIconImage(tex);
        this.SetEaseOfSell(easeOfSell);

    }

    /// <summary>
    /// カードが売れたときの処理
    /// </summary>
    public void OnBoughtCard()
    {
        //価格分だけ会社利益になる
        CompanyInfomation.Instance.AddCompanyMargin(this.price);
    }

    /// <summary>
    /// カードの表示名を設定するための関数
    /// </summary>
    /// <param name="nameText"></param>
    public void SetNameText(string nameText)
    {
        this.nameText.text = nameText;
    }

    /// <summary>
    /// 商品名の取得
    /// </summary>
    /// <returns></returns>
    public string GetNameString()
    {
        return this.nameText.text;
    }

    /// <summary>
    /// カード効果の表記を設定するための関数
    /// </summary>
    /// <param name="effectText"></param>
    public void SetCardEffectText(string effectText)
    {
        this.effectText.text = effectText;
    }

    public void AddCardEffectText(string effectText)
    {
        this.effectText.text += effectText;
    }

    /// <summary>
    /// カード効果の表記を取得する
    /// </summary>
    public string GetCardBodyText()
    {
        return this.effectText.text;
    }

    /// <summary>
    /// マウスが上に乗った時表示されるヒントを設定するための関数
    /// </summary>
    /// <param name="effectText"></param>
    public void SetMouseOverText(string mouseText)
    {
        this.mouseOverText.text = mouseText;
    }

    /// <summary>
    /// マウスオーバーされた時表示する文字の取得
    /// </summary>
    /// <returns></returns>
    public string GetMouseOverText()
    {
        return this.mouseOverText.text;
    }

    /// <summary>
    /// カードが売れたときの効果を記述したソースの設定
    /// </summary>
    public void SetCardEffect(UnityEngine.Events.UnityEvent boughtEve)
    {
        this.boughtEvent = boughtEve;
    }

    /// <summary>
    /// カードアイコンの設定
    /// </summary>
    /// <param name="tex"></param>
    public void SetCardIconImage(Sprite tex)
    {
        this.cardIcon.sprite =tex;
    }
    /// <summary>
    /// カードアイコンの取得
    /// </summary>
    /// <returns></returns>
    public Sprite GetCardIconTex()
    {
        return this.cardIcon.sprite;
    }

    /// <summary>
    /// 一日当たり売れる量の設定。主に初期設定
    /// </summary>
    /// <param name="val"></param>
    public void SetEaseOfSell(float val)
    {
        this.easeOfSell = val;
    }

    /// <summary>
    /// 一日当たり売れる量の増減
    /// </summary>
    /// <param name="val"></param>
    public void AddEaseOfSell(float val)
    {
        this.easeOfSell += val;
    }

    /// <summary>
    /// 一日当たり売れる量の取得
    /// </summary>
    /// <returns></returns>
    public float GetEaseOfSell()
    {
        return this.easeOfSell;
    }


    /// <summary>
    /// 価格の設定を行う
    /// </summary>
    /// <param name="val"></param>
    /// <returns></returns>
    public void SetPrice(int val)
    {
        this.price = val;
    }

    /// <summary>
    /// 価格の取得
    /// </summary>
    /// <returns></returns>
    public int GetPrice()
    {
        return this.price;
    }

    /// <summary>
    /// この商品のレビュー評価のニュースを流す
    /// </summary>
    public void CreateReviewNews()
    {
        //レビューを作成する
        NewsGenerator.Instance.CreateReviewEvalution("テストメッセージ", 100, this);
        //このオブジェクトは役目を終えた
        GameObject.Destroy(gameObject);        
    }

}
