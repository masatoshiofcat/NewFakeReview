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

    public Text GenerateImpression(int _i)
    {
        Text obj = null;
        if (impression_text_prefab != null && db.Datas.Count > _i)
        {

            obj = Instantiate(impression_text_prefab) as Text;
            // 親をキャンバスに設定
            obj.transform.SetParent(canvas.transform, false);

            obj.GetComponent<Impression>().SetData(db.Datas[_i].Text, db.Datas[_i].Tags);

            obj.text = obj.GetComponent<Impression>().Text;

            obj.transform.position = new Vector2(Screen.width / 2, Screen.height / 4);

            return obj;

        }

        return obj;
    }
    
}
