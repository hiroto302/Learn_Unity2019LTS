using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 各 MonoBehaviour.OnMouse___() について
// event を発生させるためには、オブジェクトに Collier がアタッチされていること
// Called when the mouse enters the Collider.

public class OnMouse_Event : MonoBehaviour
{
    public Renderer rend;
    public float draggingtime;
    /*
    OnMouse is called when the user has pressed the mouse button while over the 「Collider」.
    This event is sent to all scripts of the GameObject with Collider or GUIElement.
    Scripts of the parent or child objects do not receive this event.
    */
    void OnMouseDown()
    {
        // Debug.Log("Execute OnMouseDown");
    }
    void OnMouseUp()
    {
        // Register when mouse dragging has ended. OnMouseUp is called
        // when the mouse button is released.
    }

    // マウスが重なった時....
    // The mesh goes red when the mouse is over it...
    void OnMouseEnter()
    {
        rend.material.color = Color.red;
    }

    // マウスが重なっている間....
    // ...the red fades out to cyan as the mouse is held over...
    void OnMouseOver()
    {
        rend.material.color -= new Color(0.1F, 0, 0) * Time.deltaTime;
    }

    // マウスをドラッグし続けている間...
    void OnMouseDrag()
    {
        // rend.material.color -= Color.white * Time.deltaTime;
        draggingtime += Time.deltaTime;
        Debug.Log("Execute OnMouseDrag : " + draggingtime);
        // ...fadeSpeed Up!! Change white to black
        rend.material.color -= Color.white * Time.deltaTime;
    }
    // マウスが離れた時
    // ...and the mesh finally turns white when the mouse moves away.
    void OnMouseExit()
    {
        rend.material.color = Color.white;
    }
}
