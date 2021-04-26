using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// event について
public class Human : MonoBehaviour
{
    // Human が死んだときの処理を格納
    // 死のイベントが発生した時に、他のクラスが 死んだ Human にどのような処理を行うか記述できるようにするための delegate
    public delegate void OnDeath(Human human);
    // public static event にすることで, 他のクラスでも onDeath に処理を追加できるが、処理を実行することはできないようにする
    public static event OnDeath onDeath;

    // 年齢
    public int age = 70;

    void Update()
    {
        if(Input.anyKeyDown)
        {
            age += 10;
            if(age >= 100)
            {
                // 100を超えたら死ぬ
                Death();
            }
        }
    }

    void Death()
    {
        // 死んだ時の event 発生
        onDeath(this);
    }
}
