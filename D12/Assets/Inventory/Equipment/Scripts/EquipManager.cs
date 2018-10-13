﻿using Assets.Inventory.Scripts.Item.ItemModels;
using Assets.Inventory.Scripts.Item.OM;
using Assets.Inventory.Scripts.ItemList;
using Assets.Inventory.Scripts.ItemObject;
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
    public EquipSlot ArmorSlot;
    public List<EquipSlot> CurioSlots;
    public List<ItemDm> CurioItems;
    public int CurioNum;


	void Start ()
    {
        LoadEquipSlots();
        LoadEquipmentObjects();
    }
    
    private void LoadEquipSlots()
    {
        // load Equipment slots
        for (int i = 0; i < 3; i++)
        {
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
                    ArmorSlot = obj.GetComponent<EquipSlot>();
                    break;
                case 2:
                    obj.transform.name = "Off Hand Slot";
                    obj.GetComponent<EquipSlot>().SlotType = ItemType.Wielded;
                    OffHandSlot = obj.GetComponent<EquipSlot>();
                    break;
            }
        }
        // load curio slots
        CurioSlots = new List<EquipSlot>();
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
            CurioSlots.Add(obj.GetComponent<EquipSlot>());
        }
    }

    public void LoadEquipmentObjects()
    {
        var equipment = ListManager.Equipment;
        if (equipment.MainHand != null)
        {
            GameObject newItem = ListManager.itemEquipPool.GetObject();
            var tempItem = equipment.MainHand.Clone() as ItemDm;
            newItem.GetComponent<ItemOm>().SetItemObject(tempItem);
            EquipCheck(newItem, MainHandSlot.gameObject);
            newItem.GetComponent<RectTransform>().localScale = Vector3.one;
        }
        if (equipment.Armor != null)
        {
            GameObject newItem = ListManager.itemEquipPool.GetObject();
            var tempItem = equipment.Armor.Clone() as ItemDm;
            newItem.GetComponent<ItemOm>().SetItemObject(tempItem);
            EquipCheck(newItem, ArmorSlot.gameObject);
            newItem.GetComponent<RectTransform>().localScale = Vector3.one;
        }
        if (equipment.Offhand != null)
        {
            GameObject newItem = ListManager.itemEquipPool.GetObject();
            var tempItem = equipment.Offhand.Clone() as ItemDm;
            newItem.GetComponent<ItemOm>().SetItemObject(tempItem);
            EquipCheck(newItem, OffHandSlot.gameObject);
            newItem.GetComponent<RectTransform>().localScale = Vector3.one;
        }
        if (equipment.Curios.Count > 0)
        {
            for (int i = 0; i < equipment.Curios.Count; i++)
            {
                GameObject newItem = ListManager.itemEquipPool.GetObject();
                var tempItem = equipment.Curios[i].Clone() as ItemDm;
                newItem.GetComponent<ItemOm>().SetItemObject(tempItem);
                EquipCheck(newItem, CurioSlots[i].gameObject);
                newItem.GetComponent<RectTransform>().localScale = Vector3.one;
            }
        }
        UpdateEquipment();
    }

    public int EquipStatus(GameObject itemObject, GameObject selectedSlot)
    {
        // return 0 if current item can't be equipped in slot
        // return 1 if current item can be equipped in slot
        // return 2 if current item can be swapped with item in slot
        var item = itemObject.GetComponent<ItemOm>().Item;
        var slot = selectedSlot.GetComponent<EquipSlot>();
        if (item.Type != slot.SlotType)
        {
            return 0;
        }
        if (item.Type == ItemType.Wielded) // if this item can be weilded
        {
            if (MainHandSlot.Occupied && MainHandSlot.Item.GetComponent<ItemOm>().Item.Tags.Contains(Tag.TwoHanded) && slot == OffHandSlot) // if two handed equipped
            {
                return 0;
            }
            if (!item.Tags.Contains(Tag.Light) && !item.Tags.Contains(Tag.Shielding) && slot == OffHandSlot)// item isn't light/shield and hover over offhand
            {
                return 0;
            }
        }
        if (slot.Occupied)
        {
            if (slot == MainHandSlot && item.Tags.Contains(Tag.Shielding))
            {
                return 0;
            }
            return 2;
        }
        else
        {
            if (slot == OffHandSlot && item.Tags.Contains(Tag.Shielding))
            {
                return 1;
            }
            if (slot == MainHandSlot && item.Tags.Contains(Tag.Shielding))
            {
                return 0;
            }
            return 1;
        }
    }

    public void EquipCheck(GameObject itemObject, GameObject selectedSlot)
    {
        var status = EquipStatus(itemObject, selectedSlot);
        var item = itemObject.GetComponent<ItemOm>().Item;
        if (status == 1 || status == 2)
        {
            Equip(itemObject, selectedSlot); // equip/swap item in mainhand
            if (item.Tags != null && item.Tags.Contains(Tag.TwoHanded))
            {
                UnEquipItem(OffHandSlot.GetComponent<EquipSlot>().Item, OffHandSlot.gameObject); // drop item in offhand (if any)
            }
        }
        ListManager.InvDataManager.SaveEquipment(ListManager.Equipment);
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
            item.Location = null;
            var index = ListManager.Inventory.FindIndex(x => x.InstanceID == item.InstanceID);
            if (index >= 0)
            {
                ListManager.Inventory.RemoveAt(index);
            }
            if (item.Type == ItemType.Curio)
            {
                CurioItems.Add(item);
            }
        }
    }

    public void Swap(GameObject selectedItem, GameObject selectedSlot)
    {
        var invenItem = selectedItem.GetComponent<ItemOm>().Item;
        var equipSlot = selectedSlot.GetComponent<EquipSlot>();
        var equipItem = selectedSlot.GetComponent<EquipSlot>().Item;

        if (invenItem.Location == null)
        {
            UnEquipItem(equipItem.gameObject, selectedSlot);
            // equip selectedItem to equipSlot
            ItemOm.SetSelectedItem(selectedItem);
            equipSlot.Occupied = false;
            EquipCheck(selectedItem, selectedSlot);
        }
        else if (invenItem.Type == equipSlot.SlotType)
        {
            // pull item out of equipment Slot and store in highlighted slot
            var invenSlot = GridManager.slotGrid[invenItem.Location.X + invenItem.Size.x / 2, invenItem.Location.Y + invenItem.Size.y / 2];
            GridManager.highlightedSlot = invenSlot;
            GridManager.CheckArea(invenItem.Size);
            GridManager.StoreItem(equipItem);

            // equip selectedItem to equipSlot
            ItemOm.SetSelectedItem(selectedItem);
            equipSlot.Occupied = false;
            EquipCheck(selectedItem, selectedSlot);
        }
    }

    public void UnEquipItem(GameObject itemObject, GameObject selectedSlot)
    {
        if (itemObject != null)
        {
            // if item is a curio, remove from curio list
            if (itemObject.GetComponent<ItemOm>().Item.Type == ItemType.Curio)
            {
                CurioItems.Remove(itemObject.GetComponent<ItemOm>().Item);
            }
            foreach (var slot in GridManager.slotGrid)
            {
                GridManager.highlightedSlot = slot;
                GridManager.CheckArea(itemObject.GetComponent<ItemOm>().Item.Size);
                var checkState = GridManager.SlotCheck(GridManager.checkSize);
                if (checkState == 0)
                {
                    GridManager.StoreItem(itemObject);
                    if (selectedSlot != null)
                    {
                        var equipSlot = selectedSlot.GetComponent<EquipSlot>();
                        equipSlot.Occupied = false;
                        equipSlot.Item = null;
                    }
                    GridManager.highlightedSlot = null;
                    ItemOm.SelectedItem = null;
                    return;
                }
            }
        }
    }

    public void UpdateEquipment()
    {
        if (MainHandSlot != null && MainHandSlot.Occupied)
        {
            ListManager.Equipment.MainHand = MainHandSlot.Item.GetComponent<ItemOm>().Item;
        }
        else if (MainHandSlot != null)
        {
            ListManager.Equipment.MainHand = null;
        }
        if (ArmorSlot != null && ArmorSlot.Occupied)
        {
            ListManager.Equipment.Armor = ArmorSlot.Item.GetComponent<ItemOm>().Item;
        }
        else if (ArmorSlot != null)
        {
            ListManager.Equipment.Armor = null;
        }
        if (OffHandSlot != null && OffHandSlot.Occupied)
        {
            ListManager.Equipment.Offhand = OffHandSlot.Item.GetComponent<ItemOm>().Item;
        }
        else if (OffHandSlot != null)
        {
            ListManager.Equipment.Offhand = null;
        }
        ListManager.Equipment.Curios = CurioItems;
        ListManager.InvDataManager.SaveEquipment(ListManager.Equipment);
    }
}
