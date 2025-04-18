using Core;
using Data;
using Entities;
using Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Scenes
{
    public class BuyScene : IScene
    {
        private readonly Player player = PlayerData.Player;
        private readonly Shop shop = new Shop();

        public GameState Run()
        {
            Console.Clear();

            Console.WriteLine($"상점 - 아이템 구매");
            Console.WriteLine($"필요한 아이템을 얻을 수 있는 상점입니다.\n");
            Console.WriteLine($"[보유골드]");
            Console.WriteLine($"{player.Gold} G\n");

            shop.ShowShopItemsController(player);

            Console.WriteLine("\n0. 돌아가기");
            Console.WriteLine("\n구매할 아이템 번호를 입력해주세요.");
            Console.Write(">> ");

            string input = Console.ReadLine();
            bool isCorrect = int.TryParse(input, out int index);

            if (!isCorrect || index < 0 || index > shop.GetItemsForSale().Length)
            {
                Console.WriteLine("\n잘못된 입력입니다.");
                ConsoleUtil.WaitForNext();
                return GameState.Retry;
            }

            if (index == 0)
            {
                return GameState.Pop;
            }

            Item selectedItem = shop.GetItemsForSale()[index - 1];

            if (player.Inventory.HasItem(selectedItem))
            {
                Console.WriteLine("\n이미 구매한 아이템입니다.");
            }
            else if (player.Gold < selectedItem.Price)
            {
                Console.WriteLine("\nGold가 부족합니다.");
            }
            else
            {
                player.Gold -= selectedItem.Price;
                player.Inventory.Buy(selectedItem);
                Console.WriteLine($"\n{selectedItem.Name}을(를) 구매했습니다.");
            }

            ConsoleUtil.WaitForNext();
            return GameState.Retry;
        }

        public GameState SceneType => GameState.Buy;
    }
}
