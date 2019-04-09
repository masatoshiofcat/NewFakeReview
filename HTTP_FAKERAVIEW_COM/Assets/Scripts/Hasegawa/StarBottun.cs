using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarBottun : MonoBehaviour
{
    public void Star1ButtonFunc()
    {
        CompanyInfomation company = CompanyInfomation.Instance;
        //星が足りるかどうか
        if (company.GetStarNum() < 1) return;
        //星を減少
        company.AddStarNum(-1);

        //選択中カードを取得
        CardBase currentCard= company.GetChosenCard();
        if (currentCard == null) return;
        //設定している値分だけ基本的に売れにくくなる
        currentCard.AddSellInADay(currentCard.GetAmountOfDecrease());

    }

    public void Star2ButtonFunc()
    {
        CompanyInfomation company = CompanyInfomation.Instance;
        //星が足りるかどうか
        if (company.GetStarNum() < 2) return;
        //星を減少
        company.AddStarNum(-2);
    }


    public void Star3ButtonFunc()
    {
        CompanyInfomation company = CompanyInfomation.Instance;
        //星が足りるかどうか
        if (company.GetStarNum() < 3) return;
        //星を減少
        company.AddStarNum(-3);

        //選択中カードを取得
        CardBase currentCard = company.GetChosenCard();
        if (currentCard == null) return;
        //設定している値分だけ基本的に売れやすく
        currentCard.AddSellInADay(currentCard.GetAmountOfIncrease());


    }

}
