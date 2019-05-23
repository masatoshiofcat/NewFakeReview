using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// GameObjectの拡張機能
/// </summary>
public class GameObjectFunction : MonoBehaviour
{
    public void DestoryThisObject()
    {
        GameObject.Destroy(gameObject);
    }
}
