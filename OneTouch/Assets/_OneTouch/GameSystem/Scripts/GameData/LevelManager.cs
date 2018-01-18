using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum LevelName{
    Main,
    GameMenu,
    Jump,
    FarJump,
    PushBall,
    BonusGames
}


public class LevelManager  {

    public static LevelName currentLevel { get; private set; }

    public static void Replay()
    {
        GotoLevel(currentLevel);
    }

    public static void GotoLevel(LevelName level)
    {
        currentLevel = level;
        SceneManager.LoadScene(level.ToString());
    }

    public static void ShowSelectPanel(GameObject panel)
    {
        panel.SetActive(true);
    }

    public static void HideSelectPanel(GameObject panel)
    {
        panel.SetActive(false);
    }
   

    public static void GotoMain()
    {
        GotoLevel(LevelName.Main);
    }

    public static void GotoGameMenu()
    {
        GotoLevel(LevelName.GameMenu);
    }

    public static void GotoJump()
    {
        GotoLevel(LevelName.Jump);
    }

    public static void GotoFarJump()
    {
        GotoLevel(LevelName.FarJump);
    }

    public static void GotoPushBall()
    {
        GotoLevel(LevelName.PushBall);
    }
    public static void GotoBonusGames()
    {
        GotoLevel(LevelName.BonusGames);
    }


}
