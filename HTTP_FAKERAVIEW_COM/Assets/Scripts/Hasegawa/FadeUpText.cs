using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// フェードアウトしながら上昇していくテキストのためのスクリプト
/// </summary>
public class FadeUpText : MonoBehaviour
{
    //色の減少の大きさ
    [SerializeField]
    private float alphaSpeed=0.1f;
    //移動速度
    [SerializeField]
    private Vector3 velocity;

    private Text textComponent;
    //現在のアルファ値
    private float currentAlpha=1.0f;

    // Start is called before the first frame update
    void Start()
    {
        this.textComponent = GetComponent<Text>();
        //最初は表示
        this.textComponent.color = new Color(1, 1, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        //上昇
        transform.localPosition += velocity;

        //色の更新(フェードアウト)
        this.currentAlpha -= this.alphaSpeed;
        this.textComponent.color = new Color(1, 1, 1, currentAlpha);
        //表示されなくなったら消滅
        if (this.currentAlpha <= 0) Destroy(gameObject);

    }

    public void SetText(string str)
    {
        textComponent.text = str;
    }
}
