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
using Assets.Inventory.Scripts.ItemList;

namespace Assets.Inventory.Scripts.InventoryGrid
{
    public class InventoryDataManager
    {

        private string InventoryJsonFile = Path.Combine(Application.streamingAssetsPath, "InventoryItemData.json");
        private string EquipmentJsonFile = Path.Combine(Application.streamingAssetsPath, "EquipmentItemData.json");

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
                    var newItem = database.dbList.Where(x => x.GlobalID == item.GlobalID).First().Clone() as ItemDm;
                    newItem.Location = item.Location;
                    newItem.Quantity = item.Quantity;
                    newList.Add(newItem);
                }
            }
            return newList;
        }

        public EquipmentItems LoadEquipment(LoadItemDatabase database)
        {
            EquipmentSave equipmentSave = new EquipmentSave();
            if (File.Exists(EquipmentJsonFile))
            {
                string dataAsJason = File.ReadAllText(EquipmentJsonFile);
                equipmentSave = JsonConvert.DeserializeObject<EquipmentSave>(dataAsJason, new ItemConverter());
            }
            ItemDm mainHand = null;
            if (equipmentSave.MainHand != null)
            {
                mainHand = database.dbList.Where(x => x.GlobalID == equipmentSave.MainHand.GlobalID).First();
                
            }
            ItemDm offhand = null;
            if (equipmentSave.Offhand != null)
            {
                offhand = database.dbList.Where(x => x.GlobalID == equipmentSave.Offhand.GlobalID).First();
            }
            ItemDm armor = null;
            if (equipmentSave.Armor != null)
            {
                armor = database.dbList.Where(x => x.GlobalID == equipmentSave.Armor.GlobalID).First();
            }
            var curios = new List<ItemDm>();
            foreach (var curio in equipmentSave.Curios)
            {
                curios.Add(database.dbList.Where(x => x.GlobalID == curio.GlobalID).First());
            }
            return new EquipmentItems(mainHand, armor, offhand, curios);
        }

        public void SaveEquipment(EquipmentItems equipment)
        {
            InventoryItemSave mainHand = null;
            if (equipment.MainHand != null)
            {
                mainHand = new InventoryItemSave(equipment.MainHand.GlobalID, equipment.MainHand.Quantity, null);
            }
            InventoryItemSave offhand = null;
            if (equipment.Offhand != null)
            {
                offhand = new InventoryItemSave(equipment.Offhand.GlobalID, equipment.Offhand.Quantity, null);
            }
            InventoryItemSave armor = null;
            if (equipment.Armor != null)
            {
                armor = new InventoryItemSave(equipment.Armor.GlobalID, equipment.Armor.Quantity, null);
            }
            var curios = new List<InventoryItemSave>();
            foreach (var curio in equipment.Curios)
            {
                var curioSave = new InventoryItemSave(curio.GlobalID, curio.Quantity, null);
                curios.Add(curioSave);
            }
            var equipmentSave = new EquipmentSave(mainHand, armor, offhand, curios);

            var json = JsonConvert.SerializeObject(equipmentSave, Formatting.Indented, new ItemConverter());
            File.WriteAllText(EquipmentJsonFile, json);
        }

        public void SaveEquipAndInv(EquipmentItems equipment, List<ItemDm> inventory)
        {
            SaveEquipment(equipment);
            SaveInventory(inventory);
        }
    }
}