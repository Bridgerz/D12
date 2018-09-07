using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotScript : MonoBehaviour
{
    public IntVector2 gridPos;

    public GameObject storedItemObject;
    public IntVector2 storedItemSize;
    public IntVector2 storedItemStartPos;
    public ItemDm storedItemClass;
    public bool isOccupied;

    private void Start()
    {
        
    }
}
