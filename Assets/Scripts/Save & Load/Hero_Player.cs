using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ヒーロー : Player
public class Hero_Player : MonoBehaviour
{
    // テキトーな初期設定されてる player の情報が保存されてる
    [SerializeField] PlayerData_ScriptableObject _playerData;

    // 初期設定
    public string playerName;
    public int level;

    // 下記で設定する値を上記に保存する
    public string settingPlayerName = "UltraMan";
    public int SettingLevel = 777;

    // PlayerPrefs に保存する時のキー
    public string key = "";

    void Start()
    {
        playerName = _playerData.PlayerName;
        level = _playerData.Level;
        Debug.Log("初期設定の名前 : " + playerName );
        Debug.Log("初期設定のLevel : " + level);
    }

    void Update()
    {
        // 1回目 : 設定内容を保存
        if(Input.GetKeyDown(KeyCode.S))
        {
            // 新規ネーム・Level設定完了
            playerName = settingPlayerName;
            level = SettingLevel;
            // 情報をJson化(このオブジェクトの情報をJson形式でフォーマット化)
            string jsonData = JsonUtility.ToJson(this, true);
            // キーを作成
            if(key == "")
            {
                key = this.name;
                // 保存
                PlayerPrefs.SetString(key, jsonData);
                Debug.Log("保存");
            }
        }

        // 2回目 : ロード処理する時
        if(Input.GetKeyDown(KeyCode.L))
        {
            if(key == "")
            {
                key = this.name;
            }
            // Jsonデータをこのオブジェクトに上書き
            JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString(key), this);
            Debug.Log("ロード");
        }


        // Data 削除
        if(Input.GetKeyDown(KeyCode.D))
        {
            // 設定情報からキーとと対応する値を削除
            PlayerPrefs.DeleteKey(key);
        }
    }
}
