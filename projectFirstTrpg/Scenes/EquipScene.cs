using Core;
using Utils;
using Entities;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using Views;

namespace Scenes
{
    public class EquipScene : IScene
    {
        private readonly Player player = PlayerData.Player;

        public GameState Run()
        {
            Console.Clear();

            Console.WriteLine("인벤토리 - 장착 관리");
            Console.WriteLine("보유한 장비를 장착/해제할 수 있습니다.\n");

            PlayerInventoryView.PrintItemListforEquip(player.Inventory);

            Console.WriteLine("\n0. 돌아가기");
            Console.Write("\n장착할 아이템 번호를 선택해주세요.\n>> ");
            string input = Console.ReadLine();
            bool isCorrect = int.TryParse(input, out int index);

            if (!isCorrect || index < 0 || index > player.Inventory.Items.Count)
            {
                Console.WriteLine("\n잘못된 입력입니다.");
                ConsoleUtil.WaitForNext();
                return GameState.Retry;
            }

            if (index == 0)
            {
                return GameState.Pop;
            }

            Item selectedItem = player.Inventory.Items[index - 1];
            Item? priorItem = player.Inventory.EquippedItems
                .FirstOrDefault(item => item.Type == selectedItem.Type);

            if (priorItem == selectedItem)
                Console.WriteLine($"\n이미 {selectedItem.Name}을(를) 장착 중입니다.");
            else
            {
                player.Inventory.Equip(priorItem, selectedItem);
                Console.WriteLine($"\n{selectedItem.Name}을(를) 장착했습니다.");
            }

            ConsoleUtil.WaitForNext();
            return GameState.Retry;
        }

        public GameState SceneType => GameState.Equip;
    }
}
