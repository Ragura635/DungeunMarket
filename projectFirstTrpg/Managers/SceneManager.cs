using System;
using System.Collections.Generic;
using Core;
using Scenes;
using Scenes;
using Scenes.ShopScenes;

namespace Managers
{
    internal class SceneManager
    {
        private readonly Dictionary<GameState, IScene> scenes;
        private GameState currentState;

        public SceneManager()
        {
            scenes = new Dictionary<GameState, IScene>
            {
                { GameState.Main, new MainScene() },
                { GameState.Shop, new ShopScene() },
                { GameState.Buy, new BuyScene() },
                { GameState.Sell, new SellScene() },
                { GameState.Equip, new EquipScene() },
                { GameState.Dungeon, new DungeonScene() },
                { GameState.Rest, new RestScene() },
                { GameState.Inventory, new InventoryScene() },
                { GameState.Status, new StatusScene() },
                { GameState.GameOver, new GameOverScene() },
                //{ GameState.Intro, new IntroScene() },
                //{ GameState.CreateCharacter, new CreateCharacterScene() },
                //{ GameState.LoadCharacter, new LoadCharacterScene() },
                { GameState.Exit, null }
            };

            currentState = GameState.Main;
        }

        public void Run()
        {
            while (currentState != GameState.Exit)
            {
                Console.Clear();

                if (scenes.TryGetValue(currentState, out var scene) && scene != null)
                {
                    currentState = scene.Run();
                }
                else
                {
                    Console.WriteLine($"[에러] '{currentState}' 에 해당하는 Scene이 존재하지 않습니다.");
                    currentState = GameState.Exit;
                }
            }

            Console.WriteLine("게임을 종료합니다.");
        }
    }
}
