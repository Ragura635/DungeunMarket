using Data;
using Core;
using Entities;
using Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection;

namespace Scenes
{
    public class DungeonScene : IScene
    {
        private readonly Dungeon[] dungeons = DungeonDatabase.dungeons;
        private readonly Player player = PlayerData.Player;
        private readonly Random random = new();

        public GameState Run()
        {
            Console.Clear();

            Console.WriteLine("던전 입장");
            Console.WriteLine("도전할 던전을 선택하세요.\n");

            ShowDungeonList();
            Console.WriteLine("0. 나가기");
            Console.Write("\n원하시는 행동을 입력해주세요.\n>> ");

            string input = Console.ReadLine();
            bool isCorrect = int.TryParse(input, out int index);

            if (!isCorrect || index < 0 || index > dungeons.Length)
            {
                Console.WriteLine("\n잘못된 입력입니다.");
                ConsoleUtil.WaitForNext();
                return GameState.Dungeon;
            }

            if (index == 0)
            {
                return GameState.Main;
            }

            Dungeon selected = dungeons[index - 1];
            bool isFailed = (selected.DefCut > player.Status.CurrentDef) &&
                            (random.Next(0, 100) < Constants.DUNGEON_FAIL_PERCENT);

            ShowDungeonResult(selected, isFailed);

            if (player.Status.RemainHp() <= 0)
            {
                return GameState.GameOver;
            }

            ConsoleUtil.WaitForNext();
            return GameState.Dungeon;
        }

        private void ShowDungeonList()
        {
            Console.WriteLine("[던전 목록]");
            for (int i = 0; i < dungeons.Length; i++)
            {
                string name = ConsoleUtil.AlignKoreanLeft(dungeons[i].Name, 10);
                string def = $"방어력 {dungeons[i].DefCut,2} 이상 권장";

                Console.WriteLine($"{i + 1}. {name}| {def}");
            }
        }

        private void ShowDungeonResult(Dungeon selected, bool isFailed)
        {
            Console.Clear();

            if (isFailed)
            {
                Console.WriteLine("클리어 실패...");
                Console.WriteLine($"{selected.Name}을 클리어하지 못했습니다.");
            }
            else
            {
                Console.WriteLine("던전 클리어!");
                Console.WriteLine($"축하합니다! {selected.Name}을 클리어했습니다.");
            }

            int defGap = defGap = player.Status.CurrentDef - selected.DefCut; ;
            int tempDamage;
            int damage;

            if (!isFailed)
            {
                tempDamage = random.Next(Constants.MIN_DAMAGE - defGap, Constants.MAX_DAMAGE - defGap + 1);
                damage = Math.Max(0, tempDamage);
            }
            else
            {
                damage = (int)Math.Round(player.Status.RemainHp() / 2.0);
            }

            float min = player.Status.CurrentAtk;
            float max = player.Status.CurrentAtk * 2;
            float bonusRate = (float)(random.NextDouble() * (max - min) + min);
            float rewardMultiplier = 1 + (bonusRate / 100f);
            float finalReward = selected.BaseReward * rewardMultiplier;

            Console.WriteLine("\n[탐험 결과]");
            Console.Write($"체력 {player.Status.RemainHp()} -> ");
            player.Status.ChangeDamagedAmount(damage);
            Console.WriteLine($"{player.Status.RemainHp()}");

            if (!isFailed)
            {
                int goldBefore = player.Gold;
                player.Gold += (int)finalReward;
                Console.WriteLine($"Gold {goldBefore} -> {player.Gold}");
            }
        }

        public GameState SceneType => GameState.Dungeon;
    }
}
