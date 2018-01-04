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
        menu_mainGame.button.onClick.AddListener(LevelManager.GotoGameMenu);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
