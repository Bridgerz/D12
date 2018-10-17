using Assets.Inventory.Scripts.Item.ItemModels;
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
public class CurioDm : ItemDm
{
    public override List<Enchantment> Enchantments { get; set; }

    [JsonConstructor]
    public CurioDm(int globalID, ItemType type, string title,
        string defenition, List<Enchantment> enchantments, Quality quality,
        string subType, int weight) : base(globalID, type, title, quality, subType, weight)
    {
        Enchantments = enchantments;
    }

    public CurioDm(CurioDm right) : base(right)
    {
        Enchantments = right.Enchantments;
    }

    public override object Clone()
    {
        return new CurioDm(this);
    }
}
