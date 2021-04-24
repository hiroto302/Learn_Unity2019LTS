using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Events.UnityEvent について

[System.Serializable]
public class MyIntEvent : UnityEvent<int>
{
    // One argument version of UnityEvent. UnityEvent<T0>
}

public class Event : MonoBehaviour
{
    // A zero argument persistent callback that can be saved with the Scene.
    // publicにすることで、Inspectorウィンドウで編集することを可能とする
    public UnityEvent myEvent;

    // ジェネリックの UnityEvent 型を使用したい場合は、クラスをオーバーライドする必要がある(上記に記載)
    public MyIntEvent myEvent_1 = new MyIntEvent();

    // Start is called before the first frame update
    void Start()
    {
        // 参照先がなければ、新たなインスタンス作成
        if(myEvent == null)
            myEvent = new UnityEvent();

        // Add a listener to the new Event. Calls MyEvent method when invoked
        // 非永続的なイベントは、AddListenerで追加することで呼び出すことが出来る。
        // 永続的なイベント : InspectorのButtonコンポーネントにスクリプトをアタッチしてイベント登録されたイベントなど
        myEvent.AddListener(MyEvent);


        // 型が異なるイベント関数を追加 : 引数ごとに追加してる？
        myEvent_1.AddListener(MyEvent1);
        // 今回は、インスペクター上でも追加したよ
    }

    void Update()
    {
        if(Input.anyKeyDown)
        {
            // イベント関数の呼び出し
            myEvent.Invoke();

            // 追加された関数がInvokeの引数に関係なくインスペクター上で追加したものは呼ばれてる。どういう仕組み？
            myEvent_1.Invoke(1);
        }

        if(Input.GetKeyDown("q"))
        {
            Debug.Log("Quitting Remove MyEvent");
            // UnityEvent から非永続的なリスナーを削除
            myEvent.RemoveListener(MyEvent);

            // インスペクター上で登録したものはどうなるか?
            myEvent_1.RemoveAllListeners();
            // イベントからすべての非永続的な (つまり、スクリプトから作成された) リスナーのみを削除
        }
    }

    void MyEvent()
    {
        Debug.Log("MY EVENT!!");
    }
    public void MyEvent1(int i)
    {
        Debug.Log("MY EVENT " + i);
    }
}

