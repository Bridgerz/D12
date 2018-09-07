using Assets.Inventory.Scripts.Item;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotSectorScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    public GameObject slotParent;
    public int QuadNum;
    public static IntVector2 posOffset;
    public static SlotSectorScript sectorScript;
    // public static ItemOverlayScript overlayScript;
    private InvenGridManager invenGridManager;
    private SlotScript parentSlotScript;

    private void Start()
    {
        
        invenGridManager = this.gameObject.transform.parent.parent.GetComponent<InvenGridManager>();
        parentSlotScript = slotParent.GetComponent<SlotScript>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        sectorScript = this;
        invenGridManager.highlightedSlot = slotParent;
        PosOffset();
        if (ItemManager.SelectedItem != null)
        {
            invenGridManager.RefrechColor(true);
        }
        if (parentSlotScript.storedItemObject != null && ItemManager.SelectedItem == null)
        {
            invenGridManager.ColorChangeLoop(SlotColorHighlights.Blue, parentSlotScript.storedItemSize, parentSlotScript.storedItemStartPos);
        }
        if (parentSlotScript.storedItemObject != null)
        {
            //overlayScript.UpdateOverlay(parentSlotScript.storedItemClass);
        }

    }

    public void PosOffset()
    {
        if (ItemManager.SelectedItemSize.x != 0 && ItemManager.SelectedItemSize.x % 2 == 0)
        {
            switch (QuadNum)
            {
                case 1:
                    posOffset.x = 0; break;
                case 2:
                    posOffset.x = -1; break;
                case 3:
                    posOffset.x = 0; break;
                case 4:
                    posOffset.x = -1; break;
                default: break;
            }
        }
        if (ItemManager.SelectedItemSize.y != 0 && ItemManager.SelectedItemSize.y % 2 == 0)
        {
            switch (QuadNum)
            {
                case 1:
                    posOffset.y = -1; break;
                case 2:
                    posOffset.y = -1; break;
                case 3:
                    posOffset.y = 0; break;
                case 4:
                    posOffset.y = 0; break;
                default: break;
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        sectorScript = null;
        invenGridManager.highlightedSlot = null;
        //overlayScript.UpdateOverlay(null);
        if (ItemManager.SelectedItem != null)
        {
            invenGridManager.RefrechColor(false);
        }
        posOffset = IntVector2.Zero;
        if (parentSlotScript.storedItemObject != null && ItemManager.SelectedItem == null)
        {
            invenGridManager.ColorChangeLoop(SlotColorHighlights.Blue2, parentSlotScript.storedItemSize, parentSlotScript.storedItemStartPos);
        }
    }
}
