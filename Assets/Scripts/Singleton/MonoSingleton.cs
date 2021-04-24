using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 追加項目 : 「そのゲームオブジェクトが1つしか存在しないことを保証する」ような仕組みが欲しい
// C#では、ジェネリック型をインスタンス化する際に、クライアントコードが特定の型を指定することを制約できる
// Syntax: GenericTypeName<T> where T  : contraint1, constraint2
// where : ジェネリック・タイプの名前の後にwhere句を使って、ジェネリック・タイプに1つ以上の制約を指定可能

/*  ジェネリック・クラスをインスタンス化する際に、型を参照するという制約を設けてる?
    class DataStore<T> where T : class
    そうしたいなら上記のようになる
    上記では、クラス制約を適用した。
    これはDataStoreのクラスオブジェクトを作成する際に、引数として渡すことができるのは参照型のみということ。
    そのため、class、interface、delegate、array型などの参照型を渡すことができる。
    値型を渡すとコンパイルエラーになるので、プリミティブデータ型や構造体型は渡せない。
*/

// ジェネリックタイプの抽象クラス MonoSingleTone : where句 : 引数として渡すことができるのは MonoSingletone<T>（参照型のみ）ということ？

/* 正しい解釈 : abstract class MonoSingletone<T> : MonoBehaviour where T : MonoSingletone<T>
    型パラメーターの制約
    MonoSingletone<T> は MonoBehaviour を継承する。
    ただし T は MonoSingletone<T> を継承する型である。つまり、T のパラメターはクラス型に制約するということ
    AddComponent<T>()など、クラスの型が必要となる処理を行う時、T が class 型であることを保証しなければならない
*/

// public abstract class MonoSingletone<T> : MonoBehaviour

public abstract class MonoSingletone<T> : MonoBehaviour where T : MonoSingletone<T>
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                // Tに指定された型に応じて処理を行いたい場合、typeofを使う事で実現可能
                Debug.LogError(typeof(T).ToString() + "is Null");
                // なければ生成する. 下記の処理に関しては場合によっては必要ないかも
                GameObject newSingleton = new GameObject(typeof(T).ToString());
                newSingleton.AddComponent<T>();
            }
            return _instance;
        }
    }

    void Awake()
    {
        _instance = this as T;
    }
    public virtual void Init()
    {
        // optional to override
    }
}
