using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewsGenerator : SingletonMonoBehaviour<NewsGenerator>
{
    [SerializeField]
    private ConstantNewsDataBase constantNewsDataBase;//恒常ニュースのデータベース

    [SerializeField]
    private NewsBase reviewCommentFrame;//レビューに対する評価のひな型

    [SerializeField]
    private NewsBase newsFrame;//ニュースのひな型

    [SerializeField]
    private CardBase reviewdCardBase;//レビューした商品を表すためのひな型

    [SerializeField]
    private Vector3 createPosition;//ニュースの生成位置
    [SerializeField]
    private Vector3 newsFirstLerpedPosition;//最初のニュースの補間後の位置

    [SerializeField]
    private Vector3 newsOffest = new Vector3(0, 10, 0);

    [SerializeField]
    private float NEWS_INTERVAL = 30;//他ニュースとどれだけ離れるか

    [SerializeField]
    Sprite[] newsIconSprite;

    private List<NewsBase> newsListInShown = new List<NewsBase>();//表示しているニュースのリスト

    private List<NewsData> newsAbleApear;//恒常ニュース及び出てくる可能性のあるニュースのデータリスト

    // Start is called before the first frame update
    void Start()
    {
        //恒常ニュースの登録
        this.newsAbleApear = constantNewsDataBase.GetConstantNewsDataList();
    }

    // Update is called once per frame
    void Update()
    {

    }


    /// <summary>
    /// ニュースを生成する
    /// </summary>
    NewsBase CreateNews(string headStr,string bodyStr,NewsData.NewsKind newsKind, string reviewComment="",int frameId=0)
    {
        //ニュースオブジェクトの作成
        NewsBase newsCreating = new NewsBase();
        switch(frameId)
        {
            case 0:
                newsCreating = this.newsFrame;
                break;
            case 1:
                newsCreating= this.reviewCommentFrame;
                break;
            default:
                break;
        }
        NewsBase news= Instantiate(newsCreating);
        //ワールド座標のキャンバスに生成
        news.transform.SetParent(gameObject.transform);
        //ニュースの座標の設定
        news.transform.localPosition = this.createPosition;
        //ニュースを等倍に調整
        news.transform.localScale = new Vector3(1, 1, 1);
        //ニュースの補間先の設定
        news.SetLerpGoalPosition(this.newsFirstLerpedPosition);
        //ニュースのパラメータ設定
        news.SetHeadText(headStr);
        news.SetBodyText(bodyStr);
        news.SetReviewComment(reviewComment);

        //ニュースの種類からアイコン画像を決定
        news.SetNewsIcon(this.DecideNewsIconFromNewsKind(newsKind));

        //全てのニュースをせり上げる
        this.UpNews(news.GetComponent<RectTransform>().sizeDelta.y - this.NEWS_INTERVAL);

        //管理リストに登録
        this.newsListInShown.Add(news);

        return news;
    }


    /// <summary>
    /// ランダムにニュースをひとつ作成し表示する
    /// </summary>
    public void CreateConstantNewsOne()
    {

    }

    /// <summary>
    /// レビュー評価を作成する
    /// </summary>
    public void CreateReviewEvalution(string yourReview,int customer,CardBase productCard)
    {
        //ニュースの生成
        var news = CreateNews("あなたのレビュー:",customer.ToString()+"人がこれを見て購入しました。",NewsData.NewsKind.MONEY,yourReview,1);


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



    private Sprite DecideNewsIconFromNewsKind(NewsData.NewsKind kind)
    {
        return this.newsIconSprite[(int)kind];
    }
}
