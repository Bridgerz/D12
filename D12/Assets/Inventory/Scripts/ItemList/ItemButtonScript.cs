using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Assets.Inventory.Scripts.Item;
using Assets.Inventory.Scripts.Item.ItemModels;
using Assets.Inventory.Scripts.Misc;

public class ItemButtonScript : MonoBehaviour ,IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler{

    public Button buttonComponent;
    public Text nameText;
    public Image iconImage;
    public Text LvlText;
    public Text QualityText;
    public Image QualityColor;

    public ItemDm item;
    private ItemListManager listManager;
    public ObjectPoolScript itemEquipPool;

    public GameObject toolTip;

    public static InvenGridManager invenManager;
    //public static ItemOverlayScript overlayScript;


    public void OnPointerDown(PointerEventData eventData)
    {
        if (Input.GetMouseButtonDown(0))// still spawns when drag scroll
        {
            if (ItemOm.SelectedItem == null)
            {
                if ((Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
                {
                    // auto add to inventory
                    SpawnStoredItem();
                    invenManager.Equipment.UnEquipItem(ItemOm.SelectedItem, null);
                    listManager.InvDataManager.SaveInventory(listManager.Inventory);
                    ItemOm.IsDragging = false;
                    listManager.invenManager.RemoveSelectedButton();
                    return;
                }
                SpawnStoredItem(); //swap item when no selectedButton and selectedItem
                toolTip.SetActive(false);
            }
            if (ItemOm.SelectedItem == null) // if selectedItem is still null then turn on too much weight animation
            {
                return;
            }
            if (ItemOm.SelectedItem.GetComponent<ItemOm>().Item.Type == ItemType.Curio)
            {
                invenManager.Equipment.CurioItems.Remove(ItemOm.SelectedItem.GetComponent<ItemOm>().Item);
            }
            invenManager.Equipment.UpdateEquipment();
            listManager.InvDataManager.SaveInventory(listManager.Inventory);
            listManager.AddSelectedItemToList();
            if (ItemOm.SelectedItem != null && invenManager.selectedButton != this.gameObject) // reset selected button when item is from list
            {
                invenManager.SubtractWeight(ItemOm.SelectedItem.GetComponent<ItemOm>().Item.Weight);
                invenManager.Equipment.UpdateWeight();
                invenManager.selectedButton.GetComponent<CanvasGroup>().alpha = 1f;
                invenManager.selectedButton = null;
                listManager.itemEquipPool.ReturnObject(ItemOm.SelectedItem);
                SpawnStoredItem();
            }
        }
        else if (Input.GetMouseButtonDown(1) && invenManager.selectedButton == null && ItemOm.SelectedItem == null)
        {
            toolTip.GetComponent<ItemToolTip>().UpdateActivateComplex(item);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        toolTip.SetActive(true);
        toolTip.GetComponent<RectTransform>().pivot = new Vector2(1.05f, 1.05f);
        toolTip.GetComponent<ItemToolTip>().UpdateActivateSimple(item);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        toolTip.SetActive(false);
    }

    private void SpawnStoredItem()
    {
        if (invenManager.AddWeight(item.Weight))
        {
            GameObject newItem = itemEquipPool.GetObject();

            newItem.GetComponent<ItemOm>().SetItemObject(item.Clone() as ItemDm);

            ItemOm.SetSelectedItem(newItem);
            invenManager.selectedButton = this.gameObject;

            GetComponent<CanvasGroup>().alpha = 0.5f;
            invenManager.Equipment.UpdateWeight();
        }
        else
        {
            ItemOm.SelectedItem = null;
        }
    }

    public void SetUpButton(ItemDm passedItem, ItemListManager passedListManager)
    {
        listManager = passedListManager;
        item = passedItem;
        nameText.text = passedItem.Title;
        QualityText.text = passedItem.Quality.ToString();
        GetComponent<LayoutElement>().preferredHeight = transform.parent.GetComponent<RectTransform>().rect.width / 4;
        iconImage.sprite = passedItem.Icon;
        itemEquipPool = passedListManager.itemEquipPool;
        switch ((int)item.Quality.GetTypeCode())
        {
            case 0: QualityColor.color = Color.gray; break;
            case 1: QualityColor.color = Color.white; break;
            case 2: QualityColor.color = new Color(0.5f, 0.5f, 1f, 1f); break;
            case 3: QualityColor.color = Color.yellow; break;
            default: break;
        }

        float iconSize = listManager.iconSize;
        RectTransform rect = iconImage.GetComponent<RectTransform>();
        if (passedItem.Size.y >= passedItem.Size.x)
        {
            rect.sizeDelta = new Vector2(iconSize / IntVector2.Slope(passedItem.Size), iconSize);
        }
        else
        {
            rect.sizeDelta = new Vector2(iconSize, iconSize * IntVector2.Slope(passedItem.Size));
        }
    }

    
}
