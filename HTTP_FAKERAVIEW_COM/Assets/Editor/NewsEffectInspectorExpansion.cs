using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// ニュース効果インスペクタ―拡張クラス
/// </summary>

[CustomEditor(typeof(NewsEffect))]
public class NewsEffectInspectorExpansion : Editor
{
    bool folding = false;
    public override void OnInspectorGUI()
    {
        NewsEffect effect = target as NewsEffect;


        // 価格
        effect.Price = (NewsEffect.FLUCTUATION)EditorGUILayout.EnumPopup("ニュース効果(価格変動)", effect.Price);
        if (effect.Price != NewsEffect.FLUCTUATION.NON)
        {
            effect.Flutuation = EditorGUILayout.FloatField("変動値", effect.Flutuation);
        }
    }
}

