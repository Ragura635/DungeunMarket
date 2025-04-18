using Core;
using Utils;
using Entities;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Views;

namespace Scenes
{
    public class InventoryScene : IScene
    {
        private readonly Player player = PlayerData.Player;

        public GameState Run()
        {
            Console.Clear();

            Console.WriteLine("인벤토리");
            Console.WriteLine("보유한 아이템 목록을 확인할 수 있습니다.\n");

            PlayerInventoryView.PrintItemList(player.Inventory);

            Console.WriteLine("\n1. 장착 관리");
            Console.WriteLine("0. 돌아가기");
            Console.Write("\n원하시는 행동을 입력해주세요.\n>> ");

            string input = Console.ReadLine();

            return input switch
            {
                "1" => GameState.Equip,
                "0" => GameState.Main,
                _ => InvalidInput()
            };
        }

        private GameState InvalidInput()
        {
            Console.WriteLine("\n잘못된 입력입니다.");
            ConsoleUtil.WaitForNext();
            return GameState.Inventory;
        }

        public GameState SceneType => GameState.Inventory;
    }
}
