using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// 全てのNewsオブジェクトが持つコンポーネント
/// </summary>
public class NewsBase : MonoBehaviour
{
    [SerializeField]
    float lerpSpeed;
    [SerializeField]
    float maxHeight;//表示する高さ制限

    private Text newsHeadText;//ニュースのタイトル用テキストオブジェクト
    private Text newsBodyText;//ニュースの本文用テキストオブジェクト
    private Text reviewText;//レビューを記述するためのテキストオブジェクト

    private Vector3 goalPosition;//補間移動用の座標
    private CanvasGroup canvasGroup;//ニュースをフェードアウトさせるためのコンポーネント
    // Start is called before the first frame update
    void Awake()
    {
        this.newsHeadText = transform.Find("NewsHeadText").GetComponent<Text>();
        this.newsBodyText = transform.Find("NewsBodyText").GetComponent<Text>();
        this.reviewText = transform.Find("ReviewComment").GetComponent<Text>();
        //コンポーネントの取得
        this.canvasGroup = GetComponent<CanvasGroup>();
        //登場のアニメーションを行う

    }

    // Update is called once per frame
    void Update()
    {
        float step = Time.deltaTime * this.lerpSpeed;
        //移動する
        this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, this.goalPosition, step);
        Debug.Log("pos="+transform.position);
 //       Debug.Log("goal=" + this.goalPosition);
        //高さ制限を超えたらフェードアウトする
        if(GetComponent<RectTransform>().position.y > this.maxHeight)
        {
            this.canvasGroup.alpha -= Time.deltaTime * lerpSpeed;
            if (this.canvasGroup.alpha <= 0) GameObject.Destroy(gameObject);
        }

    }

    //テキストオブジェクトへのアクセス
    public Text GetNewsHeadText()
    {
        return this.newsHeadText;
    }

    public Text GetNewsBodyText()
    {
        return this.newsBodyText;
    }
    public Text GetReviewText()
    {
        return this.reviewText;
    }

    //テキストの変更
    public void SetHeadText(string str)
    {
        this.newsHeadText.text = str;
    }

    public void SetBodyText(string str)
    {
        this.newsBodyText.text = str;
    }

    public void SetReviewComment(string str)
    {
        this.reviewText.text = str;
    }


    /// <summary>
    /// 補間の目標点の設定
    /// </summary>
    /// <param name="pos"></param>
    public void SetLerpGoalPosition(Vector3 pos)
    {
        this.goalPosition = pos;
    }

    public Vector3 GetLerpGoalPosition()
    {
        return this.goalPosition;
    }

}
