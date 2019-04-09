using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// ニュースの基底クラス。
/// ニュースを作成するにはこれを継承したオブジェクトを生成する必要がある。
/// </summary>

abstract public class NewsBase : MonoBehaviour
{
    // ニュースタイトル
    [SerializeField]
    private string newsTitle;

    // ニュース本文
    [SerializeField]
    private string newsText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
