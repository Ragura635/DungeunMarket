using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public enum StatType
    {
        ATK,
        DEF,
        HP
    }

    public enum ItemType
    {
        Weapon,
        Armor
    }

    public enum JobType
    {
        Warrior,
        Thief
    }

    public static class JobTypeExtensions
    {
        public static string ToKorean(this JobType job)
        {
            return job switch
            {
                JobType.Warrior => "전사",
                JobType.Thief => "도적",
                _ => "알 수 없음"
            };
        }
    }
}
