using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*  概要 : PlayerPrefs
    PlayerPrefsの内容はmacOSの場合、User/Library/Preferencesフォルダ内のunity.[会社名].[製品名].plistというファイルに保存されます
    会社名と製品名はProject Settingsで設定された名前
*/

public class PlayerPrefs_Test : MonoBehaviour
{
    public string SavedText = "セーブする文字";
    public string Key = "SavedText";
    public string LoadedTest = "ロードした テキスト";

    public string InitialText = "初期設定文字";

    void Start()
    {
        // InitialText に PlayerPrefs の Key と結びついてる 文字を代入(ロード)
        InitialText =  LoadText(Key);
    }

    void Update()
    {
        // Test : セーブ
        if(Input.GetKeyDown(KeyCode.S))
        {
            SaveText(Key, SavedText);
        }

        // Test : ロード
        if(Input.GetKeyDown(KeyCode.L))
        {
            // 第二引数 defalt : Keyに対応したものがなかった時帰ってくるもの
            LoadedTest =  PlayerPrefs.GetString(Key, "なかったよ");
            // ロードしたテキストを表示
            Debug.Log(LoadedTest);
        }

        // Test : 削除
        if(Input.GetKeyDown(KeyCode.D))
        {
            // 設定情報からキーとと対応する値を削除
            PlayerPrefs.DeleteKey(Key);
        }
    }


    // テキストのセーブ
    void SaveText(string key, string savedText)
    {
        // PlayerPrefs により 文字(SavedText) を保存。 key と結びつてる
        PlayerPrefs.SetString(key, savedText);
        Debug.Log("Save");
    }

    // テキストのロード
    string LoadText(string key)
    {
        LoadedTest = PlayerPrefs.GetString(key, "なかったよ");
        return LoadedTest;
    }

    // PlayerPrefs の キーに対応する値を削除
    void DeletePlayerPrefsData(string key)
    {
        PlayerPrefs.DeleteKey(key);
    }

}
