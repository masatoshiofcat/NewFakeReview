///ニュースを動的に生成するクラス
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewsGenerator : MonoBehaviour
{
    GameObject news;

    [SerializeField]
    NewsDataBase effectDataBase;

    private List<NewsData> newsDatas = new List<NewsData>();
    // Start is called before the first frame update
    void Start()
    {
        newsDatas = effectDataBase.DataBase;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
