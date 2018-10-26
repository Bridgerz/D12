using Assets.Inventory.Scripts.Item.ItemModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Tools.Inventory.Scripts.Misc
{
    public class SimpleToolTip : MonoBehaviour
    {
        // Simple Tool Tip
        public GameObject Weight;
        public GameObject Title;
        public GameObject QualitySubType;

        public GameObject AverageDamage;
        public GameObject Defence;

        public void UpdateObject(ItemDm item, GameObject itemObject, bool left)
        {
            gameObject.GetComponent<Image>().raycastTarget = false;
            SetPosition(itemObject, left);
            // deactivate variable attributes
            AverageDamage.SetActive(false);
            Defence.SetActive(false);

            UpdateEssentials(item);

            switch (item.Type)
            {
                case ItemType.Armor:
                    SetDefence(item);
                    break;
                case ItemType.Wielded:
                    SetAverageDamage(item);
                    break;
                default:
                    break;
            }
        }

        private void SetPosition(GameObject itemObject, bool left)
        {
            var pivot = itemObject.GetComponent<RectTransform>().pivot;
            var objectRect = itemObject.GetComponent<RectTransform>();
            var offset = new Vector3();
            if (pivot == new Vector2(.5f, .5f) && left)
            {
                offset = offset = new Vector3(-1 * objectRect.sizeDelta.x / 2, objectRect.sizeDelta.y / 2);
            }
            else
            {
                offset = new Vector3(objectRect.sizeDelta.x, objectRect.sizeDelta.y);

            }
            gameObject.transform.position = itemObject.transform.position;
            gameObject.transform.localPosition += offset;
            if (left)
            {
                GetComponent<RectTransform>().pivot = new Vector2(1f, 1f);
            }
            else
            {
                GetComponent<RectTransform>().pivot = new Vector2(0f, 1f);
            }
        }

        private void UpdateEssentials(ItemDm item)
        {
            Weight.GetComponentInChildren<TextMeshProUGUI>().text = item.Weight.ToString() + "lb";
            Title.GetComponentInChildren<TextMeshProUGUI>().text = item.Title;
            QualitySubType.GetComponentInChildren<TextMeshProUGUI>().text = item.Quality.ToString() + " "
                + item.SubType;
        }

        private void SetAverageDamage(ItemDm item)
        {
            // average damage per roll
            AverageDamage.SetActive(true);
            AverageDamage.GetComponentInChildren<TextMeshProUGUI>().text = item.Damage.ToString();
        }

        private void SetDefence(ItemDm item)
        {
            Defence.SetActive(true);
            Defence.GetComponentInChildren<TextMeshProUGUI>().text = item.Defence.ToString();
        }

    }
}
