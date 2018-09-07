using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Assets.Inventory.Scripts.Item;

public class ItemButtonScript : MonoBehaviour ,IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler{

    public Button buttonComponent;
    public Text nameText;
    public Image iconImage;
    public Text LvlText;
    public Text QualityText;
    public Image QualityColor;

    public ItemOm item;
    private ItemListManager listManager;
    public ObjectPoolScript itemEquipPool;

    public static InvenGridManager invenManager;
    //public static ItemOverlayScript overlayScript;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (Input.GetMouseButtonDown(0))// still spawns when drag scroll
        {
            if (ItemManager.SelectedItem == null)
            {
                SpawnStoredItem(); //swap item when no selectedButton and selectedItem
            }
            listManager.AddSelectedItemToList();
            if (ItemManager.SelectedItem != null && invenManager.selectedButton != this.gameObject) // reset selected button when item is from list
            {
                invenManager.selectedButton.GetComponent<CanvasGroup>().alpha = 1f;
                invenManager.selectedButton = null;
                listManager.itemEquipPool.ReturnObject(ItemManager.SelectedItem);
                SpawnStoredItem();
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //overlayScript.UpdateOverlay(item);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //overlayScript.UpdateOverlay(null);
    }

    private void SpawnStoredItem()
    {
        GameObject newItem = itemEquipPool.GetObject();
        newItem.GetComponent<ItemOm>().SetItemObject(item);

        ItemManager.SetSelectedItem(newItem);
        invenManager.selectedButton = this.gameObject;

        GetComponent<CanvasGroup>().alpha = 0.5f;
    }

    public void SetUpButton(ItemOm passedItem, ItemListManager passedListManager)
    {
        listManager = passedListManager;
        item = passedItem;
        nameText.text = passedItem.Item.Title;
        QualityText.text = passedItem.Item.Quality.ToString();
        GetComponent<LayoutElement>().preferredHeight = transform.parent.GetComponent<RectTransform>().rect.width / 4;
        iconImage.sprite = passedItem.Icon;
        itemEquipPool = passedListManager.itemEquipPool;
        switch ((int)item.Item.Quality.GetTypeCode())
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
