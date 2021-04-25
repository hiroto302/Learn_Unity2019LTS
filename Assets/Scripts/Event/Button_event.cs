using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ShowInfoEvent : UnityEvent
{
    string name;
    int age;
    public ShowInfoEvent(string name, int age)
    {
        this.name = name;
        this.age = age;
    }
    public void ShowInfo()
    {
        Debug.Log(name + " " + age);
    }
}
// ボタン操作に関する、発生イベントを管理するクラス
public class Button_event : MonoBehaviour
{
    public ShowInfoEvent showInfo1 = new ShowInfoEvent("hiro", 302);

    void Start()
    {
        showInfo1.AddListener(showInfo1.ShowInfo);
    }

    public void InvokeShowInfo1()
    {
        showInfo1.Invoke();
    }

}
