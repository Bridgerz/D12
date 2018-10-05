using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Inventory.Scripts.ItemList
{
    public class EquipmentItems
    {
        public ItemDm MainHand;
        public ItemDm Armor;
        public ItemDm Offhand;
        public List<ItemDm> Curios;

        public EquipmentItems(ItemDm mainHand, ItemDm armor, ItemDm offhand, List<ItemDm> curios)
        {
            MainHand = mainHand;
            Armor = armor;
            Offhand = offhand;
            Curios = curios;
        }
    }
}
