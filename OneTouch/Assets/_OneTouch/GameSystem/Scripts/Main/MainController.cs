using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour {
    public UIMainMenuItem menu_user;
    public UIMainMenuItem menu_shoes;
    public UIMainMenuItem menu_coin;
    public UIMainMenuItem menu_card;
    public UIMainMenuItem menu_alert;
    public UIMainMenuItem menu_character;
    public UIMainMenuItem menu_friend;
    public UIMainMenuItem menu_task;
    public UIMainMenuItem menu_store;
    public UIMainMenuItem menu_message;
    public UIMainMenuItem menu_setting;
    public UIMainMenuItem menu_mainGame;
    public UIMainMenuItem menu_propGame;

    public GameObject charactor_Panel;
    public Button exit_Panel;

    public Image characterIdle;

    // Use this for initialization
    void Start () {

        ////设置屏幕自动旋转， 并置支持的方向
        //Screen.orientation = ScreenOrientation.AutoRotation;
        //Screen.autorotateToLandscapeLeft = true;
        //Screen.autorotateToLandscapeRight = true;
        //Screen.autorotateToPortrait = false;
        //Screen.autorotateToPortraitUpsideDown = false;
        
        characterIdle.overrideSprite = (Sprite)Resources.Load("idle_"+GameArchive.user.sex.ToString(),typeof(Sprite));

        menu_mainGame.button.onClick.AddListener(LevelManager.GotoGameMenu);
        menu_propGame.button.onClick.AddListener(LevelManager.GotoBonusGames);

        menu_character.button.onClick.AddListener(ShowSelectPanel);

        exit_Panel.onClick.AddListener(HideSelectPanel);

    }
    public void ShowSelectPanel()
    {
        LevelManager.ShowSelectPanel(charactor_Panel);
    }

    public void HideSelectPanel()
    {
        LevelManager.HideSelectPanel(charactor_Panel);
    }

}
