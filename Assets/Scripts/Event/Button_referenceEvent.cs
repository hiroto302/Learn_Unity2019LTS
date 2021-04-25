using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// ボタン操作の際、対応したイベントを実行するクラス
public class Button_referenceEvent : MonoBehaviour
{
    public Button showInfoButton;
    // Button_event buttonEvents;
    ShowInfoEvent showInfoEvent;
    void Start()
    {
        // 参照するイベントのインスタンス
        /*  MonoBehaviour を 継承してるクラスは参照できない
            You are trying to create a MonoBehaviour using the 'new' keyword.
            This is not allowed.  MonoBehaviours can only be added using AddComponent().
            buttonEvents = new Button_event(); だめ！！
        */
        showInfoEvent = new ShowInfoEvent("hiro", 302);
        // ボタンの取得
        showInfoButton.GetComponent<Button>();
        // ボタンが押された時、実行するイベントを加える
        showInfoButton.onClick.AddListener(showInfoEvent.ShowInfo);
    }

    void ShowInfo()
    {
        Debug.Log("Hello!!");
    }
}
