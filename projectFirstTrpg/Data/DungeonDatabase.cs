using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    internal class DungeonDatabase
    {
        public static Dungeon[] dungeons = new Dungeon[]
        {
            //name, defCut, baseReward
            new Dungeon("쉬운 던전", 5, 1000),
            new Dungeon("일반 던전", 11, 1700),
            new Dungeon("어려운 던전", 17, 2500)
        };
    }
}
