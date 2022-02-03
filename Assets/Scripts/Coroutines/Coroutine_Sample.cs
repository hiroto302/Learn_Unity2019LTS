using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*  コルーチンについて検証する
    コルーチンの戻り値の型 は IEnumerator : Unityプログラミングで用いられる非同期処理を行うために用いるデータ型の一種
    コルーチンでは yieldステートメント を使用して実行中のコードを一時停止
    関数を中断させたい地点で yield return というキーワードで始める
    Yield はメソッドが iterator (集合から次々に要素を抽出する行為を一般化したもの)であり、複数のフレームにわたって実行されることを示す。
    一方 return は通常の関数と同様、その時点で実行を終了し、呼び出し側のメソッドに制御を戻す。
*/
public class Coroutine_Sample : MonoBehaviour
{

    void Start()
    {
        // StartCoroutine("FrameRoutine");
        StartCoroutine(SecondRoutine());
    }


    IEnumerator FrameRoutine()
    {
        Debug.Log("Start FrameRoutine : " + Time.time);
        int i = 0;
        Debug.Log("Start i count");
        while(i < 10)
        {
            Debug.Log(i);
            i++;
            // wait until the next frame
            yield return null;
        }
        Debug.Log("End i count");
    }

    IEnumerator SecondRoutine()
    {
        // timeScale が 1.0 のとき、時間は実時間と同じ速さ。timeScale が 0.5 の場合、時間は実時間の 2 倍の速度で経過
        // Time.time は timeSale に依存していることに注意
        // Time.timeScale = 0.5f;
        Debug.Log("Start SecondRoutine : " + Time.realtimeSinceStartup);
        // wait for a period of time
        yield return new WaitForSeconds(2.0f);
        Debug.Log("End WaitForSeconds(2.0f) : " + Time.realtimeSinceStartup);
        // which uses unscaled time
        // 1秒待機
        yield return new WaitForSecondsRealtime(2.0f);
        Debug.Log("End WaitRealForSeconds(2.0f) : " + Time.realtimeSinceStartup);
    }
}

