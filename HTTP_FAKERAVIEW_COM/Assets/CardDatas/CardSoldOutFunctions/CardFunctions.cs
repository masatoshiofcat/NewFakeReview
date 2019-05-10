using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// カードを売り切った時発生させたいイベントの処理を記述するクラス
/// 引数は１つまで。それ以上のイベントを記述したい場合、要相談
/// </summary>
[CreateAssetMenu(fileName = "CardSoldOutFunction", menuName = "CreateCardSoldOutFunction")]
public class CardFunctions : ScriptableObject
{
    //会社の持つデータのインスタンス
    private CompanyInfomation company;
    private void Start()
    {
        //会社のインスタンスの取得
        this.company = CompanyInfomation.Instance;
    }


    /// <summary>
    /// 会社利益を+(引数)します
    /// </summary>
    /// <param name="val"></param>
    public void AddMargin(int val)
    {
        this.company.AddCompanyMargin(val);
    }

    /// <summary>
    /// 倒産までの日数を+(引数)します
    /// </summary>
    /// <param name="val"></param>
    public void AddDay(int val)
    {
        this.company.AddDayleft(val);
    }



}
