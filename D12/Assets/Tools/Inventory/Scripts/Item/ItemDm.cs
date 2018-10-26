using Assets.Inventory.Scripts.Item.ItemModels;
using Assets.Inventory.Scripts.Item.OM;
using Assets.Inventory.Scripts.ItemObject;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemDm : ICloneable
{
    public int GlobalID { get; set; }
    public Guid InstanceID { get; set; }
    public ItemType Type { get; set; }
    public string Title { get; set; }
    public Quality Quality { get; set; }
    public string SubType { get; set; }

    public int Weight { get; set; }
    public virtual int Damage { get; set; }
    public virtual int Defence { get; set; }
    public virtual List<Tag> Tags { get; set; }
    public virtual List<Enchantment> Enchantments { get; set; }

    public int Quantity;
    public SlotLocation Location;

    [HideInInspector] public Sprite Icon;
    [HideInInspector] public IntVector2 Size;

    [JsonConstructor]
    public ItemDm(int globalID, ItemType type, string title,
        Quality quality, string subType, int weight)
    {
        GlobalID = globalID;
        InstanceID = Guid.NewGuid();
        Type = type;
        Title = title;
        Quality = quality;
        SubType = subType;
        Weight = weight;
        Quantity = 1;
        Icon = Resources.Load<Sprite>("ItemImages/" + Title);
        Location = new SlotLocation();
    }

    public ItemDm(ItemDm right)
    {
        GlobalID = right.GlobalID;
        InstanceID = Guid.NewGuid();
        Type = right.Type;
        Title = right.Title;
        Quality = right.Quality;
        SubType = right.SubType;
        Weight = right.Weight;
        Quantity = right.Quantity;
        Icon = right.Icon;
        Size = right.Size;
    }

    public virtual object Clone()
    {
        return new ItemDm(this);
    }

}
