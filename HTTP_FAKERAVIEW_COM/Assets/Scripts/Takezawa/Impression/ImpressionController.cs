////////////////////////
// 移動感想の移動関係 //
////////////////////////


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImpressionController : MonoBehaviour
{
    ImpressionGenerate gen = new ImpressionGenerate();
    // 登録している感想の数
   　public const int MAX_IMP_NUM = 2;
    // 表示する感想の配列
    Text[] impressions = new Text[2];
    //Start is called before the first frame update
    void Start()
    {
        gen = gameObject.GetComponent<ImpressionGenerate>();

        int j = 0;
        while (j < impressions.Length)
        {
            int i = (int)Random.Range(0, MAX_IMP_NUM);
            impressions[j] = gen.GenerateImpression(i);
            if (impressions[j] == null) { Debug.Log("生成"); }
            else { Debug.Log("失敗"); continue; }
            j++;
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
