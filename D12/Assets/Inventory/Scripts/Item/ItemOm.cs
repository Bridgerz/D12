using Assets.Inventory.Scripts.Item;
using Assets.Inventory.Scripts.ItemObject;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemOm : MonoBehaviour
{
    private GameObject InvenPanel;
    private float SlotSize;

    public ItemDm Item;
    public static GameObject SelectedItem;
    public static IntVector2 SelectedItemSize;
    public static bool IsDragging = false;

    private void Awake()
    {
        SlotSize = GameObject.FindGameObjectWithTag("InvenPanel").GetComponent<InvenGridScript>().slotSize;
    }

    public void SetItemObject(ItemDm passedItem)
    {
        RectTransform rect = GetComponent<RectTransform>();
        rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, passedItem.Size.x * SlotSize);
        rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, passedItem.Size.y * SlotSize);
        Item = passedItem;
        GetComponent<Image>().sprite = passedItem.Icon;
    }

    private void Update()
    {
        if (IsDragging)
        {
            SelectedItem.transform.position = Input.mousePosition;
        }
    }

    public static void SetSelectedItem(GameObject obj)
    {
        SelectedItem = obj;
        SelectedItemSize = obj.GetComponent<ItemOm>().Item.Size;
        IsDragging = true;
        obj.transform.SetParent(GameObject.FindGameObjectWithTag("DragParent").transform);
        obj.GetComponent<RectTransform>().localScale = Vector3.one;
    }

    public static void ResetSelectedItem()
    {
        SelectedItem = null;
        SelectedItemSize = IntVector2.Zero;
        IsDragging = false;
    }

}
