using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// コマンド入力を実装するインターフェース
public interface ICommand
{
    void Execute(); // 実行処理
    void Undo();    // 戻す処理
}
