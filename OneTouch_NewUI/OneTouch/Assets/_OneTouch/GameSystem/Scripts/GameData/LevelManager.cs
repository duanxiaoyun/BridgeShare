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
        AudioManager.AudioManager.m_instance.PlayMusic("MainBg");
        GotoLevel(LevelName.Main);
    }

    public static void GotoGameMenu()
    {
        AudioManager.AudioManager.m_instance.PlayMusic("MainBg");
        GotoLevel(LevelName.GameMenu);
    }

    public static void GotoJump()
    {
        //AudioManager.AudioManager.m_instance.PlayMusic("JumpBg");
        GotoLevel(LevelName.Jump);
    }

    public static void GotoFarJump()
    {
        //AudioManager.AudioManager.m_instance.PlayMusic("FarJumpBg");
        GotoLevel(LevelName.FarJump);
    }

    public static void GotoPushBall()
    {
        //AudioManager.AudioManager.m_instance.PlayMusic("PushBallBg");
        GotoLevel(LevelName.PushBall);
    }
    public static void GotoBonusGames()
    {
        AudioManager.AudioManager.m_instance.PlayMusic("MainBg");
        GotoLevel(LevelName.BonusGames);
    }

    public static void GameEnd()
    {

        Debug.Log("GAME OVER");
        Application.Quit();
    }

}
