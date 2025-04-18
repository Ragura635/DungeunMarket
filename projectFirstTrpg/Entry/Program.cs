using Core;
using Data;
using Entities;
using Managers;
using Scenes;
using System.Runtime.InteropServices;

namespace Entry
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PlayerData.Player = new Player("Ragu", JobType.Warrior);

            SceneManager manager = new SceneManager();
            manager.Run();
        }
    }
}