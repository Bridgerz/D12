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

            Weight.GetComponentInChildren<TextMeshProUGUI>().text = item.Weight.ToString() + "lb";
            Title.GetComponentInChildren<TextMeshProUGUI>().text = item.Title;
            QualitySubType.GetComponentInChildren<TextMeshProUGUI>().text = item.Quality.ToString() + " "
                + item.SubType;
            switch (item.Type)
            {
                case ItemType.Armor:
                    SetDefence(item);
                    break;
                case ItemType.Wielded:
                    SetDamage(item);
                    break;
                default:
                    break;
            }
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

        private void SetDefence(ItemDm item)
        {
            Defence.SetActive(true);
            Defence.GetComponentInChildren<TextMeshProUGUI>().text = item.Defence.ToString();
        }

        private void SetDamage(ItemDm item)
        {
            Damage.SetActive(true);
            Damage.GetComponentInChildren<TextMeshProUGUI>().text = item.Damage.ToString();
        }
    }
}
