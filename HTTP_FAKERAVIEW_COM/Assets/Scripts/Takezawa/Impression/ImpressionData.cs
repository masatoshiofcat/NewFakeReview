using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

[Serializable]
[CreateAssetMenu(fileName = "ImpressData", menuName = "Impress")]
public class ImpressionData : ScriptableObject
{
    // 表示させる文字
    public string text;
    public List<Shared.Tags> tags;

    bool tag_view_flag = false;

    public string Text { get { return text; } set { text = value; } }
    public List<Shared.Tags> Tags { get { return tags; } set { tags = value; } }
    public bool TagViewFlag { get { return tag_view_flag; } set { tag_view_flag = value; } }


#if UNITY_EDITOR
    // Inspector拡張

    [CustomEditor(typeof(ImpressionData))]
    public class ImpressionDataEditor : Editor
    {
        bool tags_flag = false;
        SerializedProperty string_property;
        SerializedProperty list_property;


        private void OnEnable()
        {
            string_property = serializedObject.FindProperty("text");
            list_property = serializedObject.FindProperty("tags");

        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            ImpressionData id = target as ImpressionData;
            List<Shared.Tags> tags = id.Tags;

            EditorGUILayout.LabelField("感想");
            string_property.stringValue = EditorGUILayout.TextArea(string_property.stringValue);

            EditorGUILayout.BeginHorizontal();      // 開始
            tags_flag = EditorGUILayout.Foldout(tags_flag, "タグ設定");
            //追加ボタンを作る
            if (GUILayout.Button("タグ追加"))
            {
                list_property.InsertArrayElementAtIndex(list_property.arraySize);

            }
            EditorGUILayout.EndHorizontal();        // 終了
            if (tags_flag)
            {
                for (int i = 0; i < id.tags.Count; i++)
                {
                    EditorGUILayout.BeginHorizontal();      // 開始
                    list_property.GetArrayElementAtIndex(i).enumValueIndex = (int)(Shared.Tags)EditorGUILayout.EnumPopup("タグ", (Shared.Tags)Enum.GetValues(typeof(Shared.Tags)).GetValue(list_property.GetArrayElementAtIndex(i).enumValueIndex));

                    EditorGUILayout.EndHorizontal();        // 終了
                }
                if (GUILayout.Button("削除"))
                {
                    list_property.DeleteArrayElementAtIndex(list_property.arraySize - 1);
                }
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
#endif
}

