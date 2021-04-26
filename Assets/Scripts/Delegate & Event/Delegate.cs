using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delegate : MonoBehaviour
{
    // デリゲート宣言 void型 引数あり
    public delegate void ChangeColor(Color newColor);
    public ChangeColor onColorChange;

    // Delegate ReturnType
    public delegate int CharacterLength(string text);
    CharacterLength c1;

    //

    void Start()
    {
        onColorChange = UpdateColor; // 格納
        onColorChange(Color.green);  // 実行

        c1 = GetCharacters;
        Debug.Log(c1("HIRO302") + " : CharacterLength");


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
