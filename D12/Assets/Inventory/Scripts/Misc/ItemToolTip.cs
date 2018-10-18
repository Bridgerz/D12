using Assets.Inventory.Scripts.Item.ItemModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Inventory.Scripts.Misc
{
   
    public class ItemToolTip : MonoBehaviour
    {
        // Simple Tool Tip
        public GameObject Weight;
        public GameObject Title;
        public GameObject QualitySubType;

        public GameObject Damage;
        public GameObject Defence;

        // Complex Tool Tip
        public GameObject Tags;
        public GameObject Enchantments;
  

        private void Update()
        {
            gameObject.transform.position = Input.mousePosition;
        }

        public void UpdateActivateSimple(ItemDm item)
        {
            gameObject.transform.position = Input.mousePosition;
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
        }

        public void UpdateActivateComplex(ItemDm item)
        {
            Enchantments.SetActive(false);
            Tags.SetActive(false);
            Damage.SetActive(false);
            Defence.SetActive(false);

            // move object to specified relative point to item

            // stretch size of tooltip to complex size.
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
                case ItemType.Weapon:
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
            if (item.Enchantments.Count > 0)
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
