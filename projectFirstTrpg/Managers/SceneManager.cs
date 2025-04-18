using System;
using System.Collections.Generic;
using Core;
using Scenes;
using Scenes.CharacterCreation;

namespace Managers
{
    internal class SceneManager
    {
        private readonly Stack<IScene> sceneStack = new();

        public void Run()
        {
            sceneStack.Push(new IntroScene());

            while (sceneStack.Count > 0)
            {
                Console.Clear();

                IScene currentScene = sceneStack.Peek();
                GameState next = currentScene.Run();

                switch (next)
                {
                    case GameState.Retry:
                        continue;

                    case GameState.Pop:
                        sceneStack.Pop(); // 현재 씬 제거
                        break;

                    case GameState.MainFromLoad:
                        sceneStack.Pop();                 // LoadScene 제거
                        sceneStack.Push(new MainScene()); // MainScene 추가
                        break;

                    case GameState.Intro:
                        sceneStack.Push(new IntroScene());
                        break;

                    case GameState.CreateName:
                        sceneStack.Push(new CreateNameScene());
                        break;

                    case GameState.SelectJob:
                        sceneStack.Push(new SelectJobScene());
                        break;

                    case GameState.SelectSlot:
                        sceneStack.Push(new SelectSlotScene());
                        break;

                    case GameState.Save:
                        sceneStack.Push(new SaveScene());
                        break;

                    case GameState.Load:
                        sceneStack.Push(new LoadScene());
                        break;

                    case GameState.Main:
                        sceneStack.Push(new MainScene());
                        break;

                    case GameState.Shop:
                        sceneStack.Push(new ShopScene());
                        break;

                    case GameState.Buy:
                        sceneStack.Push(new BuyScene());
                        break;

                    case GameState.Sell:
                        sceneStack.Push(new SellScene());
                        break;

                    case GameState.Equip:
                        sceneStack.Push(new EquipScene());
                        break;

                    case GameState.Dungeon:
                        sceneStack.Push(new DungeonScene());
                        break;

                    case GameState.Rest:
                        sceneStack.Push(new RestScene());
                        break;

                    case GameState.Inventory:
                        sceneStack.Push(new InventoryScene());
                        break;

                    case GameState.Status:
                        sceneStack.Push(new StatusScene());
                        break;

                    case GameState.GameOver:
                        sceneStack.Push(new GameOverScene());
                        break;

                    case GameState.Exit:
                        sceneStack.Clear(); // 전체 종료
                        break;

                    default:
                        Console.WriteLine($"Unknown Game Scene");
                        sceneStack.Pop();
                        break;
                }
            }

            Console.WriteLine("게임을 종료합니다.");
        }
    }
}
