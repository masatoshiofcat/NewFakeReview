using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 残り日数
/// 利益
/// 選択中カード
/// 等を管理する会社クラス
/// </summary>
public class CompanyInfomation : SingletonMonoBehaviour<CompanyInfomation>
{
    [SerializeField]
    private int dayLeft = 120; //残り日数

    //残り日数を描画するためのテキストオブジェクト
    [SerializeField]
    private Text dayLeftTextObject;

    [SerializeField]
    private float SECOUND_IN_A_DAY =6;//1日の秒数

    [SerializeField]
    private int currentConfidence = 3;//信用
    [SerializeField]
    private int currentStar = 10;//☆

    [SerializeField]
    private Text starNumText;//☆の数を書くためのテキスト

    [SerializeField]
    private Text confidenceNumText;//信憑性を書くためのテキスト

    [SerializeField]
    private Text marginText;//利益を書くためのテキスト

    private int dayElapsed = 0;//経過日数
    private int companyMargin=0;//総利益

    private CardBase[] cardsOnWindow = new CardBase[6];//表示されているカード
    private CardBase currentChosenCard;//現在選択中のカード

    private float currentTimeCount=0;//時を進めるためのタイマー


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //一日を経過させる
        if(this.currentTimeCount > this.SECOUND_IN_A_DAY)
        {
            //一日の勘定をし、次の日を迎える
            GreetTheNextDay();
            //タイマーのリセット
            this.currentTimeCount = 0;
        }
        //残り日数表示の更新
        this.dayLeftTextObject.text = "あと" + this.dayLeft.ToString() + "日";
        //☆数の更新
        this.starNumText.text = "x" + this.currentStar.ToString();
        //信憑性の更新
        this.confidenceNumText.text = "+" + this.currentConfidence.ToString();
        //利益の更新
        this.marginText.text = this.companyMargin.ToString() + "円";

        //タイマーを進める
        this.currentTimeCount += Time.deltaTime;
    }

    /// <summary>
    /// 次の日を迎える
    /// </summary>
    public void GreetTheNextDay()
    {
        //商品を売る処理
        for(int i=0;i<this.cardsOnWindow.Length;i++)
        {
            this.cardsOnWindow[i].EndOfTheDay();
        }
        //レビュー☆の回復
        this.currentStar += this.currentConfidence;
        //日にちの経過
        this.dayElapsed++;
        this.dayLeft--;
    }


    //GetterとSetterの数々=================================================

    /// <summary>
    /// 残り日数の取得
    /// </summary>
    public int GetDayLeft()
    {
        return this.dayLeft;
    }
    /// <summary>
    /// 残り日数の設定
    /// </summary>
    /// <param name="day"></param>
    public void SetDayLeft(int day)
    {
        this.dayLeft = day;
    }

    /// <summary>
    /// 残り日数の追加(減少)
    /// </summary>
    /// <param name="value"></param>
    public void AddDayleft(int value)
    {
        this.dayLeft += value;
    }

    /// <summary>
    /// 経過日数の取得
    /// </summary>
    public int GetDayElapsed()
    {
        return this.dayElapsed;
    }

    /// <summary>
    /// 総利益の取得
    /// </summary>
    /// <returns></returns>
    public int GetCompanyMargin()
    {
        return this.companyMargin;
    }

    /// <summary>
    /// 総利益の設定
    /// </summary>
    /// <param name=""></param>
    public void SetCompanyMargin(int val)
    {
        this.companyMargin = val;
    }

    /// <summary>
    /// 総利益の増加（減少）
    /// </summary>
    /// <param name="val"></param>
    public void AddCompanyMargin(int val)
    {
        this.companyMargin += val;
    }


    /// <summary>
    /// 表示されているカードリストの取得
    /// </summary>
    public CardBase[] GetCardListOnWindow()
    {
        return this.cardsOnWindow;
    }

    /// <summary>
    /// 現在選択中のカードの取得
    /// </summary>
    /// <returns></returns>
    public CardBase GetChosenCard()
    {
        return this.currentChosenCard;
    }

    /// <summary>
    /// 現在選択中カードの設定
    /// </summary>
    /// <param name="card"></param>
    public void SetChosenCard(CardBase card)
    {
        this.currentChosenCard = card;
    }

    /// <summary>
    /// 信頼度の取得
    /// </summary>
    /// <returns></returns>
    public int GetCurrentConfidence()
    {
        return this.currentConfidence;
    }

    /// <summary>
    /// 信頼度の設定
    /// </summary>
    /// <param name="val"></param>
    public void SetCurrentConfidence(int val)
    {
        this.currentConfidence = val;
    }

    /// <summary>
    /// 信頼度の増減
    /// </summary>
    /// <param name="val"></param>
    public void AddCurrentConfidence(int val)
    {
        this.currentConfidence += val;
    }

    /// <summary>
    /// スター数の取得
    /// </summary>
    /// <returns></returns>
    public int GetStarNum()
    {
        return this.currentStar;
    }
    /// <summary>
    /// スター数の設定
    /// </summary>
    /// <param name="val"></param>
    public void SetStarNum(int val)
    {
        this.currentStar = val;
    }
    /// <summary>
    /// スター数の増減
    /// </summary>
    /// <param name="val"></param>
    public void AddStarNum(int val)
    {
        this.currentStar += val;
    }

}
