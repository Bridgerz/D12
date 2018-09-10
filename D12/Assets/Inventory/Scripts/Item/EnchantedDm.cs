using Assets.Inventory.Scripts.Item.OM;
using Assets.Inventory.Scripts.ItemObject;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This class is for Curios and Enchantable consumables
/// </summary>

[System.Serializable]
public class EnchantedDm : ItemDm
{
    public override List<Enchantment> Enchantments { get; set; }

    public EnchantedDm(int globalID, string title,
        string defenition, List<Enchantment> enchantments, Quality quality,
        int weight) : base(globalID, title, defenition, quality, weight)
    {
        Enchantments = enchantments;
    }
}
