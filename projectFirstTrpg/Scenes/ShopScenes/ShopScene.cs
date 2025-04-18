using Core;
using Data;
using Entities;
using Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Scenes.ShopScenes
{
    public class ShopScene : IScene
    {
        private readonly Player player = PlayerData.Player;
        private readonly Shop shop = new Shop();

        public GameState Run()
        {
            Console.Clear();
            Console.WriteLine($"상점");
            Console.WriteLine($"필요한 아이템을 얻을 수 있는 상점입니다.\n");
            Console.WriteLine($"[보유골드]");
            Console.WriteLine($"{player.Gold} G\n");

            shop.ShowShopItems(player);

            Console.WriteLine("\n1. 아이템 구매");
            Console.WriteLine("2. 아이템 판매");
            Console.WriteLine("0. 나가기");
            Console.WriteLine("\n원하시는 행동을 입력해주세요.");
            Console.Write(">> ");

            string input = Console.ReadLine();

            return input switch
            {
                "1" => GameState.Buy,
                "2" => GameState.Sell,
                "0" => GameState.Main,
                _ => InvalidInput()
            };
        }

        private GameState InvalidInput()
        {
            Console.WriteLine("\n잘못된 입력입니다.");
            ConsoleUtil.WaitForNext();
            return GameState.Shop;
        }

        public GameState SceneType => GameState.Shop;
    }
}
