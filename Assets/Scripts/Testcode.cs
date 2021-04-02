using System.Collections;
using System.Collections.Generic;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Profiling;

public class Testcode : MonoBehaviour
{
    int num = 0;
    float elapsedTime = 0;

    CustomSampler mySampler = CustomSampler.Create("Test Code 1");
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if(elapsedTime > 0.1f)
        {
            Test1(10);
            elapsedTime = 0;
        }
    }

    void Test1(int num)
    {
        mySampler.Begin(gameObject);
        this.num += num;
        mySampler.End();
    }
}
