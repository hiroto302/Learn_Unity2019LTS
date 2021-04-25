using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class SlowTimeEvent : UnityEvent<float>
{
}
public class TimeScaleManager : MonoBehaviour
{
    public SlowTimeEvent slowTimeEvent = new SlowTimeEvent();

    // Start is called before the first frame update
    void Start()
    {
            slowTimeEvent.AddListener(SlowMotion);
    }

    public void InvokeSlowMotion()
    {
        slowTimeEvent.Invoke(1);
    }

    public void SlowMotion(float timeScale)
    {
        Time.timeScale = timeScale;
    }
}
