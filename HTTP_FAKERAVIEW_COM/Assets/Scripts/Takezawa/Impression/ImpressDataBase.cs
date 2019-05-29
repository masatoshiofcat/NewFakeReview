////////////////////////
// 感想のデータベース //
////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;




[Serializable]
[CreateAssetMenu(fileName ="ImpressDataBase",menuName ="Impressions")]
public class ImpressDataBase :ScriptableObject
{
    // 感想を保存
    public List<ImpressionData> impress_datas = new List<ImpressionData>();

    public List<ImpressionData> Datas { get { return impress_datas; } }
    public void AddImpression() { impress_datas.Add(null); }
    public void AddImpression(ImpressionData _add) { impress_datas.Add(_add); }
}
