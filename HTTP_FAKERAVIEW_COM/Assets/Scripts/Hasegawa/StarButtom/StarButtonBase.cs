using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarButtonBase : MonoBehaviour
{
    [SerializeField]
    private int reviewAffect;//どれだけ売れやすくなるか

    private int continuePushCount;//押された数をカウント

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    /// <summary>
    /// レビューによってどれだけ商品が売れやすくなるかの取得
    /// </summary>
    /// <returns></returns>
    public int GetReviewAffect()
    {
        return this.reviewAffect;
    }


}
