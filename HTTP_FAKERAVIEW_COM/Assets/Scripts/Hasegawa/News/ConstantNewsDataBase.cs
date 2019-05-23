using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ConstantNewsDataBase", menuName = "CreateNewsDataBase")]
/// <summary>
/// 恒常的に流れるニュースのデータベース
/// </summary>
public class ConstantNewsDataBase : ScriptableObject
{
    [SerializeField]
    private List<NewsData> newsDataList = new List<NewsData>();

    /// <summary>
    /// 恒常ニュースをランダムに一つ取得する
    /// </summary>
    /// <returns></returns>
    public NewsData GetAConstantNewsFromRandom()
    {
        int ran = Random.Range(0, this.newsDataList.Count);

        return this.newsDataList[ran];
    }

    /// <summary>
    /// 恒常ニュースのデータリストを返す
    /// </summary>
    /// <returns></returns>
    public List<NewsData> GetConstantNewsDataList()
    {
        return this.newsDataList;
    }
}
