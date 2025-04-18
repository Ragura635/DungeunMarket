using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Managers
{
    public static class SaveManager
    {
        public static void SavePlayer(Player player, string path)
        {
            var saveData = new PlayerSaveData
            {
                Name = player.Name,
                Job = player.Job,
                Gold = player.Gold,
                Level = player.Status.Level,
                Exp = player.Status.Exp,
                MaxExp = player.Status.MaxExp,
                DamagedAmount = player.Status.DamagedAmount,
                InventoryItems = player.Inventory.Items.Select(ConvertToSaveData).ToList(),
                EquippedItems = player.Inventory.EquippedItems.Select(ConvertToSaveData).ToList(),
                SavedAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm")
            };

            string json = JsonSerializer.Serialize(saveData, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, json);
        }

        public static Player LoadPlayer(string path)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("저장 파일이 존재하지 않습니다.");
                return null;
            }

            string json = File.ReadAllText(path);
            var data = JsonSerializer.Deserialize<PlayerSaveData>(json);

            var player = new Player(data.Name, data.Job)
            {
                Gold = data.Gold
            };

            foreach (var itemData in data.InventoryItems)
                player.Inventory.Buy(ConvertToItem(itemData));

            foreach (var itemData in data.EquippedItems)
                player.Inventory.Equip(null, ConvertToItem(itemData));

            player.Status.AddExp(data.Exp);
            player.Status.ChangeDamagedAmount(data.DamagedAmount);

            return player;
        }

        public static (string name, string savedAt)? LoadSummary(string path)
        {
            if (!File.Exists(path)) return null;

            string json = File.ReadAllText(path);
            using JsonDocument doc = JsonDocument.Parse(json);
            var root = doc.RootElement;

            string name = root.GetProperty("Name").GetString();
            string savedAt = root.TryGetProperty("SavedAt", out var dateProp)
                ? dateProp.GetString()
                : "알 수 없음";

            return (name, savedAt);
        }

        private static ItemSaveData ConvertToSaveData(Item item)
        {
            return new ItemSaveData
            {
                Name = item.Name,
                FlavorText = item.FlavorText,
                Price = item.Price,
                Type = item.Type,
                Option = item.Option,
                IsForSale = item.IsForSale
            };
        }

        private static Item ConvertToItem(ItemSaveData data)
        {
            return new Item(data.Name, data.Type, data.FlavorText, data.Option, data.IsForSale);
        }

        private class PlayerSaveData
        {
            public string Name { get; set; }
            public JobType Job { get; set; }
            public int Gold { get; set; }
            public int Level { get; set; }
            public int Exp { get; set; }
            public int MaxExp { get; set; }
            public int DamagedAmount { get; set; }
            public string SavedAt { get; set; }

            public List<ItemSaveData> InventoryItems { get; set; }
            public List<ItemSaveData> EquippedItems { get; set; }
        }

        private class ItemSaveData
        {
            public string Name { get; set; }
            public string FlavorText { get; set; }
            public int Price { get; set; }
            public ItemType Type { get; set; }
            public Dictionary<StatType, int> Option { get; set; }
            public bool IsForSale { get; set; }
        }
    }
}
