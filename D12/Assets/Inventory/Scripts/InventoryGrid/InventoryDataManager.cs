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
using Assets.Inventory.Scripts.CreateItem;

namespace Assets.Inventory.Scripts.InventoryGrid
{
    public class InventoryDataManager
    {

        private string InventoryJsonFile = "Assets/StreamingAssets/InventoryItemData.json";
        private string EquipmentJsonFile = "Assets/StreamingAssets/EquipmentItemData.json";

        public void SaveInventory(List<ItemDm> inventory)
        {
            var saveList = new List<InventoryItemSave>();
            foreach (var item in inventory)
            {
                var saveItem = new InventoryItemSave(item.GlobalID, item.Quantity, item.Location);
                saveList.Add(saveItem);
            }
            var json = JsonConvert.SerializeObject(saveList, Formatting.Indented, new ItemConverter());
            File.WriteAllText(InventoryJsonFile, json);
        }
        
        public List<ItemDm> LoadInventory(LoadItemDatabase database)
        {
            List<InventoryItemSave> saveList = new List<InventoryItemSave>();
            List<ItemDm> newList = new List<ItemDm>();
            if (File.Exists(InventoryJsonFile))
            {
                string dataAsJason = File.ReadAllText(InventoryJsonFile);
                saveList = JsonConvert.DeserializeObject<List<InventoryItemSave>>(dataAsJason, new ItemConverter());
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

        public EquipmentSave LoadEquipment(LoadItemDatabase database)
        {
            EquipmentSave equipmentSave = new EquipmentSave();
            List<ItemDm> newList = new List<ItemDm>();
            if (File.Exists(EquipmentJsonFile))
            {
                string dataAsJason = File.ReadAllText(EquipmentJsonFile);
                equipmentSave = JsonConvert.DeserializeObject<EquipmentSave>(dataAsJason, new ItemConverter());
            }
            return equipmentSave;
        }

        public void SaveEquipment(EquipManager inventory)
        {

        }
    }
}