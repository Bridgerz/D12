using Assets.Inventory.Scripts.ItemObject;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Text;
using Assets.Inventory.Scripts.Item.OM;
using Newtonsoft.Json;

[Serializable]
public class LoadItemDatabase : MonoBehaviour
{
    private string JsonFile = "Assets/StreamingAssets/ItemData.json";

    private void Awake()
    {
        LoadJson();
    }    

    public List<ItemDm> dbList = new List<ItemDm>();

    private void LoadJson()
    {
        var list = new List<ItemDm>();
        if (File.Exists(JsonFile))
        {
            string dataAsJason = File.ReadAllText(JsonFile);
            dbList = JsonConvert.DeserializeObject<List<ItemDm>>(dataAsJason);
        }
    }
}
