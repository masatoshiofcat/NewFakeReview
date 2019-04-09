///カードを動的に生成するためのクラス
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject cardFrame;//CardBaseをアタッチしてある、カードの枠、テキスト入力をまとめたオブジェクト

    [SerializeField]
    CardDataBase cardDataList; //カードのデータをまとめたデータベース

    [SerializeField]
    Sprite[] cardIcons;//カードのアイコンリスト

    [SerializeField]
    Vector3 LEFT_TOP_ON_WINDOW;//カード表示枠の左上

    [SerializeField]
    Vector3 CARD_OFFSET;//カード一枚との間隔

    [SerializeField]
    int CARDS_NUM_IN_SAME_ROW=2;//1列に表示されるカードの枚数

    // Start is called before the first frame update
    void Start()
    {
        //デバッグ用　カードデータのnullチェック
        this.cardDataList.CardListNullCheck();

    }

    // Update is called once per frame
    void Update()
    {
        CardGenerate();
    }

    /// <summary>
    /// カードを生成します
    /// </summary>
    public void CardGenerate()
    {
        //表示枠に空きがあるかどうかを調べる
        CardBase[] cardOnWindow = CompanyInfomation.Instance.GetCardListOnWindow();
        int i = 0;
        for(i=0;i<cardOnWindow.Length;i++)
        {
            if (cardOnWindow[i] == null) break;
        }
        //空きが無ければ処理しない
        if (i >= cardOnWindow.Length) return;

        //乱数より1枚のデータの取得
        CardData cardData =  cardDataList.GetACardDataFromRandom();
        //カードの実体を生成
        GameObject card =  Instantiate(this.cardFrame);
        //カードのパラメータを設定する
        card.GetComponent<CardBase>().CardInitialize(cardData.GetCardName(), cardData.GetCardEffectText(), cardData.GetStock(), cardData.GetCardEffect(), GetIconSpriteFromCardKind(cardData)
            ,cardData.GetFirstSellInADay(),cardData.GetFirstAmountOfIncrease(),cardData.GetFirstAmountOfDecrease());

        //!カードの座標を決定
        card.transform.position = DecisionCardPosition(i);

        //カードを保持しておく
        cardOnWindow[i] = card.GetComponent<CardBase>();

    }

    /// <summary>
    /// カードの座標を決定する
    /// </summary>
    /// <param name="cardIndex"></param>
    /// <returns></returns>
    private Vector3 DecisionCardPosition(int cardIndex)
    {
        Vector3 temp = LEFT_TOP_ON_WINDOW;
        //x座標の設定
        temp.x += CARD_OFFSET.x * (cardIndex% CARDS_NUM_IN_SAME_ROW);
        //y座標の設定
        temp.y += CARD_OFFSET.y * (cardIndex / CARDS_NUM_IN_SAME_ROW);

        return temp;
    }

    /// <summary>
    /// カード種類からアイコン画像を取得する
    /// </summary>
    /// <returns></returns>
    private Sprite GetIconSpriteFromCardKind(CardData cardData)
    {
        return cardIcons[(int)cardData.GetKind()];
    }

}
