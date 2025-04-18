using System;

namespace Core
{
    public enum GameState
    {
        Intro,
        CreateName,
        SelectJob,
        SelectSlot,
        Save,
        Load,
        Main,
        Status,
        Inventory,
        Equip,
        Shop,
        Buy,
        Sell,
        Dungeon,
        Rest,
        GameOver,
        Exit,

        Retry,
        Pop,            // 이전 씬으로 되돌아가기(Pop)
        MainFromLoad    // LoadScene → MainScene으로 교체 (Pop + Push Main)
    }
}
