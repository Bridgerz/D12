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
        public GameObject Weight;
        public GameObject Title;
        public GameObject Defenition;
        public GameObject Enchantments;
        public GameObject Tags;
        public GameObject Damage;
  

        private void Update()
        {
            gameObject.transform.position = Input.mousePosition;
        }

        public void UpdateActivate(ItemDm item)
        {
            // deactivate variable attributes
            Enchantments.SetActive(false);
            Tags.SetActive(false);
            Damage.SetActive(false);

            Weight.GetComponentInChildren<TextMeshProUGUI>().text = item.Weight.ToString();
            Title.GetComponentInChildren<TextMeshProUGUI>().text = item.Title;
            Defenition.GetComponentInChildren<TextMeshProUGUI>().text = item.Defenition;
            switch (item.Type)
            {
                case ItemType.Curio:
                    SetEnchantments(item);
                    break;
                case ItemType.Armor:
                    SetEnchantments(item);
                    SetTags(item);
                    break;
                case ItemType.Weapon:
                    SetEnchantments(item);
                    SetTags(item);
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

        private void SetDamage(ItemDm item)
        {
            Damage.GetComponentInChildren<TextMeshProUGUI>().text = item.Damage.ToString();
        }
    }
}
