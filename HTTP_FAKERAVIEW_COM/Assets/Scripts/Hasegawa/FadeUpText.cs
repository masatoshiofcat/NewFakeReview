using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// フェードアウトしながら上昇していくテキストのためのスクリプト
/// </summary>
public class FadeUpText : MonoBehaviour
{
    enum FadeUpState
    {
        DISAPPER,//非表示
        RISING,//表示・上昇中
    }


    //色の減少の大きさ
    [SerializeField]
    private float alphaSpeed=0.1f;
    //移動速度
    [SerializeField]
    private Vector3 velocity;

    //テキスト
    private Text textComponent;
    //初期位置
    private Vector3 firstPosition;

    //現在のアルファ値
    private float currentAlpha=1.0f;
    private Vector3 firstRGB;//初期カラー
    //現在の状態
    private FadeUpState currentState;

    // Start is called before the first frame update
    void Start()
    {
        this.textComponent = GetComponent<Text>();

        //初期位置の記憶
        this.firstPosition = transform.position;
        //色の記憶
        this.firstRGB = new Vector3(this.textComponent.color.r, this.textComponent.color.g, this.textComponent.color.b);

        //最初は非表示
        this.textComponent.color = new Color(1, 1, 1, 0);
        this.currentState = FadeUpState.DISAPPER;
    }

    // Update is called once per frame
    void Update()
    {
        //現在の状態による処理
        switch(this.currentState)
        {
            case FadeUpState.DISAPPER:
                this.ExecuteDisapper();
                break;
            case FadeUpState.RISING:
                this.ExecuteRising();
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 非表示状態の処理
    /// </summary>
    private void ExecuteDisapper()
    {

    }

    /// <summary>
    /// 上昇中の処理
    /// </summary>
    private void ExecuteRising()
    {
        //上昇する
        transform.localPosition += velocity;

        //色の更新(フェードアウト)
        this.currentAlpha -= this.alphaSpeed;
        this.textComponent.color = new Color(this.firstRGB.x, this.firstRGB.y, this.firstRGB.z, currentAlpha);
        //表示されなくなったら消滅
        if (this.currentAlpha <= 0) Disapper();

    }


    /// <summary>
    /// 描画するテキストの設定
    /// </summary>
    /// <param name="str"></param>
    public void SetText(string str)
    {
        if (this.textComponent == null) this.textComponent = GetComponent<Text>();
        textComponent.text = str;
    }

    /// <summary>
    /// 上昇開始させる
    /// </summary>
    public void StartRising()
    {
        //テキストを表示する
        this.textComponent.color = new Color(this.firstRGB.x, this.firstRGB.y, this.firstRGB.z, 1);
        this.currentAlpha = 1.0f;
        //初期座標に
        this.transform.position = firstPosition;
        this.currentState = FadeUpState.RISING;
    }

    /// <summary>
    /// テキストを非表示する
    /// </summary>
    public void Disapper()
    {
        this.textComponent.color = new Color(1, 1, 1, 0);
        this.currentState = FadeUpState.DISAPPER;
    }

}
