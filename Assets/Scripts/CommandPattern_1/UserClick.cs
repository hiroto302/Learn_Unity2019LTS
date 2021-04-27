using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ユーザーが ClickCommand を行えるようにするためのクラス
public class UserClick : MonoBehaviour
{
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray =  Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if(Physics.Raycast(ray, out hitInfo))
            {
                if(hitInfo.collider.CompareTag("Cube"))
                {
                    // ClickComandのインスタンを生成し,親であるインターフェースICommand型のclick変数に代入
                    ICommand click = new ClickCommand(hitInfo.collider.gameObject, new Color(Random.value, Random.value, Random.value));
                    click.Execute();
                    // 入力情報を格納
                    CommandManager.Instance.AddCommand(click);
                }
            }
        }
    }
}
