using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Shop
{
    public string name; // 店名
    public int number;  // 号店番号
}

[System.Serializable]
public class SAGAShop : Shop
{
    // static type は、hierarchy に表示されない
    public static string locality;
    public string message;
    static SAGAShop()
    {
        locality = "SAGA";
    }
    public SAGAShop(string name, int number, string message)
    {
        this.name = name;
        this.number = number;
        this.message = message;
        Debug.Log(locality + " " + number + "号店" + name + message);
    }
}


// Static の Constructor にテストサンプル
public class StaticConstructor : MonoBehaviour
{
    public SAGAShop karatuShop;
    void Start()
    {
        karatuShop = new SAGAShop("karatu", 1, "できたばい");
    }

}
