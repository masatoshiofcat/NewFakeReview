using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImpressionGenerate : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.Text impression_text_prefab;
    [SerializeField]
    ImpressDataBase db;

    GameObject canvas;
    private void Awake()
    {
        canvas = GameObject.Find("Canvas");

    }
    private void Start()
    {
      
    }

    private void Update()
    {

    }

    public bool GenerateImpression(int _i)
    {
        

        if (impression_text_prefab != null && db.Datas.Count > _i)
        {

            Text text = Instantiate(impression_text_prefab) as Text;
            // 親をキャンバスに設定
            text.transform.SetParent(canvas.transform, false);
            
            text.GetComponent<Impression>().SetData(db.Datas[_i].Text, db.Datas[_i].Tags);

            text.text = text.GetComponent<Impression>().Text;

            text.transform.position = new Vector2(Screen.width / 2, Screen.height / 4);
            return true;

        }

        return false;
    }
    
}
