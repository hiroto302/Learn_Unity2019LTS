using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class God : MonoBehaviour
{
    void OnEnable()
    {
        Human.onDeath += Rebirth;
    }

    void Rebirth(Human human)
    {
        Debug.Log("転生の時じゃ");
        human.age = 0;
        human.gameObject.GetComponent<MeshRenderer>().material.color = new Color(Random.value, Random.value, Random.value);
    }

    void Start()
    {
        // onDeath は event なので God からは実行できない
        // Human.onDeath();
    }
}
