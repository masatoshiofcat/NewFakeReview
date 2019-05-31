using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviewGenerator : SingletonMonoBehaviour<ReviewGenerator>
{
    [SerializeField]
    ImpressDataBase reviewDataBase;

    [SerializeField]
    ImpressionData tutrialReview;

    private List<ImpressionData> reviewList;//レビューリスト

    private void Awake()
    {
        //データベースからリストを生成
        this.reviewList = reviewDataBase.Datas;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// ランダムに一つレビューを生成する
    /// </summary>
    public void CreateReviewOneFromRandom()
    {
        var review = reviewList[Random.Range(0, reviewList.Count - 1)];
        if (review == null) Debug.Log("アッ");
        CompanyInfomation.Instance.SetCurrentImpression(review);
    }
    public void CreateTutrialReview()
    {
        CompanyInfomation.Instance.SetCurrentImpression(this.tutrialReview);
    }
}
