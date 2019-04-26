
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
    private Text nameText; //商品名を書くためのTextオブジェクト

    [SerializeField]
    private Text effectText;//商品効果を書くためのTextオブジェクト

    [SerializeField]
    private Text maxStockText;//在庫数を書くためのTextオブジェクト

    [SerializeField]
    private Text currentStockText;//現在の在庫数を書くためのTextオブジェクト

    [SerializeField]
    private Text mouseOverText;//マウスがアイコンの上に乗った時表示されるヒントを書くためのオブジェクト

    [SerializeField]
    private SpriteRenderer cardIcon;//アイコン画像を変更するためのオブジェクト

    [SerializeField]
    private FadeUpText fadeUpText;//+n と上昇していく、売れた個数を表すテキスト

    [SerializeField]
    private Color selectedColor;//選択中の色

    private UnityEngine.Events.UnityEvent boughtEvent;//商品が買われたときの効果を記述したクラス

    private int currentStock;//現在までに売れた個数
    private int maxStock;//在庫数

    private bool isSelected=false;//このカードが選択中かのフラグ

    private float sellInADay;//一日当たり売れる量
    private float sellInATemp;//sellInADayの余剰分を記録しておく

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    /// <summary>
    /// 更新処理
    /// </summary>
    private void Update()
    {
        //マウスと接触しているかの判定
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hitData = Physics2D.Raycast(ray.origin, ray.direction, 100f);

        if (hitData)
        {
            //重なっているときクリックされたら選択中の切り替え
            if(Input.GetMouseButtonDown(0))
            {
                if(hitData.collider.gameObject == gameObject)
                {
                    Debug.Log("hit=" + gameObject.name);

                    SwitchChosenCard();
                }

            }
        }


        //選択中であれば色を変える
        if(this.isSelected)
        {
            GetComponent<SpriteRenderer>().color = selectedColor;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
        }
    }

    /// <summary>
    /// 選択中カードの切り替え
    /// </summary>
    private void SwitchChosenCard()
    {
        CardBase[] cardList =CompanyInfomation.Instance.GetCardListOnWindow();
        //一度すべてのカードを非選択状態に
        for (int i=0;i<cardList.Length;i++)
        {
            cardList[i].SetIsChosen(false);
        }
        //自分のカードを選択中に。
        this.SetIsChosen(true);
        CompanyInfomation.Instance.SetChosenCard(gameObject.GetComponent<CardBase>());

    }

    /// <summary>
    /// カード情報を初期化設定するための関数
    /// </summary>
    /// <param name="nameText"></param>商品名
    /// <param name="effectText"></param>カードの効果説明
    /// <param name="maxStock"></param>カードの在庫数
    /// <param name="effect"></param>カードの効果を記述したクラス
    /// <param name="tex"></param>アイコン画像
    public void CardInitialize(string nameText,string effectText,string mouseText, int maxStock, UnityEngine.Events.UnityEvent effect,Sprite tex,
        float firstSellInADay)
    {
        this.SetNameText(nameText);
        this.SetCardEffectText(effectText);
        this.SetMouseOverText(mouseText);
        this.SetMaxStock(maxStock);
        this.SetCardEffect(effect);
        this.SetCardIconImage(tex);
        this.SetSellInADay(firstSellInADay);

        //ヒントのみ最初は表示しない
        this.mouseOverText.enabled = false;
    }

    /// <summary>
    /// カードが売れたときの処理
    /// </summary>
    public void OnBoughtCard()
    {
        //登録してあるメソッドを行う
        boughtEvent.Invoke();
    }

    /// <summary>
    /// 一日の終わりの処理を記述。
    /// 売れたか売れないかの処理を行う。
    /// </summary>
    public void EndOfTheDay()
    {
        //1日当たり売れる量がマイナスの場合、処理しない
        if (this.sellInADay < 0) return;
        //一日当たり売れる量の増加
        this.sellInATemp += this.sellInADay;
        //整数の取得
        int temp = (int)sellInATemp;
        //売れた分だけ売れたときの処理を行う
        for (int i = 0; i < temp; i++)
        {
            OnBoughtCard();
        }
        //小数点以下のみ記録
        sellInATemp -= temp;
        //売れた個数を記録
        this.currentStock += temp;

        //売れた数を表示する
        this.fadeUpText.SetText("+" + temp.ToString());
        this.fadeUpText.StartRising();

        //売り切れの処理
        if (currentStock >= this.maxStock)
        {

        }

        //表示個数の設定
        this.currentStockText.text = this.currentStock.ToString();
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
    /// カード効果の表記を設定するための関数
    /// </summary>
    /// <param name="effectText"></param>
    public void SetCardEffectText(string effectText)
    {
        effectText.Replace("<br>", "\n");
        this.effectText.text = effectText;
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
    /// 現在在庫数の表記を設定するための関数
    /// </summary>
    /// <param name="value"></param>
    public void SetCurrentStock(int value)
    {
        this.currentStockText.text = value.ToString();
    }

    /// <summary>
    /// 売るべき在庫数の表記を設定するための関数
    /// </summary>
    /// <param name="value"></param>
    public void SetMaxStock(int value)
    {
        this.maxStockText.text = "/" + value.ToString();
        this.maxStock = value;
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
    /// 一日当たり売れる量の設定。主に初期設定
    /// </summary>
    /// <param name="val"></param>
    public void SetSellInADay(float val)
    {
        this.sellInADay = val;
    }

    /// <summary>
    /// 一日当たり売れる量の増減
    /// </summary>
    /// <param name="val"></param>
    public void AddSellInADay(float val)
    {
        this.sellInADay += val;
    }

    /// <summary>
    /// 一日当たり売れる量の取得
    /// </summary>
    /// <returns></returns>
    public float GetSellInADay()
    {
        return this.sellInADay;
    }

    /// <summary>
    /// カードが選択中かを取得する
    /// </summary>
    public bool GetIsChosen()
    {
        return this.isSelected;
    }

    /// <summary>
    /// カードが選択中かを選択する
    /// </summary>
    /// <param name="flag"></param>
    public void SetIsChosen(bool flag)
    {
        this.isSelected = flag;
    }

    public void SetStock(int val)
    {
        this.maxStock = val;
    }

    /// <summary>
    /// 商品の在庫数を取得する
    /// </summary>
    /// <returns></returns>
    public int GetMaxStock()
    {
        return this.maxStock;
    }

    /// <summary>
    /// 現在売れた数を取得する
    /// </summary>
    /// <returns></returns>
    public int GetCurrentStock()
    {
        return this.currentStock;
    }

}
