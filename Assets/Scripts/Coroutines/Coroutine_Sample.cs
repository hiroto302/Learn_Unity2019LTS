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
        /* nameメソッドよりもstringメソッドを使用した方が若干パフォーマンスが上がるらしい。
            ただし、文字列を使用してコルーチンを開始する場合、パラメータを1つだけ渡すことが可能 */

        // 文字列でコルーチンを開始 (文字列実行する時、引数にデフォルト値を利用することを記述する方法があるのか探す.何も指定しないと引数を要求するエラーになる)
        // StartCoroutine("FrameRoutine", 0);
        // メソッド名を参照することでコルーチンを開始
        // StartCoroutine(CheckFuelRoutine_2());
        // StartCoroutine(SecondRoutine());
        // Run();
    }

    void Update()
    {
        // fuel--;
    }


    IEnumerator FrameRoutine(int n = 0)
    {
        Debug.Log("Start FrameRoutine : " + Time.time);
        int i = n;
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

    // Yield Return Wait Until / Wait While (デリゲートを待つ)
    // Wait Untilはデリゲートがtrueと評価されるまで実行を一時停止し、Wait Whileはそれがfalseになるまで待ってから実行を開始。
    // 提供されたデリゲートは、MonoBehaviour.Updateの後、MonoBehaviour.LateUpdateの前に、各フレームで実行されることに注意。
    int fuel = 5;

    Coroutine fuelCoroutine = null;

    void Run()
    {
        fuelCoroutine = StartCoroutine(UseFuelRoutine());
        StartCoroutine(CheckFuelRoutine());
    }

    IEnumerator UseFuelRoutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(1.0f);
            fuel--;
            Debug.Log(fuel + " fuel");
        }
    }
    IEnumerator CheckFuelRoutine()
    {
        // false => true のとき実行
        yield return new WaitUntil(IsEmpty);
        Debug.Log("tank is Empty!");
        StopCoroutine(fuelCoroutine);
    }
    bool IsEmpty()
    {
        // Debug.Log("Fuel is Empty?");
        if(fuel > 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    // 上記のように条件を評価するために外部関数(IsEmpty) を使用しているが
    // While Loopの代わりにWait UntilやWait Whileを使う利点は、利便性にある。ラムダ式を使うと、While Loopと同じように、1行のコードで変数の条件をチェックすることが可能
    IEnumerator CheckFuelRoutine_2()
    {
        // true => false 時実行
        yield return new WaitWhile(() => fuel > 0);
        Debug.Log("tank is empty");
        Debug.Log(fuel);
    }
}

