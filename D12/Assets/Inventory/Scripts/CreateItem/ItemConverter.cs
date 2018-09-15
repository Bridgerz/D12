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
                return item.ToObject<EnchantedDm>();
            }
            else if (value == 2)
            {
                return item.ToObject<TaggedDm>();
            }
            else if (value == 3)
            {
                return item.ToObject<WeaponDm>();
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
