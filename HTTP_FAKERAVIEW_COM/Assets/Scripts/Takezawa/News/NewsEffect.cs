using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// ニュースの効果を決める
/// </summary>

[Serializable]
[CreateAssetMenu(fileName = "effects", menuName = "EffectData")]
public class NewsEffect : NewsEffectBase
{
     public enum FLUCTUATION
    {
        NON,    // 変動なし
        UP,     // 上昇
        DOWN,   // 下降
    }


    // 変動(価格)
    [SerializeField]
    FLUCTUATION price=FLUCTUATION.NON;

    // 変動値
    [SerializeField]
    float flutuation = 0.0f;

    public override void Effect()
    {

    }

    // getter & setter
    public FLUCTUATION Price { get { return price; } set { price = value; } }
    public float Flutuation { get { return flutuation; } set { flutuation = value; } }

    }
