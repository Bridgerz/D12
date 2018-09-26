using Assets.Inventory.Scripts.Item.ItemModels;
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
        if (ItemOm.SelectedItem == null)
        {
            if (Occupied)
            {
                ItemOm.SelectedItem = Item;
                Item.transform.SetParent(GameObject.Find("DragParent").transform);
                ItemOm.IsDragging = true;
                Occupied = false;
            }
            else
            {
                return;
            }
        }
        else
        {
            Manager.Equip(ItemOm.SelectedItem, gameObject);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (ItemOm.SelectedItem == null)
        {
            return;
        }
        if (ItemOm.SelectedItem.GetComponent<ItemOm>().Item.Type != SlotType)
        {
            transform.GetComponent<Image>().color = SlotColorHighlights.Red;
        }
        else if (Occupied)
        {
            transform.GetComponent<Image>().color = SlotColorHighlights.Yellow;
        }
        else
        {
            transform.GetComponent<Image>().color = SlotColorHighlights.Green;
        }
    }

    public void Equip(GameObject item)
    {
        Item = item;
    }

    public void Drop()
    {

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (ItemOm.SelectedItem == null)
        {
            return;
        }
        transform.GetComponent<Image>().color = SlotColorHighlights.Blue;
    }


}
