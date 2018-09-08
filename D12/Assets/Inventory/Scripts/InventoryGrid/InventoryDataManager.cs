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
            
        }
        
        public List<ItemDm> LoadInventory(LoadItemDatabase database)
        {
            return new List<ItemDm>();
        }
    }
}