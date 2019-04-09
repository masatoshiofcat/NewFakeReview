using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// ニュースデータインスペクター拡張クラス
/// </summary>

[CustomEditor(typeof(NewsData))]
public class NewsDataInspectorExpansion : Editor
{
    bool folding = false;
    public override void OnInspectorGUI()
    {

        NewsData data = target as NewsData;

        // タイトル
        data.Title = (NewsData.TITLES)EditorGUILayout.EnumPopup("Title", data.Title);

        // 本文
        EditorGUILayout.LabelField("Text");
        data.Text = (string)EditorGUILayout.TextField(data.Text);

        // ターゲット
        // 折り畳み表示
        if (folding = EditorGUILayout.Foldout(folding, "Target"))
        {
            // リストの表示
            for (int i = 0; i < data.Target.Count; i++)
            {
                data.Target[i] = (NewsData.TARGET)EditorGUILayout.EnumPopup(data.Target[i]);
            }
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("ターゲット追加"))
            {
                NewsData.TARGET add = NewsData.TARGET.NON;
                data.Target.Add(add);
            }
            if (GUILayout.Button("ターゲット削除"))
            {
                data.Target.RemoveAt(data.Target.Count - 1);
            }
            EditorGUILayout.EndHorizontal();
        }

        // エフェクトを選択
        data.Effect = (NewsEffect)EditorGUILayout.ObjectField("NewsEffect", data.Effect, typeof(NewsEffect), true) as NewsEffect;
    }
}
