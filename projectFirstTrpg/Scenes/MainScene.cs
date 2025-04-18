using Core;
using Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Scenes
{
    public class MainScene : IScene
    {
        public GameState Run()
        {
            Console.Clear();

            Console.WriteLine("던근마켓에 오신 여러분을 환영합니다!");
            Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.\n");

            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine("4. 던전 입장");
            Console.WriteLine("5. 휴식하기");
            //Console.WriteLine("0. 게임 종료");

            Console.Write("\n원하시는 행동을 입력해주세요.\n>> ");
            string input = Console.ReadLine();

            return input switch
            {
                "1" => GameState.Status,
                "2" => GameState.Inventory,
                "3" => GameState.Shop,
                "4" => GameState.Dungeon,
                "5" => GameState.Rest,
                //"0" => GameState.Exit,
                _ => InvalidInput()
            };
        }

        private GameState InvalidInput()
        {
            Console.WriteLine("\n잘못된 입력입니다.");
            ConsoleUtil.WaitForNext();
            return GameState.Main;
        }

        public GameState SceneType => GameState.Main;
    }
}
