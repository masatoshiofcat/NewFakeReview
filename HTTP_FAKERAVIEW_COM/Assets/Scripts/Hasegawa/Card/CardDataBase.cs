///カードのデータをまとめておくデータベースを作るためのクラス
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[CreateAssetMenu(fileName = "CardDataBase",menuName ="CreateCardDataBase")]
public class CardDataBase : ScriptableObject
{
    [SerializeField]
    private List<CardData> cardDataList = new List<CardData>();

    /// <summary>
    /// カードのデータリストの取得
    /// </summary>
    /// <returns></returns>
    public List<CardData> GetCardDataList()
    {
        return this.cardDataList;
    }

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

            if (card.GetCardEffect() == null)
            {
                Debug.Log("効果スクリプトがない！index="+i.ToString());
            }

            if(card.GetCardEffectText() == "")
            {
                Debug.Log("効果説明が無記入!index="+i.ToString());
            }

            if(card.GetCardName() == "")
            {
                Debug.Log("商品名が無記入!index="+i.ToString());
            }

            if(card.GetStock() <=0)
            {
                Debug.Log("在庫数のパラメータエラー!index=" + i.ToString());
            }

            
        }
    }

}
