using Assets.Inventory.Scripts.Item.ItemModels;
using Assets.Inventory.Scripts.Item.OM;
using Assets.Inventory.Scripts.ItemObject;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This class is for Armor
/// </summary>

[Serializable]
public class TaggedDm : ItemDm
{
    public override List<Tag> Tags { get; set; }
    public override List<Enchantment> Enchantments { get; set; }

    public TaggedDm(int globalID, ItemType type, string title,
        string defenition, int damage, List<Tag> tags,
        List<Enchantment> enchantments, Quality quality,
        int weight) : base (globalID, type, title, defenition, quality, weight)
    {

        Tags = tags;
        Enchantments = enchantments;
    }
}
