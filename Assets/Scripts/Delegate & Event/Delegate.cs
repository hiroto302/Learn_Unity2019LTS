using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delegate : MonoBehaviour
{
    // デリゲート宣言 void型 引数あり
    public delegate void ChangeColor(Color newColor);
    // 上記で宣言したデリゲートのインスタンス変数
    public ChangeColor onColorChange;

    void Start()
    {
        onColorChange = UpdateColor; // 格納
        onColorChange(Color.green);  // 実行
    }

    // 引数に Color を要求するメソッド
    void UpdateColor(Color newColor)
    {
        Debug.Log("Change Color to" + newColor.ToString());
    }
}
