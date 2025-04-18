using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    internal class ItemDatabase
    {
        public static Item[] items = new Item[]
        {
            //name, ItemType, FlavorText, Option, isForSale
            new Item("왼쪽 에어팟", ItemType.Armor, "오른쪽만 남은 분 찾습니다.", new Dictionary<StatType, int>{{ StatType.DEF, 2 } }, true),
            new Item("아빠양말", ItemType.Armor, "\"냄새안남\"", new Dictionary<StatType, int>{{ StatType.DEF, 6 }, { StatType.HP, -10 } }, true),
            new Item("구멍난 장화", ItemType.Armor, "물 조금밖에 안 샘.", new Dictionary<StatType, int>{{ StatType.DEF, 9 }}, true),
            new Item("솜 죽은 롱패딩", ItemType.Armor, "이거 솜 죽은거 복구 되나요?", new Dictionary<StatType, int>{{ StatType.DEF, 15 }, { StatType.ATK, -2 } }, true),
            new Item("낙서된 깁스", ItemType.Armor, "늘 건강하세요 -호날두-", new Dictionary<StatType, int>{{ StatType.DEF, 20 }}, true),
            new Item("전공서적", ItemType.Weapon, "팝니다. 전공서적. 한번도 안쓴.", new Dictionary<StatType, int>{{ StatType.ATK, 5 }}, true),
            new Item("고장난 전동드릴", ItemType.Weapon, "돌아가진 않는데 엔진 소리는 나요.", new Dictionary<StatType, int>{{ StatType.ATK, 9 }}, true),
            new Item("선풍기 날개", ItemType.Weapon, "리필용) 본체는 고장났어요", new Dictionary<StatType, int>{{ StatType.ATK, 12 }}, true),
            new Item("손잡이 빠진 식칼", ItemType.Weapon, "이거 어케씀?!?!", new Dictionary<StatType, int>{{ StatType.ATK, 17 }, { StatType.HP, -20} }, true),
            new Item("벽돌 두 장", ItemType.Weapon, "게임기 샀는데 이게 배달왔어요", new Dictionary<StatType, int>{{ StatType.ATK, 22 }}, true)
        };
    }
}