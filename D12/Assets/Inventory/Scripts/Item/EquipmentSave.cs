using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Inventory.Scripts.Item
{
    public class EquipmentSave
    {
        public InventoryItemSave MainHand;
        public InventoryItemSave Armor;
        public InventoryItemSave Offhand;
        public List<InventoryItemSave> Curios;

        public EquipmentSave(InventoryItemSave mainHand, InventoryItemSave armor, 
            InventoryItemSave offhand, List<InventoryItemSave> curios)
        {
            MainHand = mainHand;
            Armor = armor;
            Offhand = offhand;
            Curios = curios;
        }

        public EquipmentSave()
        {
            MainHand = null;
            Armor = null;
            Offhand = null;
            Curios = new List<InventoryItemSave>();
        }
    }
}
