using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.Audio;

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

    public SetUI setUI;

    public Image characterIdle;
 
    // Use this for initialization
    void Start () {
        //AudioManager.AudioManager.m_instance.PlayMusic("MainBg");
        AudioManager.AudioManager.m_instance.SetMute(AudioManager.AudioManager.m_instance.m_backgroundMusicList, !(PlayerPrefs.GetInt("musicOn") == 1));
        AudioManager.AudioManager.m_instance.SetMute(AudioManager.AudioManager.m_instance.m_sfxList, !(PlayerPrefs.GetInt("soundOn") == 1));

        ////设置屏幕自动旋转， 并置支持的方向
        //Screen.orientation = ScreenOrientation.AutoRotation;
        //Screen.autorotateToLandscapeLeft = true;
        //Screen.autorotateToLandscapeRight = true;
        //Screen.autorotateToPortrait = false;
        //Screen.autorotateToPortraitUpsideDown = false;

        characterIdle.overrideSprite = (Sprite)Resources.Load("idle_" + GameArchive.user.sex.ToString(), typeof(Sprite));

        menu_user.button_Avatar.GetComponent<Image>().overrideSprite = (Sprite)Resources.Load("User_" + GameArchive.user.sex.ToString(), typeof(Sprite));

        menu_card.SetText(PlayerPrefs.GetInt("Credit").ToString());
        menu_coin.SetText(PlayerPrefs.GetInt("MyGold").ToString()); 

        //menu_mainGame.button.onClick.AddListener(LevelManager.GotoGameMenu);
        menu_mainGame.button.onClick.AddListener(GoToGameMenu);
        //menu_propGame.button.onClick.AddListener(LevelManager.GotoBonusGames);
        menu_propGame.button.onClick.AddListener(GoToBonusGameMenu);

        menu_character.button.onClick.AddListener(ShowSexPanel);
        menu_setting.button.onClick.AddListener(ShowGameSetting);

        charactor_Panel.GetComponent<ShowCharacter>().exit_button.onClick.AddListener(HideSexPanel);
        setUI.btn_exit.onClick.AddListener(HideGameSetting);

    }

    public void ShowSexPanel()
    {
        AudioManager.AudioManager.m_instance.PlaySFX("Click");
        LevelManager.ShowSelectPanel(charactor_Panel);
    }

    public void HideSexPanel()
    {
        AudioManager.AudioManager.m_instance.PlaySFX("Click");
        LevelManager.HideSelectPanel(charactor_Panel);
    }

    public void ShowGameSetting()
    {
        AudioManager.AudioManager.m_instance.PlaySFX("Click");
        setUI.Show();
    }

    public void HideGameSetting()
    {
        AudioManager.AudioManager.m_instance.PlaySFX("Click");
        setUI.Hide();
        GameArchive.SaveG_Audio();
    }
    void GoToGameMenu()
    {
        AudioManager.AudioManager.m_instance.PlaySFX("Click");
        LevelManager.GotoLevel(LevelName.GameMenu);
    }
    void GoToBonusGameMenu()
    {
        AudioManager.AudioManager.m_instance.PlaySFX("Click");
        LevelManager.GotoLevel(LevelName.BonusGames);
    }
}
