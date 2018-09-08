using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotScript : MonoBehaviour
{
    public IntVector2 gridPos;
    public GameObject storedItemObject { get; set; }
    public IntVector2 storedItemSize { get; set; }
    public IntVector2 storedItemStartPos { get; set; }
    public ItemOm storedItemClass { get; set; }
    public bool isOccupied { get; set; }
}
