////////////////////////
// 移動感想の移動関係 //
////////////////////////


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpressionController : MonoBehaviour
{
    ImpressionGenerate gen = new ImpressionGenerate();

    //Start is called before the first frame update
    void Start()
    {
        gen = gameObject.GetComponent<ImpressionGenerate>();
        if (gen.GenerateImpression(0)) { Debug.Log("生成"); }
        else { Debug.Log("失敗"); }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
