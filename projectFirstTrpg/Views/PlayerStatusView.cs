using Entities;
using Utils;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Views
{
    public static class PlayerStatusView
    {
        public static void PrintStatus(Player player)
        {
            Console.WriteLine($"Lv. {player.Status.Level:D2} ({player.Status.Exp}/{player.Status.MaxExp})");
            Console.WriteLine($"{player.Name} ( {player.Job.ToKorean()} )");
            Console.WriteLine($"체  력 : {player.Status.RemainHp()} / {player.Status.CurrentHp} {GetStatBonusToStr(player, StatType.HP)}");
            Console.WriteLine($"공격력 : {player.Status.CurrentAtk} {GetStatBonusToStr(player, StatType.ATK)}");
            Console.WriteLine($"방어력 : {player.Status.CurrentDef} {GetStatBonusToStr(player, StatType.DEF)}");
            Console.WriteLine($"Gold  : {player.Gold}\n");
        }

        public static string GetStatBonusToStr(Player player, StatType stat)
        {
            int bonus = player.Inventory.GetStatBonus(stat);

            if (bonus > 0)
                return $"( +{bonus} )";
            else if (bonus < 0)
                return $"( {bonus} )";
            else
                return "";
        }
    }
}