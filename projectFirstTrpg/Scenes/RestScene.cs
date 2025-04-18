using Core;
using Data;
using Entities;
using Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;


namespace Scenes
{
    public class RestScene : IScene
    {
        private readonly Player player = PlayerData.Player;

        public GameState Run()
        {
            Console.Clear();

            Console.WriteLine("휴식하기");
            Console.WriteLine("500 G를 지불하면 체력을 전부 회복할 수 있습니다.");
            Console.WriteLine($"[보유 골드] {player.Gold} G");
            Console.WriteLine($"[현재 체력] {player.Status.RemainHp()} / {player.Status.CurrentHp}\n");

            Console.WriteLine("1. 휴식하기");
            Console.WriteLine("0. 나가기");
            Console.Write("\n원하시는 행동을 입력해주세요.\n>> ");
            string input = Console.ReadLine();

            return input switch
            {
                "1" => TryRest(),
                "0" => GameState.Main,
                _ => InvalidInput()
            };
        }

        private GameState TryRest()
        {
            if (player.Status.DamagedAmount == 0)
            {
                Console.WriteLine("\n다친 곳이 없습니다.");
            }
            else if (player.Gold < 500)
            {
                Console.WriteLine("\nGold가 부족합니다.");
            }
            else
            {
                player.Gold -= 500;
                player.Status.ChangeDamagedAmount(-player.Status.DamagedAmount);
                Console.WriteLine("\n휴식을 완료했습니다.");
                Console.WriteLine("체력이 회복되었습니다!");
            }

            ConsoleUtil.WaitForNext();
            return GameState.Rest;
        }

        private GameState InvalidInput()
        {
            Console.WriteLine("\n잘못된 입력입니다.");
            ConsoleUtil.WaitForNext();
            return GameState.Rest;
        }

        public GameState SceneType => GameState.Rest;
    }
}
