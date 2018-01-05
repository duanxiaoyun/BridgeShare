﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : UIBaseView {
    public Button btn_back;
    public Button btn_pause;
    public Text txt_time;
    public Image img_avatar;
    public Slider slider_hp;
    public Text txt_score;
    public ImageNumber timeUI;


	// Use this for initialization
	void Start () {
        btn_back.onClick.AddListener(LevelManager.GotoGameMenu);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetTime(float time){
        txt_time.text = Mathf.Ceil(time).ToString();
        if (timeUI != null)
            timeUI.SetTime(time);
    }

    public void SetScore(int score){
        txt_score.text = score.ToString();
    }

    public void SetMaxHP(int maxHP){
        slider_hp.maxValue = maxHP;
    }

    public void SetCurrentHP(int hp){
        slider_hp.value = hp;
    }

    public void SetAvatar(Sprite avatar){
        img_avatar.overrideSprite = avatar;
    }
}