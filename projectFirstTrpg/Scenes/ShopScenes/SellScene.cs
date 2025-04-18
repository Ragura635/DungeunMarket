using Core;
using Data;
using Entities;
using Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Views;

namespace Scenes.ShopScenes
{
    public class SellScene : IScene
    {
        private readonly Player player = PlayerData.Player;

        public GameState Run()
        {
            Console.Clear();

            Console.WriteLine($"상점 - 아이템 판매");
            Console.WriteLine($"불필요한 아이템을 판매할 수 있습니다.\n");
            Console.WriteLine($"[보유골드]");
            Console.WriteLine($"{player.Gold} G\n");

            Console.WriteLine("[보유 아이템 목록]");
            PlayerInventoryView.PrintSellList(player.Inventory);

            Console.WriteLine("\n0. 나가기");
            Console.WriteLine("\n판매할 아이템 번호를 입력해주세요.");
            Console.Write(">> ");

            string input = Console.ReadLine();
            bool isCorrect = int.TryParse(input, out int index);

            if (!isCorrect || index < 0 || index > player.Inventory.Items.Count)
            {
                Console.WriteLine("\n잘못된 입력입니다.");
                ConsoleUtil.WaitForNext();
                return GameState.Sell;
            }

            if (index == 0)
            {
                return GameState.Shop;
            }

            Item selectedItem = player.Inventory.Items[index - 1];
            bool isEquipped = player.Inventory.EquippedItems.Contains(selectedItem);

            if (isEquipped)
            {
                Console.WriteLine($"\n{selectedItem.Name}을(를) 해제합니다.");
            }

            player.Inventory.Sell(selectedItem);
            Console.WriteLine($"\n{selectedItem.Name}을(를) {(int)(selectedItem.Price * 0.85f)} G에 판매했습니다.");

            ConsoleUtil.WaitForNext();
            return GameState.Sell;
        }

        public GameState SceneType => GameState.Sell;
    }
}
