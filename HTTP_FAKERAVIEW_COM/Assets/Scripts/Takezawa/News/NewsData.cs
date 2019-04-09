using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
[CreateAssetMenu(fileName = "NewsData", menuName = "CreateNews")]
public class NewsData : ScriptableObject
{

    // ニュースのタグ。
    public enum TARGET
    {
        NON,
        NARD, //オタク
        YOUNG, //若者
    }

    public enum TITLES
    {
        NON,
        POLITICS,
        SPORTS,
        HOBBY,
    }

    // ニュースのタイトル
    [SerializeField]
    private TITLES newsTitle;
    // ニュース本文
    [SerializeField]
    private string newsText;

    // ニュースタグ
    [SerializeField]
    private List<TARGET> targetTag;

    // ニュースの効果
    [SerializeField]
    private NewsEffectBase newsEffect;


    //public string SetTitle(TITLES _title)
    //{
    //    switch(_title)
    //    {
    //        case TITLES.POLITICS:
    //            newsTitle = "政治ニュース";
    //            break;
    //        case TITLES.SPORTS:
    //            newsTitle = "スポーツニュース";
    //            break;
    //        case TITLES.HOBBY:
    //            newsTitle = "遊びニュース";
    //            break;
    //        default:
    //            break;
    //    }
    //    return newsTitle;
    //}
    //public void SetTerget(TARGET[] _target)
    //{
    //    targetTag = _target;
    //}

    /// <summary>
    /// getter & setter
    /// </summary>
    public TITLES Title             { get { return this.newsTitle; }    set { this.newsTitle = value; } }
    public string Text              { get { return this.newsText; }     set { this.newsText = value; } }
    public List<TARGET> Target      { get { return this.targetTag; }    set { this.targetTag = value; } }
    public NewsEffectBase Effect    { get { return this.newsEffect; }   set { this.newsEffect = value; } }


}
