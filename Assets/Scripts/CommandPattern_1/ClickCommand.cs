using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ユーザーがClickCommandを実行した時の処理
public class ClickCommand : ICommand
{
    private GameObject _cube;       // クリックしたオブジェクト
    private Color _color;           // 変更した後の色
    private Color _previousColor;   // 変更する前の色

    // コンストラクタ (cube : クリックしたオブジェクト, Color : cube を 変える色)
    public ClickCommand(GameObject cube, Color color)
    {
        this._cube = cube;
        this._color = color;
    }
    // 実行処理
    public void Execute()
    {
        _previousColor = _cube.GetComponent<MeshRenderer>().material.color; // 初期の色
        _cube.GetComponent<MeshRenderer>().material.color = _color;         // 色を変える
    }
    // 実行した処理を、前の状態に戻す処理
    public void Undo()
    {
        _cube.GetComponent<MeshRenderer>().material.color = _previousColor; // 初期の色に戻す
    }
}
