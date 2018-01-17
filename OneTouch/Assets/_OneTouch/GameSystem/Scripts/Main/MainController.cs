using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


	// Use this for initialization
	void Start () {

        //设置屏幕自动旋转， 并置支持的方向
        Screen.orientation = ScreenOrientation.AutoRotation;
        Screen.autorotateToLandscapeLeft = true;
        Screen.autorotateToLandscapeRight = true;
        Screen.autorotateToPortrait = false;
        Screen.autorotateToPortraitUpsideDown = false;

        menu_mainGame.button.onClick.AddListener(LevelManager.GotoGameMenu);
        menu_propGame.button.onClick.AddListener(LevelManager.GotoBonusGames);
       
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
