using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Entities
{
    public class Item
    {
        public string Name { get; }
        public string FlavorText { get; }
        public int Price { get; }
        public ItemType Type { get; }
        public Dictionary<StatType, int> Option { get; }
        public bool IsForSale { get; }

        public Item(string name, ItemType type, string flavorText, Dictionary<StatType, int> option, bool isForSale = true)
        {
            Name = name;
            Type = type;
            FlavorText = flavorText;
            Option = option;
            IsForSale = isForSale;
            Price = CalculatePrice(option);
        }

        private int CalculatePrice(Dictionary<StatType, int> option)
        {
            int atk = option.ContainsKey(StatType.ATK) ? option[StatType.ATK] : 0;
            int def = option.ContainsKey(StatType.DEF) ? option[StatType.DEF] : 0;
            int hp = option.ContainsKey(StatType.HP) ? option[StatType.HP] : 0;

            return atk * 300 + def * 200 + hp * 50;
        }
    }
}
