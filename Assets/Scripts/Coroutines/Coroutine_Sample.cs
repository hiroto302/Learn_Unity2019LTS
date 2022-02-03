using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* コルーチンについて検証する
    コルーチンの戻り値の型 は IEnumerator : Unityプログラミングで用いられる非同期処理を行うために用いるデータ型の一種
    コルーチンでは yieldステートメント を使用して実行中のコードを一時停止
    関数を中断させたい地点で yield return というキーワードで始める
    Yield はメソッドが iterator (集合から次々に要素を抽出する行為を一般化したもの)であり、複数のフレームにわたって実行されることを示す。
    一方 return は通常の関数と同様、その時点で実行を終了し、呼び出し側のメソッドに制御を戻す。
*/

/* コルーチンの開始方法について
    nameメソッドよりもstringメソッドを使用した方が若干パフォーマンスが上がるらしい。
    ただし、文字列を使用してコルーチンを開始する場合、パラメータを1つだけ渡すことが可能
*/

/* コルーチンの終了について
    コルーチンは、そのコードが実行されると自動的に終了する。明示的にコルーチンを終了させる必要ない。
    コルーチンが終了する前に手動で終了させたい場合などの時は yield break(内部で) または、StopCoroutine(外部から) を使用する
    全てのコルーチンを停止したいときは、StopAllCoroutines()を使用。

    Game Objectを破壊すると、コルーチンが停止するのか？
    Game Objectを破壊または無効化すると、そこから呼び出されたコルーチンが、他のGame Object上の他のスクリプトにある場合でも終了する。
    ただしこれは、ゲームオブジェクトレベルでしか機能しない。スクリプトを無効化するだけでは、コルーチンは停止しない。
    また、あるオブジェクトのコルーチンが別のスクリプトによって呼び出された場合、そのオブジェクトを破壊しても、
    コルーチンは呼び出したゲームオブジェクトと結びついているため、コルーチンを終了させることはできない。
*/

/* その他メモ
    関数の開始を遅らせるだけならInvokeで、同じ関数を何度も繰り返すならInvoke Repeating でも対応できる。
    まUnityではAsync関数やAwait関数を使用することも可能で、これらはコルーチンと似たような仕組みで動作する
    Async関数やAwait関数とコルーチンの大きな違いは、一般的にコルーチンが値を返すことができないのに対して、Async関数やAwait関数は値を返すことができる点である。
*/


public class Coroutine_Sample : MonoBehaviour
{

    void Start()
    {
        // 文字列でコルーチンを開始 (文字列実行する時、引数にデフォルト値を利用することを記述する方法があるのか探す.何も指定しないと引数を要求するエラーになる)
        // StartCoroutine("FrameRoutine", 0);
        // メソッド名を参照することでコルーチンを開始
        // StartCoroutine(CheckFuelRoutine_2());
        // StartCoroutine(CountRoutine());
        // StartCoroutine(BreakRoutine());
        // Run();
        StartCoroutine(FirstRoutine());
    }

    void Update()
    {
        // fuel--;

        if(Input.GetKeyDown(KeyCode.S))
        {
            // 呼び出されたスクリプトによって開始されたすべてのコルーチンを停止する。他の場所で実行されている他のコルーチンに影響を与えない
            StopAllCoroutines();
        }
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

    IEnumerator CountRoutine()
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

    /*  コルーチンへの参照を保存
        ある特定のコルーチンのインスタンスを停止させたい場合などに便利
    */
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

        // 外部から 実行されている Coroutine を終了
        StopCoroutine(fuelCoroutine);
        fuelCoroutine = null;
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

    IEnumerator BreakRoutine()
    {
        int i = 0;
        while(true)
        {
            i++;
            Debug.Log(i);
            if(i > 3)
            {
                Debug.Log("途中終了");
                yield break;
            }
            yield return null;
        }
    }

    // Wait For End of Frame
    // この命令は、Unity がすべてのカメラと UI エレメントをレンダリングするまで、実際にフレームを表示する前に待機します。典型的な使い方は、スクリーンショットを撮ること
    IEnumerator TakePictureRoutine()
    {
        yield return new WaitForEndOfFrame();

        // CaptureScreen();
    }

    /* Wait for another Coroutine
        yield文のトリガーとなる別のコルーチンが実行を終了するまでyieldすることが可能。
        yield returnの後にStart Coroutineメソッドを実行するように記述する。
    */
    IEnumerator FirstRoutine()
    {
        Debug.Log("FirstRoutine has started");
        // 指定した Coroutine が終了するまで待機
        yield return StartCoroutine(SecondRoutine());
        // 終了後実行
        yield return new WaitForSeconds(1.0f);
        Debug.Log("FirstRoutine has ended");
    }
    IEnumerator SecondRoutine()
    {
        yield return new WaitForSeconds(1.0f);
        Debug.Log("SecondRoutine All Done");
    }
}

