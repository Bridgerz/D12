using Assets.Inventory.Scripts.InventoryGrid;
using Assets.Inventory.Scripts.Item;
using Assets.Inventory.Scripts.Item.ItemModels;
using Assets.Inventory.Scripts.Item.OM;
using Assets.Inventory.Scripts.ItemObject;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvenGridManager : MonoBehaviour {

    public GameObject[,] slotGrid;
    public GameObject highlightedSlot;
    public Transform dropParent;
    [HideInInspector]
    public IntVector2 gridSize;

    public ItemListManager listManager;
    public GameObject selectedButton;
    public IntVector2 checkSize;
    public EquipManager Equipment;
    
    public IntVector2 totalOffset, checkStartPos;
    public IntVector2 otherItemPos, otherItemSize;

    private int checkState;
    private bool isOverEdge = false;

    public int MaxWeight;
    public int CurrentWeight;

    private void Start()
    {
        MaxWeight = 50;
        CurrentWeight = 0;
        ItemButtonScript.invenManager = this;
        if (listManager.Inventory.Count > 0)
        {
            LoadInventoryObjects(listManager.Inventory);
        }
    }

    private void LoadInventoryObjects(List<ItemDm> inventory)
    {
        foreach (var item in inventory)
        {
            // create object
            GameObject newItem = listManager.itemEquipPool.GetObject();
            var newItemDm = item.Clone() as ItemDm;
            item.InstanceID = newItemDm.InstanceID;
            newItem.GetComponent<ItemOm>().SetItemObject(newItemDm);
            CurrentWeight += item.Weight;
            // store object
            var slot = slotGrid[item.Location.X + item.Size.x / 2, item.Location.Y + item.Size.y / 2];
            highlightedSlot = slot;
            CheckArea(item.Size);
            StoreItem(newItem);
            newItem.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        }
        highlightedSlot = null;
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0)) // left click
        {
            if (highlightedSlot != null && ItemOm.SelectedItem != null && !isOverEdge)
            {
                switch (checkState)
                {
                    //store on empty slots
                    case 0: 
                        StoreItem(ItemOm.SelectedItem);
                        ColorChangeLoop(SlotColorHighlights.Blue, ItemOm.SelectedItemSize, totalOffset);
                        ItemOm.ResetSelectedItem();
                        RemoveSelectedButton();
                        break;
                    //swap items
                    case 1: 
                        ItemOm.SetSelectedItem(SwapItem(ItemOm.SelectedItem));
                        SlotSectorScript.sectorScript.PosOffset();
                        ColorChangeLoop(SlotColorHighlights.Gray, otherItemSize, otherItemPos); //*1
                        RefrechColor(true);
                        RemoveSelectedButton();
                        break;
                }
                listManager.InvDataManager.SaveInventory(listManager.Inventory);
            }
            // retrieve items
            else if (highlightedSlot != null && ItemOm.SelectedItem == null && highlightedSlot.GetComponent<SlotScript>().isOccupied == true)
            {
                ColorChangeLoop(SlotColorHighlights.Gray, highlightedSlot.GetComponent<SlotScript>().storedItemSize, highlightedSlot.GetComponent<SlotScript>().storedItemStartPos);
                ItemOm.SetSelectedItem(GetItem(highlightedSlot));
                ItemOm.SelectedFromEquipment = false;
                SlotSectorScript.sectorScript.PosOffset();
                RefrechColor(true);
                listManager.InvDataManager.SaveInventory(listManager.Inventory);
            }
            
        }
        else if (Input.GetMouseButtonUp(1)) // right click
        {
            if (highlightedSlot != null && ItemOm.SelectedItem == null && highlightedSlot.GetComponent<SlotScript>().isOccupied == true)
            {
                RightClickEquip();
            }
        }
    }

    private void RightClickEquip()
    {
        var item = highlightedSlot.GetComponent<SlotScript>().storedItemObject;
        var type = highlightedSlot.GetComponent<SlotScript>().storedItemClass.Item.Type;
        var tempHighlightedSlot = highlightedSlot;
        switch (type)
        {
            case ItemType.Armor:
                ColorChangeLoop(SlotColorHighlights.Gray, highlightedSlot.GetComponent<SlotScript>().storedItemSize, highlightedSlot.GetComponent<SlotScript>().storedItemStartPos);
                SlotSectorScript.sectorScript.ZeroOffset();
                GetItem(highlightedSlot);
                SlotSectorScript.sectorScript.ZeroOffset();
                Equipment.EquipCheck(item, Equipment.ArmorSlot.gameObject);
                highlightedSlot = tempHighlightedSlot;
                RefrechColor(false);
                break;
            case ItemType.Curio:
                foreach (var slot in Equipment.CurioSlots)
                {
                    if (!slot.Occupied)
                    {
                        ColorChangeLoop(SlotColorHighlights.Gray, highlightedSlot.GetComponent<SlotScript>().storedItemSize, highlightedSlot.GetComponent<SlotScript>().storedItemStartPos);
                        GetItem(highlightedSlot);
                        SlotSectorScript.sectorScript.ZeroOffset();
                        Equipment.EquipCheck(item, slot.gameObject);
                        highlightedSlot = tempHighlightedSlot;
                        RefrechColor(false);
                        break;
                    }
                }
                break;
            case ItemType.Wielded:
                var mainHandStatus = Equipment.EquipStatus(item, Equipment.MainHandSlot.gameObject);
                var offHandStatus = Equipment.EquipStatus(item, Equipment.OffHandSlot.gameObject);
                ColorChangeLoop(SlotColorHighlights.Gray, highlightedSlot.GetComponent<SlotScript>().storedItemSize, highlightedSlot.GetComponent<SlotScript>().storedItemStartPos);
                GetItem(highlightedSlot);
                SlotSectorScript.sectorScript.ZeroOffset();
                if (mainHandStatus == 1) // if mainhand is green equip 
                {
                    Equipment.EquipCheck(item, Equipment.MainHandSlot.gameObject);
                }
                else if (offHandStatus == 1) // if offhand is green equip 
                {
                    Equipment.EquipCheck(item, Equipment.OffHandSlot.gameObject);
                }
                else if (mainHandStatus == 2) // if mainhand is swapable swap 
                {
                    Equipment.EquipCheck(item, Equipment.MainHandSlot.gameObject);
                }
                else if (offHandStatus == 2)
                {
                    Equipment.EquipCheck(item, Equipment.OffHandSlot.gameObject);

                }
                else // shields
                {
                    Equipment.UnEquipItem(Equipment.MainHandSlot.GetComponent<EquipSlot>().Item, Equipment.MainHandSlot.gameObject);
                    Equipment.EquipCheck(item, Equipment.OffHandSlot.gameObject);
                }
                highlightedSlot = tempHighlightedSlot;
                RefrechColor(false);
                break;
            default:
                break;
        }
        Equipment.UpdateEquipment();
        listManager.InvDataManager.SaveInventory(listManager.Inventory);
    }

    public void CheckArea(IntVector2 itemSize) //*2
    {
        IntVector2 halfOffset;
        IntVector2 overCheck;
        halfOffset.x = (itemSize.x - (itemSize.x % 2 == 0 ? 0 : 1)) / 2;
        halfOffset.y = (itemSize.y - (itemSize.y % 2 == 0 ? 0 : 1)) / 2;
        totalOffset = highlightedSlot.GetComponent<SlotScript>().gridPos - (halfOffset + SlotSectorScript.posOffset);
        checkStartPos = totalOffset;
        checkSize = itemSize;
        overCheck = totalOffset + itemSize;
        isOverEdge = false;
        //checks if item to stores is outside grid
        if (overCheck.x > gridSize.x)
        {
            checkSize.x = gridSize.x - totalOffset.x;
            isOverEdge = true;
        }
        if (totalOffset.x < 0)
        {
            checkSize.x = itemSize.x + totalOffset.x;
            checkStartPos.x = 0;
            isOverEdge = true;
        }
        if (overCheck.y > gridSize.y)
        {
            checkSize.y = gridSize.y - totalOffset.y;
            isOverEdge = true;
        }
        if (totalOffset.y < 0)
        {
            checkSize.y = itemSize.y + totalOffset.y;
            checkStartPos.y = 0;
            isOverEdge = true;
        }
    }

    public int SlotCheck(IntVector2 itemSize)//*2
    {
        GameObject obj = null;
        SlotScript instanceScript;
        if (!isOverEdge)
        {
            for (int y = 0; y < itemSize.y; y++)
            {
                for (int x = 0; x < itemSize.x; x++)
                {
                    instanceScript = slotGrid[checkStartPos.x + x, checkStartPos.y + y].GetComponent<SlotScript>();
                    if (instanceScript.isOccupied)
                    {
                        if (obj == null)
                        {
                            obj = instanceScript.storedItemObject;
                            otherItemPos = instanceScript.storedItemStartPos;
                            otherItemSize = obj.GetComponent<ItemOm>().Item.Size;
                        }
                        else if (obj != instanceScript.storedItemObject)
                        {
                            return 2; // if cheack Area has 1+ item occupied
                        }
                    }
                }
            }
            if (obj == null)
                return 0; // if checkArea is not accupied
            else
                return 1; // if checkArea only has 1 item occupied
        }
        return 2; // check areaArea is over the grid
    }

    public void RefrechColor(bool enter)
    {
        if (enter)
        {
            CheckArea(ItemOm.SelectedItemSize);
            checkState = SlotCheck(checkSize);
            switch (checkState)
            {
                case 0: ColorChangeLoop(SlotColorHighlights.Green, checkSize, checkStartPos); break; //no item in area
                case 1:
                    ColorChangeLoop(SlotColorHighlights.Yellow, otherItemSize, otherItemPos); //1 item on area and can swap
                    ColorChangeLoop(SlotColorHighlights.Green, checkSize, checkStartPos);
                    break;
                case 2: ColorChangeLoop(SlotColorHighlights.Red, checkSize, checkStartPos); break; //invalid position (more then 2 items in area or area is outside grid)
            }
        }
        else //on pointer exit. resets colors
        {
            isOverEdge = false;
            ColorChangeLoop2(checkSize, checkStartPos);
            if (checkState == 1)
            {
                ColorChangeLoop(SlotColorHighlights.Blue2, otherItemSize, otherItemPos);
            }
        }
    }

    public void ColorChangeLoop(Color32 color, IntVector2 size, IntVector2 startPos)
    {
        for (int y = 0; y < size.y; y++)
        {
            for (int x = 0; x < size.x; x++)
            {
                slotGrid[startPos.x + x, startPos.y + y].GetComponent<Image>().color = color;
            }
        }
    }

    public void ColorChangeLoop2(IntVector2 size, IntVector2 startPos)
    {
        GameObject slot;
        for (int y = 0; y < size.y; y++)
        {
            for (int x = 0; x < size.x; x++)
            {
                slot = slotGrid[startPos.x + x, startPos.y + y];
                if (slot.GetComponent<SlotScript>().isOccupied != false)
                {
                    slotGrid[startPos.x + x, startPos.y + y].GetComponent<Image>().color = SlotColorHighlights.Blue2;
                }
                else
                {
                    slotGrid[startPos.x + x, startPos.y + y].GetComponent<Image>().color = SlotColorHighlights.Gray;
                }
            }
        }
    }

    public void StoreItem(GameObject itemObject)
    {
        var item = itemObject.GetComponent<ItemOm>().Item;
        SlotScript instanceScript;
        IntVector2 itemSizeL = itemObject.GetComponent<ItemOm>().Item.Size;
        item.Location = new SlotLocation(totalOffset.x, totalOffset.y);
        for (int y = 0; y < itemSizeL.y; y++)
        {
            for (int x = 0; x < itemSizeL.x; x++)
            {
                //set each slot parameters
                instanceScript = slotGrid[totalOffset.x + x, totalOffset.y + y].GetComponent<SlotScript>();
                instanceScript.storedItemObject = itemObject;
                instanceScript.storedItemClass = itemObject.GetComponent<ItemOm>();
                instanceScript.storedItemSize = itemSizeL;
                instanceScript.storedItemStartPos = totalOffset;
                instanceScript.isOccupied = true;
                slotGrid[totalOffset.x + x, totalOffset.y + y].GetComponent<Image>().color = SlotColorHighlights.Gray;
            }
        }
        //set dropped parameters
        itemObject.transform.SetParent(dropParent);
        itemObject.GetComponent<RectTransform>().pivot = Vector2.zero;
        itemObject.transform.position = slotGrid[totalOffset.x, totalOffset.y].transform.position;
        itemObject.GetComponent<CanvasGroup>().alpha = 1f;

        // check if item was already in Inventory
        var index = listManager.Inventory.FindIndex(x => x.InstanceID == item.InstanceID);
        if (index >= 0)
        {
            listManager.Inventory[index].Location = item.Location;
        }
        else
        {
            listManager.Inventory.Add(item);
        }

        // save both equipment and inventory if both were affected else save inventory
        if (ItemOm.SelectedFromEquipment)
        {
            if (ItemOm.SelectedItem.GetComponent<ItemOm>().Item.Type == ItemType.Curio)
            {
                Equipment.CurioItems.Remove(ItemOm.SelectedItem.GetComponent<ItemOm>().Item);
            }
            Equipment.UpdateEquipment();
            listManager.InvDataManager.SaveEquipAndInv(listManager.Equipment, listManager.Inventory);
        }
        else
        {
            listManager.InvDataManager.SaveInventory(listManager.Inventory);
        }
    }

    private GameObject GetItem(GameObject slotObject)
    {
        SlotScript slotObjectScript = slotObject.GetComponent<SlotScript>();
        GameObject retItem = slotObjectScript.storedItemObject;
        IntVector2 tempItemPos = slotObjectScript.storedItemStartPos;
        IntVector2 itemSizeL = retItem.GetComponent<ItemOm>().Item.Size;

        SlotScript instanceScript;
        for (int y = 0; y < itemSizeL.y; y++)
        {
            for (int x = 0; x < itemSizeL.x; x++)
            {
                //reset each slot parameters
                instanceScript = slotGrid[tempItemPos.x + x, tempItemPos.y + y].GetComponent<SlotScript>();
                instanceScript.storedItemObject = null;
                instanceScript.storedItemSize = IntVector2.Zero;
                instanceScript.storedItemStartPos = IntVector2.Zero;
                instanceScript.storedItemClass = null;
                instanceScript.isOccupied = false;
            }
        }
        //returned item set item parameters
        retItem.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
        retItem.GetComponent<CanvasGroup>().alpha = 0.5f;
        retItem.transform.position = Input.mousePosition;
        return retItem;
    }

    public GameObject SwapItem(GameObject item)
    {
        GameObject tempItem;
        tempItem = GetItem(slotGrid[otherItemPos.x, otherItemPos.y]);
        StoreItem(item);
        return tempItem;
    }

    public void RemoveSelectedButton()
    {
        if (selectedButton != null)
        {
            listManager.RevomeItemFromList(selectedButton.GetComponent<ItemButtonScript>().item);
            listManager.RemoveButton(selectedButton);
            listManager.sortManager.SortAndFilterList();
            selectedButton = null;
        }
    }

    public bool AddWeight(int weight)
    {
        if (CurrentWeight + weight <= MaxWeight)
        {
            CurrentWeight += weight;
            return true;
        }
        return false;
    }

    public void SubtractWeight(int weight)
    {
        CurrentWeight -= weight;
    }
}


public struct SlotColorHighlights
{
    public static Color32 Green
    { get { return new Color32(127, 223, 127, 255); } }
    public static Color32 Yellow
    { get { return new Color32(223, 223, 63, 255); } }
    public static Color32 Red
    { get { return new Color32(223, 127, 127, 255); } }
    public static Color32 Blue
    { get { return new Color32(159, 159, 223, 255); } }
    public static Color32 Blue2
    { get { return new Color32(191, 191, 223, 0); } }
    public static Color32 Gray
    { get { return new Color32(223, 223, 223, 0); } }
}
