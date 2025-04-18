using Core;
using Data;
using Entities;
using Managers;
using System;
using System.IO;
using Utils;

namespace Scenes
{
    internal class LoadScene : IScene
    {
        public GameState Run()
        {
            Console.Clear();
            Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.\n");
            Console.WriteLine("불러올 세이브 슬롯을 선택해주세요.\n");

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
                    return TryLoadSlot(int.Parse(input));
                case "0":
                    Console.WriteLine("\n불러오기를 취소했습니다.");
                    ConsoleUtil.WaitForNext();
                    return GameState.Pop;
                default:
                    Console.WriteLine("\n잘못된 입력입니다.");
                    ConsoleUtil.WaitForNext();
                    return GameState.Retry;
            }
        }

        private GameState TryLoadSlot(int slot)
        {
            string path = $"save_slot_{slot}.json";

            if (!File.Exists(path))
            {
                Console.WriteLine($"\n[슬롯 {slot}] 저장된 데이터가 없습니다.");
                ConsoleUtil.WaitForNext();
                return GameState.Retry;
            }

            Player loaded = SaveManager.LoadPlayer(path);

            if (loaded == null)
            {
                Console.WriteLine($"\n[슬롯 {slot}] 저장 데이터가 손상되었거나 불러오기에 실패했습니다.");
                ConsoleUtil.WaitForNext();
                return GameState.Retry;
            }

            PlayerData.Player = loaded;
            PlayerData.LastLoadedSlotPath = path;
            Console.WriteLine($"\n[슬롯 {slot}] 불러오기에 성공했습니다!");
            ConsoleUtil.WaitForNext();
            return GameState.MainFromLoad;
        }

        public GameState SceneType => GameState.Load;
    }
}
