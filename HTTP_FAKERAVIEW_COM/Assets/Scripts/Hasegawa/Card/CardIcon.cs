using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardIcon : MonoBehaviour
{
    [SerializeField]
    Text mouseOverText; //マウスが上に乗った時表示されるヒント

    // Update is called once per frame
    void Update()
    {
        //マウスと接触しているかの判定
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hitData = Physics2D.Raycast(ray.origin, ray.direction, 100f);
 
        //マウスと重なっているときのみヒントを表示する
        if (hitData)
        {
            if (hitData.collider.gameObject == gameObject)
            {
                this.mouseOverText.enabled = true;
            }
        }
        else
        {
            this.mouseOverText.enabled = false;

        }

    }
}
