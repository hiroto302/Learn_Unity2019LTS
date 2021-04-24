using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGUI_Event : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // You can only call GUI functions from inside OnGUI.
        // GUI.Button(new Rect(10, 10, 150, 100), "I am a button");
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 150, 100), "I am a button"))
        {
            print("You clicked the button!");
        }
    }
}
