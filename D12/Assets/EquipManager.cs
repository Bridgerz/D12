using Assets.Inventory.Scripts.Item.ItemModels;
using Assets.Inventory.Scripts.Item.OM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipManager : MonoBehaviour {

    public GameObject EquipSlotPrefab;
    public GameObject MainSlotPanel;
    public ItemListManager ListManager;
    public InvenGridScript Grid;
    public int CurioSlotY;
    public int CurioSlotX;
    public EquipSlot MainHandSlot;
    public EquipSlot OffHandSlot;


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
                    obj.GetComponent<EquipSlot>().SlotType = ItemType.Weapon;
                    MainHandSlot = obj.GetComponent<EquipSlot>();
                    break;
                case 1:
                    obj.transform.name = "Armor Slot";
                    obj.GetComponent<EquipSlot>().SlotType = ItemType.Tagged;
                    break;
                case 2:
                    obj.transform.name = "Off Hand Slot";
                    obj.GetComponent<EquipSlot>().SlotType = ItemType.Weapon;
                    OffHandSlot = obj.GetComponent<EquipSlot>();
                    break;
            }
        }
        LoadEquipment();
	}

    public void Equip(GameObject itemObject, GameObject selectedSlot)
    {
        var item = itemObject.GetComponent<ItemOm>().Item;
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
        /*var item = itemObject.GetComponent<ItemOm>().Item;
        if (selectedSlot == MainHandSlot || selectedSlot == OffHandSlot) // if weapon shit
        {
            if (item.Tags.Contains(Tag.TwoHanded) && selectedSlot == MainHandSlot) // item is two handed being clicked on mainhandslot
            {
                if (selectedSlot.Occupied)
                {
                    // selectedSlot.swap 
                    // Offhand
                }

            }

            if (item.Tags.Contains(Tag.TwoHanded)) // if weapon to equip is two handed
            {
                MainHandSlot.Drop();
                OffHandSlot.Drop();
                MainHandSlot.Equip(itemObject);
            }
            else if (item.Tags.Contains(Tag.Light)) // if weapon to equip is light (can be main hand or offhand)
            {
                
            }
        }
        else // Armor/Curio shit
        {
            if (selectedSlot.Occupied)
            {
                selectedSlot.Drop();
                selectedSlot.Equip(itemObject);
            }
            else
            {
                selectedSlot.Equip(itemObject);
            }
        }*/
    }

    private void LoadEquipment()
    {
        // load equipment 
    }
}
