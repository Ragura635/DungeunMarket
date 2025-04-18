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
            SceneManager manager = new SceneManager();
            manager.Run();
        }
    }
}