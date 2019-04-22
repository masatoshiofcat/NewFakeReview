using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarButtonBase : MonoBehaviour
{
    [SerializeField]
    private int reviewAffect;//どれだけ売れやすくなるか
    [SerializeField]
    private float reviewPercent = 100.0f;//レビューの成功確率
    [SerializeField]
    private Text percentText;

    private int continuePushCount;//押された数をカウント

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //表示確率の更新
        this.percentText.text = Mathf.Floor(this.reviewPercent).ToString() + "%";
    }

    /// <summary>
    /// レビューによってどれだけ商品が売れやすくなるかの取得
    /// </summary>
    /// <returns></returns>
    public int GetReviewAffect()
    {
        return this.reviewAffect;
    }

    /// <summary>
    /// レビューの成功確率の取得
    /// </summary>
    /// <returns></returns>
    public float GetReviewPercent()
    {
        return this.reviewPercent;
    }

    /// <summary>
    /// レビュー成功確率の設定
    /// </summary>
    /// <param name="val"></param>
    public void SetReviewPercent(float val)
    {
        this.reviewPercent = val;
        //100%は超えない
        if (this.reviewPercent > 100.0f) this.reviewPercent = 100.0f;
        //1%より低くならない
        if (this.reviewPercent < 1.0f) this.reviewPercent = 1.0f;
    }
    /// <summary>
    /// レビュー成功確率の設定
    /// </summary>
    /// <param name="val"></param>
    public void AddReviewPercent(float val)
    {
        this.reviewPercent += val;
        //100%は超えない
        if (this.reviewPercent > 100.0f) this.reviewPercent = 100.0f;
        //1%より低くならない
        if (this.reviewPercent < 1.0f) this.reviewPercent = 1.0f;

    }

    /// <summary>
    /// 連続して押された数の取得
    /// </summary>
    /// <returns></returns>
    public int GetContinuePushCount()
    {
        return this.continuePushCount;
    }

    /// <summary>
    /// 連続して押された数の設定
    /// </summary>
    /// <param name="val"></param>
    public void SetContinuePushCount(int val)
    {
        this.continuePushCount = val;
    }
}
