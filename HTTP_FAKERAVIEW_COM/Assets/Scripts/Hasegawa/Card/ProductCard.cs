using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductCard : CardBase
{
    enum CardState
    {
        APPERARANCE, //登場
        SELLING,//販売中
        SOLDOUT,//売り切れの時の処理
    }

    CardState currentState;//現在の状態
    private Animator animator;

    private bool isSelected = false;//このカードが選択中かのフラグ

    // Start is called before the first frame update
    void Start()
    {
        //最初は登場から
        currentState = CardState.SELLING;
        //コンポーネントの取得
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
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
        int layer = LayerMask.NameToLayer("ProductCard");
        RaycastHit2D hitData = Physics2D.Raycast(ray.origin, ray.direction, 100f,1<< layer);

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
    /// 一日の終わりの処理を記述。
    /// 売れたか売れないかの処理を行う。
    /// </summary>
    public void EndOfTheDay()
    {
        if (this.currentState == CardState.SELLING)
        {
        }

    }

    /// <summary>
    /// 選択中カードの切り替え
    /// </summary>
    private void SwitchChosenCard()
    {
        ProductCard[] cardList = CompanyInfomation.Instance.GetCardListOnWindow();
        //一度すべてのカードを非選択状態に
        for (int i = 0; i < cardList.Length; i++)
        {
            if (cardList[i] == null) continue;
            cardList[i].SetIsChosen(false);
        }
        //自分のカードを選択中に。
        this.SetIsChosen(true);
        CompanyInfomation.Instance.SetChosenCard(this);
    }

    /// <summary>
    /// カードがレビューされたときの処理
    /// </summary>
    public void CardReviewedFunction()
    {
        //売りに出しているときじゃないと評価できない
        if (this.currentState == CardState.SELLING)
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
            this.animator.SetTrigger("isSoldOut");
        }

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

}
