///カードのデータをまとめておくデータベースを作るためのクラス
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[CreateAssetMenu(fileName = "CardDataBase",menuName ="CreateCardDataBase")]
public class CardDataBase : ScriptableObject
{
    [SerializeField]
    private List<CardData> cardDataList = new List<CardData>();


    [SerializeField]
    List<CardData> test = new List<CardData>(1);

    /// <summary>
    /// Getter & Setter
    /// </summary>
    public List<CardData> CardDatas { get { return this.cardDataList; } set { this.cardDataList = value; } }

    /// <summary>
    /// リスト内にあるカードデータを一つランダムに取得する
    /// </summary>
    /// <returns></returns>
    public CardData GetACardDataFromRandom()
    {
        int ran =  Random.Range(0, this.cardDataList.Count);

        return this.cardDataList[ran];
    }

    /// <summary>
    /// データの入っていない物がないかチェックする。
    /// </summary>
    public void CardListNullCheck()
    {
        for(int i=0;i<this.cardDataList.Count; ++i)
        {
            CardData card = this.cardDataList[i];

            if (card.CardEffects == null)
            {
                Debug.Log("効果スクリプトがない！index="+i.ToString());
            }

            if(card.CardEffectText == "")
            {
                Debug.Log("効果説明が無記入!index="+i.ToString());
            }

            if(card.CardName == "")
            {
                Debug.Log("商品名が無記入!index="+i.ToString());
            }

            if(card.Stock <=0)
            {
                Debug.Log("在庫数のパラメータエラー!index=" + i.ToString());
            }
        }
    }

}
