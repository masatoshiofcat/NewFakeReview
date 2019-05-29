using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpSprite : LerpObject
{
    private SpriteRenderer rendererComponent;
    private float spriteR, spriteG, spriteB;//スプライトの色


    // Start is called before the first frame update
    protected override void Start()
    {
        //初期座標の記録
        this.goalPosition = this.transform.position;
        //回転の記録
        this.goalRotation = this.transform.eulerAngles;
        //拡大率の記録
        this.goalScale = this.transform.localScale;
        currentState = LerpState.DISAPPER;
        //初期色の記憶
        rendererComponent = GetComponent<SpriteRenderer>();
        spriteR = rendererComponent.color.r;
        spriteG = rendererComponent.color.g;
        spriteB = rendererComponent.color.b;

        //最初は非表示
        rendererComponent.color = new Color(1, 1, 1, 0);
    }



    /// <summary>
    /// 補間移動する処理
    /// </summary>
    protected override  void ExecuteLerp() 
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


    /// <summary>
    /// 補間移動を開始する
    /// </summary>
    public override void StartLerp()
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

