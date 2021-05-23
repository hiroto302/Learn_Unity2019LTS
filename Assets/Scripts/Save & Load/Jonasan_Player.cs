using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jonasan_Player : MonoBehaviour
{
    [SerializeField] PlayerData_ScriptableObject _playerData;

    public string MyName;
    public int Level;

    void Start()
    {
        // 初期値をロード
        LoadInitialPlayerData();
    }

    void Update()
    {
        // 名前とレベルを変更する
        if(Input.GetKeyDown(KeyCode.C))
        {
            ChangeNameAndLevel();
        }

        // 現在の名前とレベルを保存する
        if(Input.GetKeyDown(KeyCode.S))
        {
            _playerData.SaveCurrentPlayerData(MyName, Level);
        }

        // 保存されてる内容をロードして、名前とレベルを更新する
        if(Input.GetKeyDown(KeyCode.L))
        {
            LoadSavedData();
        }

        // PlayerData を 初期化 (パラメーターのみ, 保存されてる内容は初期化しない)
        if(Input.GetKeyDown(KeyCode.I))
        {
            _playerData.InitializeNameAndLevel();
        }
    }

    //初期値をロード
    public void LoadInitialPlayerData()
    {
        MyName = _playerData.LoadInitialNameData();
        Level = _playerData.LoadInitialLevelData();
    }

    // 自身の名前とレベルを変更
    public void ChangeNameAndLevel()
    {
        Level += 10;
        MyName += "+";
    }

    // PlayerPrefsを介して 現在の名前とレベルを保存する
    public void SaveCurrentPlayerData()
    {
        _playerData.SaveCurrentPlayerData(MyName, Level);
    }

    // PlayerData から PlayerPrefsに保存されてるデータをロード
    public void LoadSavedData()
    {
        _playerData.LoadPlayerData();
        MyName = _playerData.PlayerName;
        Level = _playerData.Level;
    }

    // PlayerData の変数を初期値に戻す
    public void InitializeNameAndLevelParameters()
    {
        _playerData.InitializeNameAndLevel();
    }

    // 保存しいるデータ削除
    public void DeleteSavedData()
    {
        _playerData.DeleteSavedData();
    }
}
