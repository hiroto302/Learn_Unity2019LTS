using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddEvents : MonoBehaviour
{
    // eventを追加するクラス

    void Start()
    {
        Events.actionClick += AddActionClick;
    }

    public void AddActionClick()
    {
        Debug.Log("追加されたのじゃ");
    }
}
