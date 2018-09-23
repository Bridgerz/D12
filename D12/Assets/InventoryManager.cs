using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {

    public InvenGridManager grid;
    public AutoFlip flipper;

	// Update is called once per frame
	void Update () {
		if (flipper.isPageFlipping)
        {
            grid.transform.gameObject.SetActive(false);
        }
        else
        {
            grid.transform.gameObject.SetActive(true);
        }
	}
}
