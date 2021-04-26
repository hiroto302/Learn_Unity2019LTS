using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Actions : MonoBehaviour
{
    // 引数あり Action
    public Action<int, int> sum;
    public Action<int, int> sum2;

    // 引数なし Action
    public Action onGetName;

    void Start()
    {
        // 従来の方法 : Action・変数宣言 作成してあるMethodを代入
        sum = CalculationSum;
        sum(1,2);

        // Lambda を利用した方法 : 変数にLambda式を利用してMethodを作成し、そのまま代入出来る
        // Method を別に用意しなくても記述できるという利点
        // Delegate = (引数, ...) => 返り値
        sum2 = (a, b) =>
        {
            var total = a +b;
            Debug.Log("Sum2 : " + total);
        };

        // 引数なしの Action を Lambda を利用して宣言する方法 エラーで、ActionはDelegateType ではないとでる,なぜ？
        // クラス名を 「Action」にしてる！？
        // クラス名をつける時は気をつけろよ!!!!!!
        onGetName = () => Debug.Log("GameObjectName = " + this.gameObject.name);
        onGetName();
    }
    void CalculationSum(int a, int b)
    {
        var total = a + b;
        Debug.Log("Sum : " + total);
    }
}

