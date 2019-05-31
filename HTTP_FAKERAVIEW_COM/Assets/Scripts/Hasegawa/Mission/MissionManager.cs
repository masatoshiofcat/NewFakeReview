using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionManager : SingletonMonoBehaviour<MissionManager>
{

    [SerializeField]
    private GameObject checkMissionCleard;//ミッションを達成した時出るチェックマーク 

    [SerializeField]
    private Text nextMarginText;//利益用のテキストオブジェクト

    [SerializeField]
    private Text reviewdCountText;//レビューした回数を出すためのテキストオブジェクト

    [SerializeField]
    private int nextGoalMargin;//次に出すべき利益

    [SerializeField]
    private float rewardMagni = 1.0f; //報酬の大きさ

    [SerializeField]

    private int currentReviwedCount;//レビューした回数
    private int nextReviwedCount=1;//レビュするべき回数


    private CompanyInfomation company;

    // Start is called before the first frame update
    void Start()
    {
        company = CompanyInfomation.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        //任務達成処理
        if (company.GetCompanyMargin() >= this.nextGoalMargin) CompleateMarginMission();
        if (this.currentReviwedCount >= nextReviwedCount) this.CompleateReviewCountMission();



        //テキストの更新
        this.UpdateText();
    }

    /// <summary>
    /// テキスト描画の更新
    /// </summary>
    private void UpdateText()
    {
        this.nextMarginText.text = nextGoalMargin.ToString() + "円";

        this.reviewdCountText.text = currentReviwedCount.ToString() + "/"+ this.nextReviwedCount.ToString(); 
    }

    /// <summary>
    /// 利益任務を達成した時の処理
    /// </summary>
    private void CompleateMarginMission()
    {
        //checkの生成
        var check = Instantiate(this.checkMissionCleard, this.nextMarginText.transform);
        check.transform.position = Vector3.zero;

        //任務報酬
        float temp = (float)nextGoalMargin;
        temp =(temp * 1.5f) / temp;
        temp *= rewardMagni;
        company.AddDayleft((int)temp);

        //任務更新
        float nextGoalTmp = nextGoalMargin * 1.5f;
        nextGoalMargin = (int) nextGoalTmp;

    }

    private void CompleateReviewCountMission()
    {
        //checkの生成
        var check = Instantiate(this.checkMissionCleard, this.reviewdCountText.transform);
        check.transform.position = Vector3.zero;

        //任務報酬
        company.AddDayleft(1+this.nextReviwedCount / 2);

        //任務更新
        this.nextReviwedCount = (this.nextReviwedCount +Random.Range(0,3)) *2;

        //チュートリアル
        if (this.currentReviwedCount == 1) NewsGenerator.Instance.CompleateTutrial();
    }

    /// <summary>
    /// レビューした回数をカウントアップする
    /// </summary>
    public void CountReview()
    {
        this.currentReviwedCount++;
    }



}
