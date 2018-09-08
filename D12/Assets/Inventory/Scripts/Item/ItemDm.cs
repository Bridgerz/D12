using Assets.Inventory.Scripts.Item.OM;
using Assets.Inventory.Scripts.ItemObject;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemDm : MonoBehaviour
{
    [JsonProperty("GlobalID")]
    public int GlobalID { get; set; }
    [JsonProperty("Title")]
    public string Title { get; set; }
    [JsonProperty("Defenition")]
    public string Defenition { get; set; }
    [JsonProperty("Quality")]
    public Quality Quality { get; set; }
    [JsonProperty("Weight")]
    public int Weight { get; set; }

    [JsonProperty("Damage")]
    public virtual int Damage { get; set; }
    [JsonProperty("MainHand")]
    public virtual bool MainHand { get; set; }
    [JsonProperty("Tags")]
    public virtual List<Tag> Tags { get; set; }
    [JsonProperty("Enchantments")]
    public virtual List<Enchantment> Enchantments { get; set; }

    public int Quantity;
    public SlotLocation Location;

    [HideInInspector] public Sprite Icon;
    [HideInInspector] public IntVector2 Size;

    public ItemDm(int globalID, string title,
        string defenition, Quality quality,
        int weight)
    {
        GlobalID = globalID;
        Title = title;
        Defenition = defenition;
        Quality = quality;
        Weight = weight;
        Quantity = 1;
        Icon = Resources.Load<Sprite>("ItemImages/" + Title);
        Size = new IntVector2(2, 2);
    }
}
