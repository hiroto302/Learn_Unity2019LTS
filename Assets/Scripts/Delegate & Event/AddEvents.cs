using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddEvents : MonoBehaviour
{
    // even tを追加するクラス

    void Start()
    {
        Events.actionClick += AddActionClick;
    }

    public void AddActionClick()
    {
        Debug.Log("追加されたのじゃ");
    }
}
