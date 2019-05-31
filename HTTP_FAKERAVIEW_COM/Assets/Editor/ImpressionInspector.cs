using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;

using UnityEngine.UI;


/// <summary>
/// インスペクタ―拡張クラス(スクリプト)
/// </summary>

[CustomEditor(typeof(ImpressDataBase))]                 // 拡張するときのお約束
public class ImpressionInspector : Editor               // Editorを継承
{
    bool data_flag = false;
    ImpressionData add = null;
    SerializedProperty list_datas;
    SerializedProperty add_data;

    private void OnEnable()
    {

        list_datas = serializedObject.FindProperty("impress_datas");

    }

    string text = "";
    public override void OnInspectorGUI()
    {
        ImpressDataBase db = target as ImpressDataBase;
        serializedObject.Update();

        ImpressionData add = null;
        add = (ImpressionData)EditorGUILayout.ObjectField("追加するもの", add, typeof(ImpressionData), true);

        if(add!=null)
        {
            db.AddImpression(add);
            add = null;
        }
        if (GUILayout.Button("リストの追加"))
        { 
            db.AddImpression();
        }
        // 登録されているデータ一覧
        if (data_flag = EditorGUILayout.Foldout(data_flag, "データ一覧"))
        {
            // リストを表示
            for (int i = 0; i < list_datas.arraySize; ++i)
            {
                EditorGUILayout.BeginHorizontal();      // 開始


                //list_datas.GetArrayElementAtIndex(i).stringValue = GUILayout.TextArea(list_datas.GetArrayElementAtIndex(i).stringValue);

                //EditorGUILayout.LabelField(list_datas.GetArrayElementAtIndex(i).stringValue);

                EditorGUILayout.PropertyField(list_datas.GetArrayElementAtIndex(i));
                //data_list[i].Text = GUILayout.TextField(data_list[i].Text);
                if (GUILayout.Button("削除", GUILayout.Width(100), GUILayout.Height(20)))
                {
                    list_datas.DeleteArrayElementAtIndex(i);
                    continue;
                }
                EditorGUILayout.EndHorizontal();        // 終了
            }
        }
        if (GUILayout.Button("クリア"))
        {


            list_datas.ClearArray();
        }
        serializedObject.ApplyModifiedProperties();



    }
}
#endif