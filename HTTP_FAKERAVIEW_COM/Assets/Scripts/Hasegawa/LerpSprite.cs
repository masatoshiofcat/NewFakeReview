using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpSprite : MonoBehaviour
{
    enum LerpState
    {
        DISAPPER,//非表示
        LERPING//補間中
    }

    [SerializeField]
    private Vector3 startPosition;//最初の座標
    [SerializeField]
    private Vector3 startRotation;//最初の回転率
    [SerializeField]
    private Vector3 startScale;//最初の拡大率

    [SerializeField]
    private float lerpSpeed;//補間速度


    private Vector3 goalPosition;//シーンウィンドウ上での座標及び補間後の座標
    private Vector3 goalRotation;//シーンウィンドウ上での回転及び補間後の回転
    private Vector3 goalScale;//シーンウィンドウ上での拡大率及び補間後の拡大率
    private SpriteRenderer rendererComponent;
    private float spriteR, spriteG, spriteB;//スプライトの色

    //現在の状態
    LerpState currentState;

    // Start is called before the first frame update
    void Start()
    {
        //初期座標の記録
        this.goalPosition = this.transform.position;
        //初期色の記憶
        rendererComponent = GetComponent<SpriteRenderer>();
        spriteR = rendererComponent.color.r;
        spriteG = rendererComponent.color.g;
        spriteB = rendererComponent.color.b;
        //回転の記録
        this.goalRotation = this.transform.eulerAngles;
        //拡大率の記録
        this.goalScale = this.transform.localScale;

        //最初は非表示
        rendererComponent.color = new Color(1, 1, 1, 0);
        currentState = LerpState.DISAPPER;
    }

    // Update is called once per frame
    void Update()
    {
        switch(currentState)
        {
            case LerpState.DISAPPER:
                this.ExecuteDisapper();
                break;
            case LerpState.LERPING:
                this.ExecuteLerp();
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 補間移動する処理
    /// </summary>
    private void ExecuteLerp()
    {
        //速度の算出
        float step = Time.deltaTime * this.lerpSpeed;
        //移動する
        this.transform.position = Vector3.Lerp(this.transform.position, this.goalPosition, step);
        //回転の保管
        this.transform.eulerAngles = Vector3.Lerp(this.transform.eulerAngles, this.goalRotation, step);
        //拡大の補間
        this.transform.localScale = Vector3.Lerp(this.transform.localScale, this.goalScale, step);
        //色の保管
        this.rendererComponent.color = Color.Lerp(this.rendererComponent.color, new Color(spriteR, spriteG, spriteB, 1),step);
    }

    private void ExecuteDisapper()
    {

    }

    /// <summary>
    /// 補間移動を開始する
    /// </summary>
    public void StartLerp()
    {
        //表示する
        this.rendererComponent.color = new Color(spriteR, spriteG, spriteB, 0);
        //開始時の状態に変化
        this.transform.position = this.startPosition;
        this.transform.eulerAngles = this.startRotation;
        this.transform.localScale = this.startScale;

        this.currentState = LerpState.LERPING;
    }

}

