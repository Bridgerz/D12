﻿using Assets.Inventory.Scripts.Item.ItemModels;
using Assets.Inventory.Scripts.Item.OM;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public EquipManager Manager;
    public GameObject Item;
    public bool Occupied;
    public ItemType SlotType;

    public void Start()
    {
        Manager = GameObject.Find("Equipment Panel").GetComponent<EquipManager>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Input.GetMouseButtonUp(0)) // left click
        {
            if (ItemOm.SelectedItem == null)
            {
                if (!Occupied) // if click on empty slot
                {
                    return;
                }
                ItemOm.SetSelectedItem(Item);
                ItemOm.SelectedFromEquipment = true;
                Item.transform.SetParent(GameObject.Find("DragParent").transform);
                ItemOm.IsDragging = true;
                Occupied = false;
                transform.GetComponent<Image>().color = SlotColorHighlights.Green;
            }
            else
            {
                //Equip selected Item to this slot;
                Manager.EquipCheck(ItemOm.SelectedItem, gameObject);
                Manager.UpdateEquipment();
                if (!ItemOm.SelectedFromEquipment)
                {
                    Manager.ListManager.InvDataManager.SaveInventory(Manager.ListManager.Inventory);
                }
                transform.GetComponent<Image>().color = SlotColorHighlights.Blue;
                Manager.GridManager.highlightedSlot = null;
            }
        }
        else if (Input.GetMouseButtonUp(1))
        {
            if (Occupied && ItemOm.SelectedItem == null) // if selected slot is occupied and there is no selected item
            {
                Manager.UnEquipItem(Item, gameObject);
                Manager.UpdateEquipment();
                Manager.ListManager.InvDataManager.SaveInventory(Manager.ListManager.Inventory);
                transform.GetComponent<Image>().color = SlotColorHighlights.Blue;
            }
        }
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (ItemOm.SelectedItem == null)
        {
            return;
        }
        int status = Manager.EquipStatus(ItemOm.SelectedItem, gameObject);
        if (status == 0)
        {
            transform.GetComponent<Image>().color = SlotColorHighlights.Red;
        }
        else if (status == 1)
        {
            transform.GetComponent<Image>().color = SlotColorHighlights.Green;
        }
        else
        {
            transform.GetComponent<Image>().color = SlotColorHighlights.Yellow;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.GetComponent<Image>().color = SlotColorHighlights.Blue;
    }
}
