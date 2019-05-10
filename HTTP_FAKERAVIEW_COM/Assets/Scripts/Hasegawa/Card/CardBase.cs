
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// 商品カードのクラス
/// </summary>
public class CardBase : MonoBehaviour
{
    enum CardState
    {
        APPERARANCE, //登場
        SELLING,//販売中
        SOLDOUT,//売り切れの時の処理
    }


    [SerializeField]
    private Text nameText; //商品名を書くためのTextオブジェクト

    [SerializeField]
    private Text effectText;//商品効果を書くためのTextオブジェクト

    [SerializeField]
    private Text mouseOverText;//マウスがアイコンの上に乗った時表示されるヒントを書くためのオブジェクト

    [SerializeField]
    private SpriteRenderer cardIcon;//アイコン画像を変更するためのオブジェクト

    [SerializeField]
    private Color selectedColor;//選択中の色

    [SerializeField]
    private LerpSprite soldOutImage;//売り切れの時表示する画像

    private UnityEngine.Events.UnityEvent boughtEvent;//商品が買われたときの効果を記述したクラス

    private int price;//価格
    private float easeOfSell;//この商品の売れやすさ


    private bool isSelected=false;//このカードが選択中かのフラグ
    CardState currentState;//現在の状態

    // Start is called before the first frame update
    private void Start()
    {
        //最初は登場から
        currentState = CardState.SELLING;
    }

    /// <summary>
    /// 更新処理
    /// </summary>
    private void Update()
    {
        switch (this.currentState)
        {
            case CardState.APPERARANCE:
                this.ExecuteAppearance();
                break;
            case CardState.SELLING:
                this.ExecuteSelling();
                break;
            case CardState.SOLDOUT:
                this.ExecuteSoldOut();
                break;
             default:
                break;
        }

    }

    /// <summary>
    /// 登場時の処理
    /// </summary>
    private void ExecuteAppearance()
    {

    }

    /// <summary>
    /// 販売中の処理
    /// </summary>
    private void ExecuteSelling()
    {
        //マウスと接触しているかの判定
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hitData = Physics2D.Raycast(ray.origin, ray.direction, 100f);

        if (hitData)
        {
            //重なっているときクリックされたら選択中の切り替え
            if (Input.GetMouseButtonDown(0))
            {
                if (hitData.collider.gameObject == gameObject)
                {
                    SwitchChosenCard();
                }

            }
        }

        //選択中であれば色を変える
        if (this.isSelected)
        {
            GetComponent<SpriteRenderer>().color = selectedColor;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }
    }

    /// <summary>
    /// 売り切れになったときの処理
    /// </summary>
    private void ExecuteSoldOut()
    {

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
            if (cardList[i] == null) continue;
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
    public void CardInitialize(string nameText,string effectText,string mouseText,UnityEngine.Events.UnityEvent effect,Sprite tex,
        float easeOfSell,int price)
    {
        this.SetNameText(nameText);
        this.SetCardEffectText(effectText);
        this.SetMouseOverText(mouseText);
        this.SetCardEffect(effect);
        this.SetCardIconImage(tex);
        this.SetEaseOfSell(easeOfSell);
        this.SetPrice(price);
        //ヒントのみ最初は表示しない
        this.mouseOverText.enabled = false;
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
    /// 一日の終わりの処理を記述。
    /// 売れたか売れないかの処理を行う。
    /// </summary>
    public void EndOfTheDay()
    {
        if(this.currentState == CardState.SELLING)
        {
        }

    }


    /// <summary>
    /// カードがレビューされたときの処理
    /// </summary>
    public void CardReviewedFunction()
    {
        //売りに出しているときじゃないと評価できない
        if(this.currentState == CardState.SELLING)
        {
            //登録してあるメソッドを行う
            boughtEvent.Invoke();
            //選択中の表記であれば解除する　
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            //売り切れ！の表示
            soldOutImage.StartLerp();
            //状態を売り切れに
            this.currentState = CardState.SOLDOUT;
            //アニメーションを売り切れ時の物に
            GetComponent<Animator>().SetTrigger("isSoldOut");
        }

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
        //売れたら利益がいくら増えるを記述しておく
        this.effectText.text = "・売れると" + this.price + "円の利益\n";
        this.effectText.text += effectText;
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

}
