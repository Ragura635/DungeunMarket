using Core;
using System;
using Utils;
using Data;

namespace Scenes.CharacterCreation
{
    internal class CreateNameScene : IScene
    {
        public GameState Run()
        {
            Console.Clear();
            Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.\n");
            Console.WriteLine("원하시는 이름을 입력해주세요. (공백 입력 시 취소)\n");
            Console.Write(">> ");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("\n입력이 취소되었습니다.");
                ConsoleUtil.WaitForNext();
                return GameState.Pop;
            }

            PlayerData.TempName = input;
            return GameState.SelectJob;
        }

        public GameState SceneType => GameState.CreateName;
    }
}