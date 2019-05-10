using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectFunction : MonoBehaviour
{
    public void DestoryThisObject()
    {
        GameObject.Destroy(gameObject);
    }
}
