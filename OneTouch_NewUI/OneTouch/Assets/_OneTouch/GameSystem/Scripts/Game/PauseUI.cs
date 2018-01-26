﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PauseUI : RecordUI {
    public Button btn_exit;
    public Toggle tog_music;
    public Text txt_music;
    public Toggle tog_sound;
    public Text txt_sound;
    public Button btn_resume;
    public UnityAction<bool> onMusicToggle, onSoundToggle;

    public JumpController jumpController;
    public PushBallController pushBallController;

    public GameTime gameTime;
    AudioSource Sound;

    //private void Awake()
    //{
      
    //}

    // Use this for initialization
    void Start () {
        if (LevelManager.currentLevel.ToString() == "PushBall")
        {
            Sound = pushBallController.GetComponent<AudioSource>();
        }
        else if (LevelManager.currentLevel.ToString() == "Jump")
        {
            Sound = jumpController.GetComponent<AudioSource>();
        }

        btn_exit.onClick.AddListener(LevelManager.GotoGameMenu);
        tog_music.onValueChanged.AddListener(OnMusicToggle);
        tog_sound.onValueChanged.AddListener(OnSoundToggle);
        btn_exit.onClick.AddListener(gameTime.ResumeGame);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMusicToggle(bool isOn)
    {
        txt_music.text = isOn ? "켜짐" : "꺼짐";
        Sound.mute = isOn ? false : true;
        if (onMusicToggle != null)
            onMusicToggle(isOn);
    }

    void OnSoundToggle(bool isOn)
    {
        txt_sound.text = isOn ? "켜짐" : "꺼짐";
        if (onSoundToggle != null)
            onSoundToggle(isOn);

        //if (!isOn)
        //{
        //    jumpSound.Stop();
        //}
        //if (isOn)
        //{
        //    jumpSound.Play();
        //}
    }
}
