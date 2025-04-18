using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using Utils;

namespace Data
{
    internal class Shop
    {
        private Item[] itemsForSale;

        public Item[] GetItemsForSale()
        {
            return itemsForSale;
        }

        public Shop()
        {
            itemsForSale = ItemDatabase.items.Where(item => item.IsForSale).ToArray();
        }

        //상점창에서 출력
        public void ShowShopItems(Player player)
        {
            Console.WriteLine("[아이템 목록]");
            for (int i = 0; i < itemsForSale.Length; i++)
            {
                string name = ConsoleUtil.AlignKoreanLeft(itemsForSale[i].Name, 20); ;
                string optionStr = string.Join(", ", itemsForSale[i].Option.Select
                                   (o => $"{o.Key}{(o.Value >= 0 ? "+" : "")}{o.Value}"));
                string flavor = ConsoleUtil.AlignKoreanLeft(itemsForSale[i].FlavorText, 50);
                string _price = player.Inventory.HasItem(itemsForSale[i]) ? "구매완료" : $"{itemsForSale[i].Price} G";

                Console.WriteLine($"- {name}| {optionStr, -16}| {flavor}| {_price}");
            }
        }

        //구매창에서 출력
        public void ShowShopItemsController(Player player)
        {
            Console.WriteLine("[아이템 목록]");
            for (int i = 0; i < itemsForSale.Length; i++)
            {
                string name = ConsoleUtil.AlignKoreanLeft(itemsForSale[i].Name, 20); ;
                string optionStr = string.Join(", ", itemsForSale[i].Option.Select
                                   (o =>$"{o.Key}{(o.Value >= 0 ? "+" : "")}{o.Value}"));
                string flavor = ConsoleUtil.AlignKoreanLeft(itemsForSale[i].FlavorText, 50);
                string _price = player.Inventory.HasItem(itemsForSale[i]) ? "구매완료" : $"{itemsForSale[i].Price} G";

                Console.WriteLine($"- {i+1,2}. {name}| {optionStr,-16}| {flavor}| {_price}");
            }
        }
    }
}
