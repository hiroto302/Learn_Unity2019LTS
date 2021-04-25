using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PrimitiveObjectを作成する機能を提供する
namespace CreateObject
{
    // Static クラスにすることで、static タイプの変数、メソッドしか持っていないことを明示している
    public static class UtilityHelper
    {
        public static GameObject CreateObject(PrimitiveType primitiveType)
        {
            return GameObject.CreatePrimitive(primitiveType);
        }
        public static void SetPositionZero(GameObject obj)
        {
            obj.transform.position = Vector3.zero;
        }
        public static void ChangeColor(GameObject obj, Color color, bool randomColor = false)
        {
            if(randomColor)
            {
                color = new Color(Random.value, Random.value, Random.value);
            }
            obj.GetComponent<MeshRenderer>().material.color = color;
        }
    }
}
