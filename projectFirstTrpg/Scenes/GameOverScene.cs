using Core;
using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using Views;

namespace Scenes
{
    internal class GameOverScene : IScene
    {
        public GameState Run()
        {
            Console.Clear();

            Console.WriteLine("속보) 던전에서 무명 용사 사망");
            Console.WriteLine("- 남긴 아이템 무료 나눔 예정 (착용감 있음)\n");
            Console.WriteLine("[게임 종료]");

            Console.ReadKey();
            return GameState.Exit;
        }

        public GameState SceneType => GameState.GameOver;
    }
}
