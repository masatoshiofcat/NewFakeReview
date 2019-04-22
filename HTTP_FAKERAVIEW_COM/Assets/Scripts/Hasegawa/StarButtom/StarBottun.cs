using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarBottun : MonoBehaviour
{
    [SerializeField]
    private StarButtonBase[] buttons;//☆1ボタン

    [SerializeField]
    private float DECREASE_MAGNI = 3;//確率上昇値の係数
    [SerializeField]
    private float INCREASE_VALUE = 1;//確率上昇値

    /// <summary>
    /// ボタンが押されたときの処理
    /// </summary>
    /// <param name="starNum"></param>
    public void ButtonCommonFunc(int starNum)
    {
        int starNumber = starNum -1;//配列に合わせるための-1
        //会社情報の取得
        CompanyInfomation company = CompanyInfomation.Instance;
        //選択中カードを取得
        CardBase currentCard = company.GetChosenCard();
        if (currentCard == null) return;

        //レビューが成功するかの判定を行う
        if(Random.Range(0.0f,100.0f) <= buttons[starNumber].GetReviewPercent())
        {
            //カードが売れやすく・売れにくくなる
            currentCard.AddSellInADay(buttons[starNumber].GetReviewAffect());

            //今押されたボタンの確率減少、押されてないボタンは上昇
            this.IncreaseAndDecreaseReviewPercent(starNumber);

        }
        //失敗の処理
        else
        {

        }

        //今押されたボタンが連続して押されてない場合、リセット
        if (buttons[starNumber].GetContinuePushCount() == 0) this.ResetBottonContinueCount();

        //押された回数のカウント
        this.buttons[starNumber].SetContinuePushCount(this.buttons[starNumber].GetContinuePushCount() + 1);


    }

    /// <summary>
    /// 確率減少値を計算する
    /// DECREASE_MAGNI *()
    /// </summary>
    /// <param name="button"></param>
    /// <returns></returns>
    private float CalcDecreasePercent(StarButtonBase button)
    {
        float temp = DECREASE_MAGNI * ((button.GetContinuePushCount() + 1) * 2);

        return -temp;
    }

    /// <summary>
    /// 他のボタンの成功確率上昇・自身のボタン成功確率減少
    /// </summary>
    private void IncreaseAndDecreaseReviewPercent(int starNum)
    {
        for(int i=0;i<buttons.Length;i++)
        {
            //現在押されたボタンかの判定
            if(i == starNum)
            {
                Debug.Log("減少");
                //押されたボタンなら確率減少
                this.buttons[i].AddReviewPercent(this.CalcDecreasePercent(this.buttons[i]));
            }
            else
            {
                //押されてないボタンは確率回復
                Debug.Log("回復");
                 this.buttons[i].AddReviewPercent(this.INCREASE_VALUE);
            }
        }
    }

    /// <summary>
    /// 全てのボタンの連続して押された回数をリセットする
    /// </summary>
    private void ResetBottonContinueCount()
    {
        for(int i=0;i<buttons.Length;i++)
        {
            this.buttons[i].SetContinuePushCount(0);
        }
    }

}
