using Data;
using Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Player
    {
        public string Name { get; private set; }
        public JobType Job { get; private set; }

        public PlayerStatus Status { get; private set; }
        public PlayerInventory Inventory { get; private set; }

        public int Gold { get; set; }

        public Player(string name, JobType job)
        {
            Name = name;
            Job = job;
            Inventory = new PlayerInventory();
            Status = new PlayerStatus(Inventory);
            Gold = 1500;
        }
    }
}