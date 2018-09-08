using Assets.Inventory.Scripts.ItemObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Inventory.Scripts.Item
{
    public class InventoryItemSave
    {
        public int GlobalID;
        public int Quantity;
        public SlotLocation Location;

        public InventoryItemSave(int globalID, int quantity, SlotLocation location)
        {
            GlobalID = globalID;
            Quantity = quantity;
            Location = location;
        }
    }
}
