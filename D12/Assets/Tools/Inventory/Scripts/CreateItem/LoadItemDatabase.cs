using Assets.Inventory.Scripts.ItemObject;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Text;
using Assets.Inventory.Scripts.Item.OM;
using Newtonsoft.Json;
using Assets.Inventory.Scripts.CreateItem;

[Serializable]
public class LoadItemDatabase : MonoBehaviour
{
    private string JsonFile;

    private void Awake()
    {
        JsonFile = Path.Combine(Application.streamingAssetsPath, "ItemData.json");
        LoadJson();
    }    

    public List<ItemDm> dbList = new List<ItemDm>();

    private void LoadJson()
    {
        if (File.Exists(JsonFile))
        {
            string dataAsJason = File.ReadAllText(JsonFile);
            dbList = JsonConvert.DeserializeObject<List<ItemDm>>(dataAsJason, new ItemConverter());
        }
    }
}
