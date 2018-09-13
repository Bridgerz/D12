﻿using Assets.Inventory.Scripts.Item;
using System.Collections.Generic;
using UnityEngine;

public class ItemListManager : MonoBehaviour {
    public ObjectPoolScript itemButtonPool;
    public ObjectPoolScript itemEquipPool;
    public InvenGridManager invenManager;
    public LoadItemDatabase itemDB;
    public SortAndFilterManager sortManager;

    public float iconSize;
    
    public List<ItemDm> startItemList; // created and initialized on LoadSaveItems
    public List<GameObject> currentButtonList;
    public List<ItemDm> currentItemList;
    public List<ItemDm> Inventory;

    private Transform contentPanel;

    private void Start()
    {
        contentPanel = this.transform;
    }

    private void Update()
    {
        //right click to return item to list if item is from list
        if (Input.GetMouseButtonDown(1) && invenManager.selectedButton != null) 
        {
            invenManager.RefrechColor(false);
            invenManager.selectedButton.GetComponent<CanvasGroup>().alpha = 1f;
            invenManager.selectedButton = null;
            itemEquipPool.ReturnObject(ItemOm.SelectedItem);
            ItemOm.ResetSelectedItem();
        }
    }

    public void AddSelectedItemToList()
    {
        //add item to list if item is not from list
        if (invenManager.selectedButton == null && ItemOm.SelectedItem != null) 
        {
            ItemDm item = ItemOm.SelectedItem.GetComponent<ItemOm>().Item;
            sortManager.AddItemToList(item);
            itemEquipPool.ReturnObject(ItemOm.SelectedItem);
            ItemOm.ResetSelectedItem();
        }
    }

    public void PopulateList(List<ItemDm> passedItemlist)
    {
        if (currentButtonList.Count > 0)
        {
            for (int i = currentButtonList.Count - 1; i >= 0; i--)
            {
                RemoveButton(currentButtonList[i]);
            }
        }
        foreach (var item in passedItemlist)
        {
            AddButton(item);
        }
    }

    public void AddButton(ItemDm addItem)
    {
        GameObject newButton = itemButtonPool.GetObject();
        newButton.transform.SetParent(contentPanel);
        newButton.GetComponent<RectTransform>().localScale = Vector3.one;
        newButton.GetComponent<ItemButtonScript>().SetUpButton(addItem, this);
        currentButtonList.Add(newButton);
    }

    public void RemoveButton(GameObject buttonObj)
    {
        buttonObj.GetComponent<CanvasGroup>().alpha = 1f;
        currentButtonList.Remove(buttonObj);
        itemButtonPool.ReturnObject(buttonObj);
    }

    //used to remove from list when placing item on grid or deleting item
    public void RevomeItemFromList(ItemDm itemToRemove)
    {
        var i = currentItemList.FindIndex(x => x.GlobalID == itemToRemove.GlobalID);
        if (i >= 0)
        {
            currentItemList.RemoveAt(i);
        }
    }

}