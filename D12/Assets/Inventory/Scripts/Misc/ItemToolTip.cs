using Assets.Inventory.Scripts.Item.ItemModels;
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
        private bool IsComplex;

        // Simple Tool Tip
        public GameObject Weight;
        public GameObject Title;
        public GameObject QualitySubType;

        public GameObject Damage;
        public GameObject Defence;

        // Complex Tool Tip
        public GameObject Tags;
        public GameObject Enchantments;

        public static Vector2 SIMPLESIZE;

        private void Start()
        {
            SIMPLESIZE = transform.GetComponent<RectTransform>().sizeDelta;
            IsComplex = false;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && IsComplex)
            {
                gameObject.GetComponent<RectTransform>().sizeDelta = SIMPLESIZE;
                gameObject.SetActive(false);
            }
        }

        public void UpdateSimple(ItemDm item, GameObject itemObject, bool left)
        {
            gameObject.GetComponent<Image>().raycastTarget = false;
            SetPosition(itemObject, left);
            // deactivate variable attributes
            Enchantments.SetActive(false);
            Tags.SetActive(false);
            Damage.SetActive(false);
            Defence.SetActive(false);

            UpdateEssentials(item);

            switch (item.Type)
            {
                case ItemType.Armor:
                    SetDefence(item);
                    break;
                case ItemType.Wielded:
                    SetSimpleDamage(item);
                    break;
                default:
                    break;
            }
            IsComplex = false;
        }

        public void UpdateComplex(ItemDm item)
        {
            gameObject.GetComponent<Image>().raycastTarget = true;
            gameObject.GetComponent<RectTransform>().sizeDelta = SIMPLESIZE;
            if (!IsComplex)
            {
                Enchantments.SetActive(false);
                Tags.SetActive(false);
                Damage.SetActive(false);
                Defence.SetActive(false);
                var rect = gameObject.GetComponent<RectTransform>();
                rect.sizeDelta = Vector2.Lerp(rect.sizeDelta, new Vector2(rect.sizeDelta.x + 100f, rect.sizeDelta.y), .75f);

                UpdateEssentials(item);

                switch (item.Type)
                {
                    case ItemType.Armor:
                        SetDefence(item);
                        SetTags(item);
                        SetEnchantments(item);
                        break;
                    case ItemType.Wielded:
                        SetComplexDamage(item);
                        SetTags(item);
                        SetEnchantments(item);
                        break;
                    case ItemType.Curio:
                        SetEnchantments(item);
                        break;
                    default:
                        break;
                }
                IsComplex = true;
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

        public void DeactivateReset()
        {
            if (!IsComplex)
            { 
                gameObject.GetComponent<RectTransform>().sizeDelta = SIMPLESIZE;
                gameObject.SetActive(false);
            }
        }

        private void SetDefence(ItemDm item)
        {
            Defence.SetActive(true);
            Defence.GetComponentInChildren<TextMeshProUGUI>().text = item.Defence.ToString();
        }

        private void SetSimpleDamage(ItemDm item)
        {
            // average damage per roll
            Damage.SetActive(true);
            Damage.GetComponentInChildren<TextMeshProUGUI>().text = item.Damage.ToString();
        }

        private void SetComplexDamage(ItemDm item)
        {
            // each individaul roll listed out 
            Damage.SetActive(true);
            Damage.GetComponentInChildren<TextMeshProUGUI>().text = item.Damage.ToString();
        }

        private void UpdateEssentials(ItemDm item)
        {
            Weight.GetComponentInChildren<TextMeshProUGUI>().text = item.Weight.ToString() + "lb";
            Title.GetComponentInChildren<TextMeshProUGUI>().text = item.Title;
            QualitySubType.GetComponentInChildren<TextMeshProUGUI>().text = item.Quality.ToString() + " "
                + item.SubType;
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
