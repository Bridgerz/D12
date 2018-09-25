using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipManager : MonoBehaviour {

    public GameObject EquipSlotPrefab;
    public InvenGridScript Grid;


	void Start () {
        for (int i = 0; i < 3; i++) {
            GameObject obj = (GameObject)Instantiate(EquipSlotPrefab);
            obj.transform.SetParent(this.transform);
            RectTransform rect = obj.transform.GetComponent<RectTransform>();
            rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Grid.slotSize);
            rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Grid.slotSize * 2);
            obj.GetComponent<RectTransform>().localScale = Vector3.one;
            switch (i)
            {
                case 0:
                    obj.transform.name = "Main Hand Slot";
                    break;
                case 1:
                    obj.transform.name = "Armor Slot";
                    // set armor location
                    break;
                case 2:
                    obj.transform.name = "Off Hand Slot";
                    // set off hand location
                    break;
            }
        }
        // create the amount of curio slots (with the correct sizes)

        // 
	}
}
