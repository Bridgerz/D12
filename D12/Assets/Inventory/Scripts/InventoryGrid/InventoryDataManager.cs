using System;
using System.Collections.Generic;
using Assets.Inventory.Scripts.Item;
using System.Linq;
using System.Text;
using Assets.Inventory.Scripts.ItemObject;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Assets.Inventory.Scripts.InventoryGrid
{
    public class InventoryDataManager
    {
        public void SaveInventory(List<ItemOm> inventory)
        {
            //var saveList = new List<ItemSaveOM>();
            //foreach (var item in inventory)
            //{
            //    var saveItem = new ItemSaveOM(item.Item.GlobalID, item.Location, item.Quantity);
            //    saveList.Add(saveItem);
            //}
            //FileStream fs = new FileStream("Assets/StreamingAssets/ItemData.json", FileMode.Create);
            //BinaryFormatter bf = new BinaryFormatter();
            //bf.Serialize(fs, saveList);
            //fs.Close();
        }
        /*
        public List<ItemOm> LoadInventory(LoadItemDatabase database)
        {
            List<ItemSaveOM> inventoryList = new List<ItemSaveOM>();
            using (Stream stream = File.Open("Assets/StreamingAssets/ItemData.json", FileMode.Open))
            {
                var bformatter = new BinaryFormatter();
                inventoryList = (List<ItemSaveOM>)bformatter.Deserialize(stream);
            }

            foreach (var saveItem in inventoryList)
            {
                var itemOm = new ItemOm();
                var item = new ItemDm();

                var itemData = database.dbList.Where(x => x.GlobalID == saveItem.ItemID).First();

                item.GlobalID = itemData.GlobalID;
                item.Icon = itemData.Icon;
                item.Category = itemData.Category;
                item.TypeID = itemData.TypeID;

                itemOm.Quantity = saveItem.Quantity;
                itemOm.Location = saveItem.Location;
                itemOm.Icon = saveItem.

                itemOm.Item = item;
            }
        }*/
    }
}