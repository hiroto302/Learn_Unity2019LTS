using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Funcs : MonoBehaviour
{
    // <引数, 返り値>
    public Func<string, int> func1;
    // 引数なし <返り値>
    public Func<int> func2;

    void Start()
    {
        // Lambda
        // (引数) => 返り値
        func1 = (name) => name.Length;
        Debug.Log(func1("HIRO") + ": func1 name.Length");
        // 引数なし
        func2 = () => 777;
        Debug.Log("今日の運勢 : " + func2());
    }
}
