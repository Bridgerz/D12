using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolBoxToggle : MonoBehaviour {
    public bool Visible;
    public GameObject ToolBox;

	void Start () {
        Visible = true;
	}
    
    public void ToggleToolBox()
    {
        if (Visible)
        {
            ToolBox.SetActive(false);
            Visible = false;
        }
        else
        {
            ToolBox.SetActive(true);
            Visible = true;
        }
    }

}
