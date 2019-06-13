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
    public List<Shared.ImpressTag> tags;

    bool tag_view_flag = false;

    public string Text { get { return text; } set { text = value; } }
    public List<Shared.ImpressTag> Tags { get { return tags; } set { tags = value; } }
    public bool TagViewFlag { get { return tag_view_flag; } set { tag_view_flag = value; } }




}

