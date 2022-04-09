using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Struct_math : MonoBehaviour
{
    // 座標を表す構造体
    public struct Point
    {
        public float x, y;
    }

    // ベクトル
    public struct Vector
    {
        public float x, y;
    }
    
    // 座標 + ベクトル
    Point AddPointVector(Point p, Vector v)
    {
        Point r;
        r.x = p.x + v.x;
        r.y = p.y + v.y;
        return r;
    }

    Point p;
    Vector v;


    // Start is called before the first frame update
    void Start()
    {
        p.x = 5.0f;
        p.y = 2.0f;

        v.x = 2.0f;
        v.y = 4.0f;

        p = AddPointVector(p, v);
        Debug.Log(p.x + " : " + p.y);
    }
}
