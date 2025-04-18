using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Views
{
    public static class PlayerInventoryView
    {
        public static void PrintItemList(PlayerInventory inventory)
        {
            foreach (var item in inventory.Items)
            {
                string name = ConsoleUtil.AlignKoreanLeft(item.Name, 20);
                string options = string.Join(", ",
                    item.Option.Select(o => $"{o.Key}{(o.Value >= 0 ? "+" : "")}{o.Value}"));
                string flavor = ConsoleUtil.AlignKoreanLeft(item.FlavorText, 50);
                Console.WriteLine($"- {name}| {options,-16}| {flavor}");
            }
        }

        public static void PrintItemListforEquip(PlayerInventory inventory)
        {
            for (int i = 0; i < inventory.Items.Count; i++)
            {
                var item = inventory.Items[i];
                string name = inventory.EquippedItems.Contains(item)
                    ? "[E] " + item.Name
                    : item.Name;

                name = ConsoleUtil.AlignKoreanLeft(name, 20);
                string options = string.Join(", ",
                    item.Option.Select(o => $"{o.Key}{(o.Value >= 0 ? "+" : "")}{o.Value}"));
                string flavor = ConsoleUtil.AlignKoreanLeft(item.FlavorText, 50);
                Console.WriteLine($"- {i + 1,2}. {name}| {options,-16}| {flavor}");
            }
        }

        public static void PrintSellList(PlayerInventory inventory)
        {
            for (int i = 0; i < inventory.Items.Count; i++)
            {
                var item = inventory.Items[i];
                string name = inventory.EquippedItems.Contains(item)
                    ? "[E] " + item.Name
                    : item.Name;

                name = ConsoleUtil.AlignKoreanLeft(name, 20);
                string options = string.Join(", ",
                    item.Option.Select(o => $"{o.Key}{(o.Value >= 0 ? "+" : "")}{o.Value}"));
                string price = (item.Price * 0.85f).ToString("F0") + " G";
                string flavor = ConsoleUtil.AlignKoreanLeft(item.FlavorText, 50);
                Console.WriteLine($"- {i + 1,2}. {name}| {options,-16}| {flavor}| {price}");
            }
        }
    }
}
