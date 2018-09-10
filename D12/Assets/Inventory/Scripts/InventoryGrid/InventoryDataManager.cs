using System;
using System.Collections.Generic;
using Assets.Inventory.Scripts.Item;
using System.Linq;
using System.Text;
using Assets.Inventory.Scripts.ItemObject;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;

namespace Assets.Inventory.Scripts.InventoryGrid
{
    public class InventoryDataManager
    {

        private string JsonFile = "Assets/StreamingAssets/InventoryItemData.json";
        

        public void SaveInventory(List<ItemDm> inventory)
        {
            var saveList = new List<InventoryItemSave>();
            foreach (var item in inventory)
            {
                var saveItem = new InventoryItemSave(item.GlobalID, item.Quantity, item.Location);
                saveList.Add(saveItem);
            }
            var json = JsonConvert.SerializeObject(saveList, Formatting.Indented);
            File.WriteAllText(JsonFile, json);
        }
        
        public List<ItemDm> LoadInventory(LoadItemDatabase database)
        {
            List<InventoryItemSave> saveList = new List<InventoryItemSave>();
            List<ItemDm> newList = new List<ItemDm>();
            if (File.Exists(JsonFile))
            {
                string dataAsJason = File.ReadAllText(JsonFile);
                saveList = JsonConvert.DeserializeObject<List<InventoryItemSave>>(dataAsJason);
            }
            if (saveList.Count > 0)
            {
                foreach (var item in saveList)
                {
                    var newItem = database.dbList.Where(x => x.GlobalID == item.GlobalID).First();
                    newItem.Location = item.Location;
                    newItem.Quantity = item.Quantity;
                    newList.Add(newItem);
                }
            }
            return newList;
        }
    }
}