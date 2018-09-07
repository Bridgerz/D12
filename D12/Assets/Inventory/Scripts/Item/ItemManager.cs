using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Inventory.Scripts.Item
{
    public class ItemManager : MonoBehaviour
    {
        public static GameObject SelectedItem;
        public static IntVector2 SelectedItemSize;
        public static bool IsDragging = false;


        private void Update()
        {
            if (IsDragging)
            {
                SelectedItem.transform.position = Input.mousePosition;
            }
        }

        public static void SetSelectedItem(GameObject obj)
        {
            SelectedItem = obj;
            SelectedItemSize = obj.GetComponent<ItemOm>().Size;
            IsDragging = true;
            obj.transform.SetParent(GameObject.FindGameObjectWithTag("DragParent").transform);
            obj.GetComponent<RectTransform>().localScale = Vector3.one;
        }

        public static void ResetSelectedItem()
        {
            SelectedItem = null;
            SelectedItemSize = IntVector2.Zero;
            IsDragging = false;
        }

    }
}
