using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    private Dictionary<string, int> items = new Dictionary<string, int>();

    void Start()
    {
        instance = this;
    }

    public void AddItem(string id, int amount){
        if(!items.ContainsKey(id)){
            items[id] = 0;
        }

        items[id] += amount;
    }

    public int GetItemCount(string id){
        if(items.ContainsKey(id)){
            return items[id];
        }
        return 0;
    }

    public static Inventory GetInstance(){
        return instance;
    }
}
