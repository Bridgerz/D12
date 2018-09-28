using Assets.Inventory.Scripts.Item.ItemModels;
using Assets.Inventory.Scripts.Item.OM;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipManager : MonoBehaviour {

    public GameObject EquipSlotPrefab;
    public GameObject MainSlotPanel;
    public GameObject CurioSlotPanel;
    public ItemListManager ListManager;
    public InvenGridScript Grid;
    public InvenGridManager GridManager;
    public int CurioSlotY;
    public int CurioSlotX;
    public EquipSlot MainHandSlot;
    public EquipSlot OffHandSlot;
    public int CurioNum;


	void Start () {
        for (int i = 0; i < 3; i++) {
            GameObject obj = (GameObject)Instantiate(EquipSlotPrefab);
            obj.transform.SetParent(MainSlotPanel.transform);
            RectTransform rect = obj.transform.GetComponent<RectTransform>();
            rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Grid.slotSize * 2);
            rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Grid.slotSize * 4);
            obj.GetComponent<RectTransform>().localScale = Vector3.one;
            switch (i)
            {
                case 0:
                    obj.transform.name = "Main Hand Slot";
                    obj.GetComponent<EquipSlot>().SlotType = ItemType.Wielded;
                    MainHandSlot = obj.GetComponent<EquipSlot>();
                    break;
                case 1:
                    obj.transform.name = "Armor Slot";
                    obj.GetComponent<EquipSlot>().SlotType = ItemType.Armor;
                    break;
                case 2:
                    obj.transform.name = "Off Hand Slot";
                    obj.GetComponent<EquipSlot>().SlotType = ItemType.Wielded;
                    OffHandSlot = obj.GetComponent<EquipSlot>();
                    break;
            }
        }

        for (int i = 0; i < CurioNum; i++)
        {
            GameObject obj = (GameObject)Instantiate(EquipSlotPrefab);
            obj.transform.SetParent(CurioSlotPanel.transform);
            RectTransform rect = obj.transform.GetComponent<RectTransform>();
            rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Grid.slotSize * 2);
            rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Grid.slotSize * 2);
            obj.GetComponent<RectTransform>().localScale = Vector3.one;
            obj.transform.name = "Curio " + i;
            obj.GetComponent<EquipSlot>().SlotType = ItemType.Curio;
        }
        LoadEquipment();
	}

    public void EquipCheck(GameObject itemObject, GameObject selectedSlot)
    {
        var item = itemObject.GetComponent<ItemOm>().Item;
        var slot = selectedSlot.GetComponent<EquipSlot>();
        if (item.Type == slot.SlotType)
        {
            if (item.Type == ItemType.Wielded)
            {
                if (item.GetType() == typeof(WeaponDm))
                {
                    if (item.Tags.Contains(Tag.TwoHanded))
                    {
                        UnEquipItem(MainHandSlot.Item);
                        UnEquipItem(OffHandSlot.Item);
                        Equip(itemObject, selectedSlot);
                    }
                    else if (item.Tags.Contains(Tag.Light) || selectedSlot == MainHandSlot)
                    {
                        Equip(itemObject, selectedSlot);
                    }
                }
                else
                {
                    if (item.IsShield)
                    {
                        if (selectedSlot == OffHandSlot)
                        {
                            Equip(itemObject, selectedSlot);
                        }
                    }
                    else
                    {
                        Equip(itemObject, selectedSlot);
                    }
                }
            }
            else
            {
                Equip(itemObject, selectedSlot);
            }
        }
    }

    public void Equip(GameObject itemObject, GameObject selectedSlot)
    {
        var item = itemObject.GetComponent<ItemOm>().Item;
        var slot = selectedSlot.GetComponent<EquipSlot>();
        if (slot.Occupied)
        {
            Swap(itemObject, selectedSlot);
        }
        else
        {
            GridManager.RemoveSelectedButton();
            selectedSlot.GetComponent<EquipSlot>().Item = itemObject;
            selectedSlot.GetComponent<EquipSlot>().Occupied = true;
            itemObject.transform.SetParent(selectedSlot.transform);
            itemObject.GetComponent<RectTransform>().pivot = new Vector2(.5f, .5f);
            itemObject.transform.position = selectedSlot.transform.position;
            itemObject.GetComponent<CanvasGroup>().alpha = 1f;
            ItemOm.SelectedItem = null;
            ItemOm.IsDragging = false;
            var index = ListManager.Inventory.FindIndex(x => x.GlobalID == item.GlobalID);
            if (index >= 0)
            {
                ListManager.Inventory.RemoveAt(index);
            }
            ListManager.InvManager.SaveInventory(ListManager.Inventory);
        }
    }

    private void UnEquipItem(GameObject itemObject)
    {
        if (itemObject != null)
        {
            // move itemObject from equipment panel to first available spot.
            // go through slot list, checking each slot if itemObject would fit
            // 
        }
    }

    public void Swap(GameObject itemObject, GameObject selectedSlot)
    {
        var item = itemObject.GetComponent<ItemOm>().Item;
        var slot = selectedSlot.GetComponent<EquipSlot>();
        if (item.Type == slot.SlotType)
        {
            GameObject preItem = slot.Item;
            EquipCheck(itemObject, selectedSlot);
            ItemOm.SetSelectedItem(preItem);
            preItem.transform.SetParent(GameObject.Find("DragParent").transform);
            ItemOm.IsDragging = true;
        }
    }

    private void LoadEquipment()
    {
        // load equipment
    }

    private void SaveEquipment()
    {

    }
}
