///ニュースのデータをまとめておくデータベースを作るためのクラス
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewsDataBase", menuName = "CreateNewsDataBase")]
public class NewsDataBase : ScriptableObject
{
    [SerializeField]
    private List<NewsData> newsDataList = new List<NewsData>();

    /// <summary>
    /// ニュースのデータリストの取得
    /// </summary>
    /// <returns></returns>
    public List<NewsData> GetNewsDataList()
    {
        return this.newsDataList;
    }

    public void PushNewsDataList(NewsData _newsData)
    {
        this.newsDataList.Add(_newsData);
    }

}
