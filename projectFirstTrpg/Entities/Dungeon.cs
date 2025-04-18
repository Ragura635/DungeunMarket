using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    internal class Dungeon
    {
        private string name;
        private int defCut;
        private int baseReward;

        public string Name { get { return name; } }
        public int DefCut { get { return defCut; } }
        public int BaseReward { get { return baseReward; } }

        public Dungeon(string name, int defCut, int baseReward)
        {
            this.name = name;
            this.defCut = defCut;
            this.baseReward = baseReward;
        }
    }
}
