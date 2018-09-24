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
    public override bool MainHand { get; set; }
    public override List<Tag> Tags { get; set; }
    public override List<Enchantment> Enchantments { get; set; }

    public WeaponDm(int globalID, ItemType type, string title,
        string defenition, int damage, bool mainHand, List<Tag> tags,
        List<Enchantment> enchantments, Quality quality,
        int weight) : base(globalID, type, title, defenition, quality, weight)
    {
        Damage = damage;
        MainHand = mainHand;
        Tags = tags;
        Enchantments = enchantments;
    }
}
