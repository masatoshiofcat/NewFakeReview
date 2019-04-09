using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ニュースの効果をつけるための基底クラス
/// </summary>

public abstract class NewsEffectBase : ScriptableObject
{
    /// <summary>
    /// ニュースの効果を記述する
    /// </summary>
    public abstract void Effect();
}
