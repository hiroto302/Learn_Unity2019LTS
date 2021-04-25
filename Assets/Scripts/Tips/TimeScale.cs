using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TimeScale : MonoBehaviour
{
    public Button button;

    void Start()
    {
        button.onClick.AddListener(SlowMotion);
    }
    public void SlowMotion()
    {
        Time.timeScale = 0.2f;
    }
    public void SlowMotion(float timeScale)
    {
        Time.timeScale = timeScale;
    }
}
