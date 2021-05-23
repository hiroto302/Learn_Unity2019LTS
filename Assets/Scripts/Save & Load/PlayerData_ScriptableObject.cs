using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ビルドした後、テストプレイ中にSaveとLoadができるように実装する

/* ビルドしたアプリでテストプレイ時の考察
    Play 実行中でも Editor, または PlayScene 上で パラメターが変更された時シリアライズ化(?)、Play 終了後も内容は保存されたままである
    ただし、ビルドしたアプリの場合は、更新されても初期化される。

    今のSave とロード 機能の記述では、アプリを２つビルドした時、同名の key だと同じデータをを参照してしまっている。
    おそらく、同名の プロダクトネーム・会社名 のままビルドしたために。別のSaveファイルが作成されていないと考えられる。
    その通りだった。

    PlayePrefs.Save(変更された値をディスクへと保存) の役割がわからないままである.
    PlayerPrefs.SetString(key で識別される設定情報の値を設定)などで 変更した後に、
    PlayerPrefs.Saveを行わなくても、変更内容を参照することは可能である。
    デフォルトでは,OnApplicationQuit(). 自動的に呼ばれるため、明示的に記述することを推奨されていない。
*/

[CreateAssetMenu(fileName = "New PlayerData", menuName = "SaveData/PlayerData")]

public class PlayerData_ScriptableObject : ScriptableObject
{

    // シリアル化のルール確認
    // プリミティブなデータ型 (int、float、double、bool、string など)
    // Enum 型
    // 特定の Unity ビルトイン型: Vector2、Vector3、Vector4、Rect、Quaternion、Matrix4x4、Color、Color32、LayerMask、AnimationCurve、Gradient、RectOffset、GUIStyle
    // Serializable 属性をもつカスタム構造体
    // UnityEngine.Object から派生するオブジェクトへの参照
    // シリアライズ可能な簡易なフィールドタイプの配列
    // シリアライズ可能な簡易なフィールドタイプの List<T>

    [Header("InitialData")]
    [SerializeField] private string _initialPlayerName; // serializeFiled OK!!
    [SerializeField] private int _initialPlayerLevel;

    private string _codeName;                    // private No!!

    [Header("SaveData")]
    public int Level;                            // public  OK!!

    public string PlayerName;                    // ok

    [SerializeField] private string _key;        // ok

    void OnDisable()
    {
        Debug.Log("範囲外");
    }

    void OnEnable()
    {
        Debug.Log("範囲内");
        // ビルドしたアプリで、起動時に保存されてるDataを取得.
        LoadPlayerData();
    }

    public void SaveCurrentPlayerData(string name, int level)
    {
        // Data の内容を更新
        PlayerName = name;
        Level = level;

        // PlayerPrefs に,Jsonを利用してこのクラスの情報を保存
        _key = this.name;
        string jsonData = JsonUtility.ToJson(this, true);
        PlayerPrefs.SetString(_key, jsonData);
        Debug.Log("セーブ");
    }

    // 保存されてる内容をロードする
    public void LoadPlayerData()
    {
        // キーと対応するDataがないときは、何も上書きされることなく変化しない
        JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString(_key), this);
        Debug.Log("ロード");
    }

    // 初期値のDataを渡す
    public string LoadInitialNameData()
    {
        return _initialPlayerName;
    }
    public int LoadInitialLevelData()
    {
        return _initialPlayerLevel;
    }

    // 初期化
    public void InitializeNameAndLevel()
    {
        PlayerName = _initialPlayerName;
        Level = _initialPlayerLevel;
    }

    // 保存してあるデータ削除
    public void DeleteSavedData()
    {
        // キーと対応しているデータ削除
        PlayerPrefs.DeleteKey(_key);
    }
}
