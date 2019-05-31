using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// カードを売り切った時やニュースの出現時など、発生させたいイベントの処理を記述するクラス
/// 引数は１つまで。それ以上のイベントを記述したい場合、要相談
/// </summary>
[CreateAssetMenu(fileName = "eventFunction", menuName = "CreateEventFunction")]
public class EventFunctions : ScriptableObject
{

    private void Awake()
    {

    }


    /// <summary>
    /// 会社利益を+(引数)します
    /// </summary>
    /// <param name="val"></param>
    public void AddMargin(int val)
    {
        CompanyInfomation.Instance.AddCompanyMargin(val);
    }

    /// <summary>
    /// 倒産までの日数を+(引数)します
    /// </summary>
    /// <param name="val"></param>
    public void AddDay(int val)
    {
        CompanyInfomation.Instance.AddDayleft(val);
    }

    public void PlayBGM(int v)
    {
        AudioManager.Instance.PlayBGM(v);
    }

    public void PlaySE(int v)
    {
        AudioManager.Instance.PlaySE(v);
    }
}
