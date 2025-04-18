using Core;
using Data;
using System;
using System.IO;
using Utils;

namespace Scenes
{
    internal class GameOverScene : IScene
    {
        public GameState Run()
        {
            Console.Clear();
            Console.WriteLine("속보) 던전에서 무명 용사 사망");
            Console.WriteLine("- 남긴 아이템 무료 나눔 예정 (착용감 있음)\n");

            File.Delete(PlayerData.LastLoadedSlotPath);

            Console.WriteLine("\n1. 타이틀로 돌아가기");
            Console.WriteLine("0. 게임 종료");
            Console.Write("\n>> ");
            string input = Console.ReadLine();

            return input switch
            {
                "1" => GameState.Intro,
                "0" => GameState.Exit,
                _ => GameState.Retry
            };
        }

        public GameState SceneType => GameState.GameOver;
    }
}