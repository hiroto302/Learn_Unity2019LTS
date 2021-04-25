using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item_D
{
    public string name;
    public int id;
    public Item_D(string name, int id)
    {
        this.name = name;
        this.id = id;
    }
}
public class ItemDB_D : MonoBehaviour
{
    public Dictionary<int, Item_D> itemDB = new Dictionary<int, Item_D>();


    void Start()
    {
        Item_D apple = new Item_D("Apple", 0);
        Item_D banana = new Item_D("Banana", 1);

        itemDB.Add(apple.id, apple);
        itemDB.Add(banana.id, banana);

        foreach(KeyValuePair<int, Item_D> item in itemDB)
        {
            Debug.Log(item.Key + " = " + item.Value.id + " : " + item.Value.name);
        }
        Debug.Log("ItemDB に登録されてる数 :" + itemDB.Count);
    }
}
