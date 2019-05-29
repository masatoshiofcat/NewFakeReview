using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName ="News",menuName ="CreateNews")]
public class NewsData : ScriptableObject
{
    /// <summary>
    /// ニュースの種類
    /// </summary>
    public enum NewsKind
    {
        TUTLIAL,
        WOLRD_NEWS,
        MONEY,
        DENGER,
        QUESTION,
    }

    [SerializeField]
    private string newsTitle;//ニュースのタイトル
    [SerializeField, Multiline(3)]
    private string bodyText;//ニュースの本文

    [SerializeField]
    private NewsKind newsKind;//ニュースの種類

    [SerializeField]
    private UnityEngine.Events.UnityEvent appearEvent;//ニュースが出現した時処理される関数



    /// <summary>
    /// ニュースタイトルの取得
    /// </summary>
    /// <returns></returns>
    public string GetNewsTitle()
    {
        return this.newsTitle;
    }

    /// <summary>
    /// ニュース本文の取得
    /// </summary>
    /// <returns></returns>
    public string GetBodyText()
    {
        return this.bodyText;
    }

    /// <summary>
    /// ニュース効果の取得
    /// </summary>
    /// <returns></returns>
    public UnityEngine.Events.UnityEvent GetNewsEvect()
    {
        return this.appearEvent;
    }

    /// <summary>
    /// ニュースの種類の取得
    /// </summary>
    /// <returns></returns>
    public NewsKind GetNewskKind()
    {
        return this.newsKind;
    }
}
