using Core;
using Data;
using Entities;
using Managers;
using System;
using Utils;

namespace Scenes.CharacterCreation
{
    internal class SelectSlotScene : IScene
    {
        public GameState Run()
        {
            Console.Clear();
            Console.WriteLine($"이름: {PlayerData.TempName}");
            Console.WriteLine($"직업: {PlayerData.TempJob}\n");
            Console.WriteLine("저장할 세이브 슬롯을 선택해주세요.\n");

            for (int i = 1; i <= 3; i++)
            {
                string path = $"save_slot_{i}.json";
                var summary = SaveManager.LoadSummary(path);

                if (summary.HasValue)
                    Console.WriteLine($"{i}. 슬롯 {i} (덮어쓰기됨) : {summary.Value.name} ({summary.Value.savedAt})");
                else
                    Console.WriteLine($"{i}. 슬롯 {i} (빈 슬롯)");
            }

            Console.WriteLine("0. 직업 선택으로 돌아가기\n");
            Console.Write(">> ");
            string input = Console.ReadLine();

            if (input == "0")
                return GameState.Pop;

            if (!int.TryParse(input, out int slot) || slot < 1 || slot > 3)
            {
                Console.WriteLine("\n잘못된 입력입니다.");
                ConsoleUtil.WaitForNext();
                return GameState.Retry;
            }

            // Player 생성 및 저장
            Player player = new Player(PlayerData.TempName, PlayerData.TempJob);
            PlayerData.Player = player;
            SaveManager.SavePlayer(player, $"save_slot_{slot}.json");

            Console.WriteLine($"\n'{player.Name}' 캐릭터가 슬롯 {slot}에 저장되었습니다!");
            ConsoleUtil.WaitForNext();
            return GameState.Main;
        }

        public GameState SceneType => GameState.SelectSlot;
    }
}
