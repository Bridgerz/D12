using Assets.Inventory.Scripts.Item;
using Assets.Inventory.Scripts.Item.ItemModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Inventory.Scripts.CreateItem
{
    public class ItemConverter : JsonConverter
    {

        public override bool CanConvert(Type objectType)
        {
            return typeof(ItemDm).IsAssignableFrom(objectType);

        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject item = JObject.Load(reader);
            var value = item["Type"].Value<int>();
            if (value == 1)
            {
                return item.ToObject<CurioDm>();
            }
            else if (value == 2)
            {
                return item.ToObject<ArmorDm>();
            }
            else if (value == 3)
            {
                var newItem = item.ToObject<WeaponDm>();
                newItem.Type = ItemType.Wielded;
                return newItem;
            }
            else if (value == 4)
            {
                return item.ToObject<WieldableDm>();
            }
            else
            {
                return item.ToObject<ItemDm>();
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

    }
}
