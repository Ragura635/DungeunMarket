using Core;
using Data;
using Managers;
using System;
using Utils;

namespace Scenes
{
    internal class SaveScene : IScene
    {
        public GameState Run()
        {
            Console.Clear();
            Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.\n");
            Console.WriteLine("저장할 세이브 슬롯을 선택해주세요.\n");

            for (int i = 1; i <= 3; i++)
            {
                string path = $"save_slot_{i}.json";
                var summary = SaveManager.LoadSummary(path);

                if (summary.HasValue)
                    Console.WriteLine($"{i}. 세이브 슬롯 {i} : {summary.Value.name} ({summary.Value.savedAt})");
                else
                    Console.WriteLine($"{i}. 세이브 슬롯 {i} : 없음");
            }

            Console.WriteLine("\n0. 돌아가기");

            Console.Write("\n>> ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                case "2":
                case "3":
                    return TrySaveSlot(int.Parse(input));
                case "0":
                    Console.WriteLine("\n저장을 취소했습니다.");
                    ConsoleUtil.WaitForNext();
                    return GameState.Pop;
                default:
                    Console.WriteLine("\n잘못된 입력입니다.");
                    ConsoleUtil.WaitForNext();
                    return GameState.Retry;
            }
        }

        private GameState TrySaveSlot(int slot)
        {
            string path = $"save_slot_{slot}.json";

            SaveManager.SavePlayer(PlayerData.Player, path);

            Console.WriteLine($"\n[슬롯 {slot}]에 저장이 완료되었습니다!");
            ConsoleUtil.WaitForNext();
            return GameState.Retry;
        }

        public GameState SceneType => GameState.Save;
    }
}
