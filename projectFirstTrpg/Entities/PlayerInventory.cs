using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class PlayerInventory
    {
        private List<Item> inventory = new();
        private List<Item> equipped = new();

        public IReadOnlyList<Item> Items => inventory;
        public IReadOnlyList<Item> EquippedItems => equipped;

        public bool HasItem(Item item) => inventory.Contains(item);

        public void Buy(Item item)
        {
            if (!inventory.Contains(item))
                inventory.Add(item);
        }

        public void Sell(Item item)
        {
            inventory.Remove(item);
            equipped.Remove(item);
        }

        public void Equip(Item prior, Item next)
        {
            equipped.Remove(prior);
            equipped.Add(next);
        }

        public int GetStatBonus(StatType type)
        {
            return equipped.Where(i => i.Option.ContainsKey(type)).Sum(i => i.Option[type]);
        }
    }
}
