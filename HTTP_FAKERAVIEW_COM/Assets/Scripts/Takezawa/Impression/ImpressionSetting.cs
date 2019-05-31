using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImpressionSetting : MonoBehaviour
{
    GameObject my_child;
    Vector2 size;
    // Start is called before the first frame update
    void Start()
    {
        my_child = transform.GetChild(0).gameObject;
        size.x = my_child.GetComponent<Text>().preferredWidth;
        size.y = my_child.GetComponent<Text>().preferredHeight;
        Debug.Log(my_child.name);
        Debug.Log(size);
        Debug.Log("Width:" + size.x + "Height" + size.y);

        gameObject.GetComponent<RectTransform>().sizeDelta = size;
    }

    private void Update()
    {

        size.x = my_child.GetComponent<Text>().preferredWidth;
        size.y = my_child.GetComponent<Text>().preferredHeight;
        gameObject.GetComponent<RectTransform>().sizeDelta = size;
    }
}
