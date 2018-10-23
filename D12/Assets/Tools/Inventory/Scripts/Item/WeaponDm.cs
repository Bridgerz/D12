using Assets.Inventory.Scripts.Item.ItemModels;
using Assets.Inventory.Scripts.Item.OM;
using Assets.Inventory.Scripts.ItemObject;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This class is for weapons
/// </summary>

[System.Serializable]
public class WeaponDm : ItemDm
{
    public override int Damage { get; set; }
    public override List<Tag> Tags { get; set; }
    public override List<Enchantment> Enchantments { get; set; }

    [JsonConstructor]
    public WeaponDm(int globalID, ItemType type, string title,
        string defenition, int damage, List<Tag> tags,
        List<Enchantment> enchantments, Quality quality, string subType,
        int weight) : base(globalID, type, title, quality, subType, weight)
    {
        Damage = damage;
        Tags = tags;
        Enchantments = enchantments;
    }

    public WeaponDm(WeaponDm right) : base(right)
    {
        Damage = right.Damage;
        Tags = right.Tags;
        Enchantments = right.Enchantments;
    }

    public override object Clone()
    {
        return new WeaponDm(this);
    }
}
