using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryBook : MonoBehaviour {
    public bool isDragging;
	// Use this for initialization
	void Start () {
        isDragging = false;
	}
	
	// Update is called once per frame
	void Update () {
	    if (isDragging)
        {
            this.enabled = false;
        }	
        else
        {
            this.enabled = true;
        }
	}
}
