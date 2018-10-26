using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolScript : MonoBehaviour {
    public GameObject ToolPanel;
    public bool IsActive;

    public void Start()
    {
        // set IsActive to previous state
        IsActive = false;
    }

    public void ToggleActive()
    {
        if (IsActive)
        {
            ToolPanel.SetActive(false);
            IsActive = false;
            // SaveState();
        }
        else
        {
            ToolPanel.SetActive(true);
            IsActive = true;
            // SaveState();
        }
    }
}
