using Core;
using Data;
using Entities;
using Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Views;

namespace Scenes
{
    public class StatusScene : IScene
    {
        private readonly Player player = PlayerData.Player;

        public GameState Run()
        {
            Console.Clear();

            Console.WriteLine("상태 보기");
            Console.WriteLine("플레이어의 현재 상태를 확인할 수 있습니다.\n");

            PlayerStatusView.PrintStatus(player);

            ConsoleUtil.WaitForNext();
            return GameState.Pop;
        }

        public GameState SceneType => GameState.Status;
    }
}
