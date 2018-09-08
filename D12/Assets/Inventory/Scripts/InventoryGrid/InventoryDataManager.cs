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
            // fetch current inventory and compare 


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
            return new List<ItemDm>();
        }
    }
}