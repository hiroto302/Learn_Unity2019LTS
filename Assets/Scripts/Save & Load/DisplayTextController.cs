using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayTextController : MonoBehaviour
{
    // 表示するテキス
    [SerializeField] Text _playerName;
    [SerializeField] Text _playerLevel;
    [SerializeField] Text _dataName;
    [SerializeField] Text _dataLevel;

    // 表示するテキストの変数を持つクラス
    [SerializeField] Jonasan_Player _player;
    [SerializeField] PlayerData_ScriptableObject _data;


    // Update is called once per frame
    void Update()
    {
        _playerName.text = "Name : " + _player.MyName;
        _playerLevel.text = "Level : " + _player.Level;
        _dataName.text = "Name : " + _data.PlayerName;
        _dataLevel.text = "Level : " + _data.Level;
    }
}
