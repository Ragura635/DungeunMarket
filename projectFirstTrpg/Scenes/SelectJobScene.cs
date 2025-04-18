using Core;
using Data;
using System;
using Utils;

namespace Scenes.CharacterCreation
{
    internal class SelectJobScene : IScene
    {
        public GameState Run()
        {
            Console.Clear();
            Console.WriteLine($"이름: {PlayerData.TempName}\n");
            Console.WriteLine("직업을 선택해주세요.\n");
            Console.WriteLine("1. 전사 (Warrior)");
            Console.WriteLine("2. 도적 (Thief)");
            Console.WriteLine("\n0. 이름 입력으로 돌아가기\n");
            Console.Write(">> ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    PlayerData.TempJob = JobType.Warrior;
                    return GameState.SelectSlot;
                case "2":
                    PlayerData.TempJob = JobType.Thief;
                    return GameState.SelectSlot;
                case "0":
                    return GameState.Pop;
                default:
                    Console.WriteLine("\n잘못된 입력입니다.");
                    ConsoleUtil.WaitForNext();
                    return GameState.Retry;
            }
        }

        public GameState SceneType => GameState.SelectJob;
    }
}