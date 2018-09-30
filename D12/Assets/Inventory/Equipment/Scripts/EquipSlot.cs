using Assets.Inventory.Scripts.Item.ItemModels;
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
        if (ItemOm.SelectedItem == null)
        {
            if (!Occupied) // if click on empty slot
            {
                return;
            }
            ItemOm.SetSelectedItem(Item);
            Item.transform.SetParent(GameObject.Find("DragParent").transform);
            ItemOm.IsDragging = true;
            Occupied = false;
            transform.GetComponent<Image>().color = SlotColorHighlights.Green;
        }
        else
        {
            Manager.EquipCheck(ItemOm.SelectedItem, gameObject);
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

    public void Equip(GameObject item)
    {
        Item = item;
    }

    public void Drop()
    {

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.GetComponent<Image>().color = SlotColorHighlights.Blue;
    }


}
