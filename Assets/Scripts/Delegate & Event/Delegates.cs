using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;       // For Action &

public class Delegates : MonoBehaviour
{
    // デリゲート宣言 void型 引数あり
    public delegate void ChangeColor(Color newColor);
    public ChangeColor onColorChange;

    // Action<引数, 引数, ...> : Void型 デリゲート・変数を同時に宣言する
    public Action<Color> changeColor;


    // Delegate ReturnType
    public delegate int CharacterLength(string text);
    CharacterLength c1;

    // Func<引数, 返り値> : ReturnType デリゲート・変数と同時に宣言する
    public Func<string, int> c2;

    void Start()
    {
        onColorChange = UpdateColor; // 格納
        onColorChange(Color.green);  // 実行

        changeColor = UpdateColor;
        changeColor(Color.black);

        c1 = GetCharacters;
        Debug.Log(c1("HIRO302") + " : CharacterLength1");

        c2 = GetCharacters;
        Debug.Log(c2("HIRO") + " : CharacterLength2");


    }

    // 引数に Color を要求するメソッド
    void UpdateColor(Color newColor)
    {
        Debug.Log("Change Color to" + newColor.ToString());
    }
    // Return Type int
    int GetCharacters(string name)
    {
        return name.Length;
    }
}
