using Assets.Inventory.Scripts.Item.ItemModels;
using Assets.Inventory.Scripts.Item.OM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Inventory.Scripts.Item
{
    public class WieldableDm : ItemDm
    {
        public override bool IsShield { get; set; }

        public WieldableDm(int globalID, ItemType type, string title,
        string defenition, bool isShield, Quality quality,
        int weight) : base(globalID, type, title, defenition, quality, weight)
        {
            IsShield = isShield;
        }
    }
}
