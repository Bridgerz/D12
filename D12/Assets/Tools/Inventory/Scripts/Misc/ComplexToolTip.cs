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
    public class ComplexToolTip : MonoBehaviour
    {
        // Complex Tool Tip
        public GameObject Tags;
        public GameObject Enchantments;
        
        public GameObject Weight;
        public GameObject Title;
        public GameObject QualitySubType;

        public GameObject Damage;
        public GameObject Defence;


        public void UpdateObject(ItemDm item, GameObject itemObject, bool left)
        {
            gameObject.GetComponent<Image>().raycastTarget = true;
            SetPosition(itemObject, left);
            Enchantments.SetActive(false);
            Tags.SetActive(false);
            Damage.SetActive(false);
            Defence.SetActive(false);
            UpdateEssentials(item);

            switch (item.Type)
            {
                case ItemType.Armor:
                    SetDefence(item);
                    SetTags(item);
                    SetEnchantments(item);
                    break;
                case ItemType.Wielded:
                    SetDamage(item);
                    SetTags(item);
                    SetEnchantments(item);
                    break;
                case ItemType.Curio:
                    SetEnchantments(item);
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


        private void SetDefence(ItemDm item)
        {
            Defence.SetActive(true);
            Defence.GetComponentInChildren<TextMeshProUGUI>().text = item.Defence.ToString();
        }

        private void SetDamage(ItemDm item)
        {
            // each individaul roll listed out 
            Damage.SetActive(true);
            Damage.GetComponentInChildren<TextMeshProUGUI>().text = item.Damage.ToString();
        }

        private void SetEnchantments(ItemDm item)
        {
            if (item.Enchantments != null && item.Enchantments.Count > 0)
            {
                Enchantments.SetActive(true);
                string enchantString = "Enchantments: ";
                foreach (var enchantment in item.Enchantments)
                {
                    enchantString += enchantment.Effect + ", ";
                }
                // remove last comma 
                string finalString = enchantString.Substring(0, enchantString.Length - 2);
                Enchantments.GetComponentInChildren<TextMeshProUGUI>().text = finalString;
            }
        }

        private void SetTags(ItemDm item)
        {
            if (item.Tags.Count > 0)
            {
                Tags.SetActive(true);
                string tagString = "Tags: ";
                foreach (var tag in item.Tags)
                {
                    tagString += tag.ToString() + ", ";
                }
                string finalString = tagString.Substring(0, tagString.Length - 2);
                Tags.GetComponentInChildren<TextMeshProUGUI>().text = finalString;
            }
        }

    }
}
