using Core;
using Data;
using Entities;
using Managers;
using System;
using System.IO;
using Utils;

namespace Scenes
{
    internal class IntroScene : IScene
    {
        public GameState Run()
        {
            Console.Clear();
            Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.\n");

            Console.WriteLine("1. 새로 시작하기");
            Console.WriteLine("2. 불러오기");
            Console.WriteLine("0. 게임 종료");

            Console.Write("\n>> ");
            string input = Console.ReadLine();

            return input switch
            {
                "1" => GameState.CreateName,
                "2" => GameState.Load,
                "0" => GameState.Exit,
                _ => InvalidInput()
            };
        }

        private GameState InvalidInput()
        {
            Console.WriteLine("\n잘못된 입력입니다.");
            ConsoleUtil.WaitForNext();
            return GameState.Retry;
        }

        public GameState SceneType => GameState.Intro;

    }
}