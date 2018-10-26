using Assets.Inventory.Scripts.Item.ItemModels;
using Assets.Tools.Inventory.Scripts.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Inventory.Scripts.Misc
{
   
    public class ItemToolTip : MonoBehaviour
    {
        public SimpleToolTip SimpleToolTip;
        public ComplexToolTip ComplexToolTip;
        public ItemDm ComplexItem;

        public bool ComplexActive;

        private void Start()
        {
            ComplexToolTip.gameObject.SetActive(false);
            ComplexActive = false;
        }

        private void Update()
        {
            // if right click and the Complex Tool tip is active
            if (Input.GetMouseButtonDown(0) && ComplexActive)
            {
                ComplexItem = null;
                ComplexToolTip.gameObject.SetActive(false);
            }
        }

        public void UpdateSimple(ItemDm item, GameObject itemObject, bool left)
        {
            if (ComplexItem != item)
            {
                SimpleToolTip.gameObject.SetActive(true);
                SimpleToolTip.UpdateObject(item, itemObject, left);
            }
        }

        public void UpdateComplex(ItemDm item, GameObject itemObject, bool left)
        {
            if (ComplexItem != item)
            {
                SimpleToolTip.gameObject.SetActive(false);
                ComplexItem = item;
                ComplexToolTip.gameObject.SetActive(true);
                ComplexActive = true;
                ComplexToolTip.UpdateObject(item, itemObject, left);
            }
        }

        public void DeactivateReset()
        {
            SimpleToolTip.gameObject.SetActive(false);
        }

    }
}
