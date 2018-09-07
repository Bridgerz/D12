using Assets.Inventory.Scripts.Item;
using Assets.Inventory.Scripts.ItemObject;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemOm : MonoBehaviour
{
    private GameObject invenPanel;
    private float slotSize;

    public ItemDm Item;
    public int Quantity;
    public SlotLocation Location;
    [HideInInspector] public Sprite Icon;
    [HideInInspector] public IntVector2 Size;

    public ItemOm(ItemDm item, int quantity, Sprite icon, IntVector2 size)
    {
        Item = item;
        Quantity = quantity;
        Icon = icon;
        Size = size;
    }

    private void Awake()
    {
        slotSize = GameObject.FindGameObjectWithTag("InvenPanel").GetComponent<InvenGridScript>().slotSize;
    }


    public void SetItemObject(ItemOm passedItem)
    {
        RectTransform rect = GetComponent<RectTransform>();
        rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, passedItem.Size.x * slotSize);
        rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, passedItem.Size.y * slotSize);
        Item = passedItem.Item;
        GetComponent<Image>().sprite = passedItem.Icon;
    }


}
