using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CallBackSystem : MonoBehaviour
{
    void Start()
    {
        Action action1 = () => Debug.Log("My Action1");

        StartCoroutine(MyRoutine(action1));

        StartCoroutine(MyRoutine(() => {
            Debug.Log("The routine has finished");
        }));
    }

    // 一定時間後に引数のActionを実行するコールバック
    public IEnumerator MyRoutine(Action onComplet = null)
    {
        yield return new WaitForSeconds(3.0f);
        if(onComplet != null)
        {
            onComplet();
        }
    }
}
