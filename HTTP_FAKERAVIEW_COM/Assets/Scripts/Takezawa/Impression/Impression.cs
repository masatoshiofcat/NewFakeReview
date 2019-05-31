//////////
// 感想 //
//////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Impression : MonoBehaviour
{
    public string text = "";

    public List<Shared.ImpressTag> tags = new List<Shared.ImpressTag>();
    bool tag_flag = false;

    private void Start()
    {

    }

    private void Update()
    {

    }

    public void SetData(string _text, List<Shared.ImpressTag> _tags) { text = _text;tags = _tags; } 
    public string Text { get { return text; } set { text = value; } }
    public List<Shared.ImpressTag> Tags { get { return tags; } set { tags = value; } }
    public bool TagViewFlag { get { return tag_flag; } set { tag_flag = value; } }
    public void AddTags(Shared.ImpressTag tag) { tags.Add(tag); }
}
