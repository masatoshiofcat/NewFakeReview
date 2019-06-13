using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleSceneComment : MonoBehaviour
{
    enum State
    {
        DISSAPEAR,
        APPEAR,
    }


    [SerializeField]
    Text textObject;

    [SerializeField,Multiline(3)]
    string[] textStr;

    [SerializeField]
    float apperTime = 6;

    [SerializeField]
    float fadeSpeed = 1.0f;


    private float currentTimeCount;
    private float currentAlpha;
    private void Start()
    {
        currentAlpha = 0.0f;
        this.textObject.color = new Color(1, 1, 1, currentAlpha);
        this.textObject.text = this.textStr[Random.Range(0, textStr.Length-1)];
    }
    // Update is called once per frame
    void Update()
    {
        if(currentTimeCount > this.apperTime)
        {
            this.currentAlpha -= Time.deltaTime * fadeSpeed;
            if (currentAlpha < 0.0f) this.currentAlpha = 0.0f;

        }
        else
        {
            this.currentAlpha += Time.deltaTime * fadeSpeed;
            if (currentAlpha > 1.0f) this.currentAlpha = 1.0f;
        }

        if(currentAlpha <= 0)
        {

            this.textObject.text = this.textStr[Random.Range(0, textStr.Length - 1)];
            this.currentTimeCount = 0;
        }

        this.textObject.color = new Color(1, 1, 1, currentAlpha);
        this.currentTimeCount += Time.deltaTime;
    }
}
