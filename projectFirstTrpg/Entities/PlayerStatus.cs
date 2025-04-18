using Core;
using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class PlayerStatus
    {
        public int Level { get; private set; } = 1;
        public int Exp { get; private set; } = 0;
        public int MaxExp { get; private set; } = 100;

        private int baseHp = 100;
        private int damagedAmount = 0;

        private float baseAtk = 10f;
        private int baseDef = 5;

        private PlayerInventory inventory;

        public PlayerStatus(PlayerInventory inventory)
        {
            this.inventory = inventory;
        }

        public int CurrentHp => baseHp + inventory.GetStatBonus(StatType.HP);
        public float CurrentAtk => baseAtk + (Level - 1) * Constants.ATK_PER_LEVEL + inventory.GetStatBonus(StatType.ATK);
        public int CurrentDef => baseDef + (Level - 1) * Constants.DEF_PER_LEVEL + inventory.GetStatBonus(StatType.DEF);

        public void AddExp(int amount)
        {
            Exp += amount;

            while (Exp >= MaxExp)
            {
                Exp -= MaxExp;
                MaxExp += 100;
                Level++;
            }
        }

        public void ChangeDamagedAmount(int value)
        {
            damagedAmount += value;
            damagedAmount = Math.Clamp(damagedAmount, 0, CurrentHp);
        }

        public int RemainHp() => CurrentHp - damagedAmount;

        public int DamagedAmount => damagedAmount;
    }
}
