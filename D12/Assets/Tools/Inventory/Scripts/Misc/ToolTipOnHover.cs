using Assets.Inventory.Scripts.Misc;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToolTipOnHover : MonoBehaviour, IPointerExitHandler
{
    public ItemListManager listManager;

    public void OnPointerExit(PointerEventData eventData)
    {
        listManager.ToolTip.GetComponent<ItemToolTip>().DeactivateReset();
    }
}
