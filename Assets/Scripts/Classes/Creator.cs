using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CreateObject; // オブジェクト作成のためのUtilityHelperを提供

public class Creator : MonoBehaviour
{
    void Start()
    {
        GameObject someObjet =  UtilityHelper.CreateObject(PrimitiveType.Capsule);
        UtilityHelper.SetPositionZero(someObjet);
        UtilityHelper.ChangeColor(someObjet, Color.red, true);
    }
}
