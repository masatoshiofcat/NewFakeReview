using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewsGenerator : SingletonMonoBehaviour<NewsGenerator>
{
    [SerializeField]
    private ConstantNewsDataBase constantNewsDataBase;//恒常ニュースのデータベース

    [SerializeField]
    private NewsBase newsFrame;//ニュースのひな型

    [SerializeField]
    private CardBase reviewdCardBase;//レビューした商品を表すためのひな型

    [SerializeField]
    private Vector3 createPosition;//ニュースの生成位置
    [SerializeField]
    private Vector3 newsFarstLerpedPosition;//最初のニュースの補間後の位置

    [SerializeField]
    private Vector3 newsOffest = new Vector3(0, 10, 0);

    [SerializeField]
    private float NEWS_INTERVAL = -30;//他ニュースとどれだけ離れるか

    List<NewsBase> newsListInShown = new List<NewsBase>();//表示しているニュースのリスト

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    /// <summary>
    /// ニュースを生成する
    /// </summary>
    void CreateNews()
    {

    }

    /// <summary>
    /// レビュー評価を作成する
    /// </summary>
    public void CreateReviewEvalution(string yourReview,int customer,CardBase productCard)
    {
        //ニュースの生成
        var news = Instantiate(this.newsFrame);

        //ワールド座標のキャンバスに生成
        news.transform.SetParent(gameObject.transform);
        //ニュースの座標の設定
        news.transform.localPosition = this.createPosition;
        //ニュースを等倍に調整
        news.transform.localScale = new Vector3(1, 1, 1);
        //ニュースパラメータの設定
        news.SetHeadText("あなたのレビュー：");
        news.SetReviewComment(yourReview);
        news.SetBodyText(customer.ToString()+"人がこれを見て購入しました。\n");
        news.SetLerpGoalPosition(this.newsFarstLerpedPosition);
        //利益を計算し、マージンに加える
        CompanyInfomation.Instance.AddCompanyMargin(productCard.GetPrice() * customer);


        //商品カードを生成する
        var card = Instantiate(this.reviewdCardBase);
        card.SetNameText(productCard.GetNameString());
        card.SetCardEffectText(productCard.GetCardBodyText());
        card.SetMouseOverText(productCard.GetMouseOverText());
        card.SetCardIconImage(productCard.GetCardIconTex());



        //ニュースにそれを張り付ける
        card.transform.SetParent(news.transform);
        card.transform.localPosition = this.newsOffest;

        //全てのニュースをせり上げる
        this.UpNews(news.GetComponent<RectTransform>().sizeDelta.y+this.NEWS_INTERVAL);

        //管理リストに登録
        this.newsListInShown.Add(news);

    }

    /// <summary>
    /// 表示している全てのニュースをせり上げ始めさせる
    /// </summary>
    /// <param name="height"></param>どのくらい上げるか
    private void UpNews(float height)
    {
        for(int i=0;i<this.newsListInShown.Count;i++)
        {
            NewsBase news = this.newsListInShown[i];
            news.SetLerpGoalPosition(news.GetLerpGoalPosition() + new Vector3(0, height, 0) );
        }
    } 

}
