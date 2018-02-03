using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using AudioManager;

public class SetUI : UIBaseView
{
    public Button btn_exit;
    public Toggle tog_music;
    public Text txt_music;
    public Toggle tog_sound;
    public Text txt_sound;
    public Button btn_end;

    public MainController mainController;

    public UnityAction<bool> onMusicToggle, onSoundToggle;

    //AudioSource mainSound;
    //AudioSource gameSound;

    private void Awake()
    {
        //mainSound = mainController.GetComponent<AudioSource>();
        //gameSound = AudioManager.AudioManager.m_instance.GetComponent<AudioSource>();
    }

    // Use this for initialization
    void Start () {
        tog_music.isOn = (PlayerPrefs.GetInt("musicOn") == 1) ? true : false;
        tog_sound.isOn = (PlayerPrefs.GetInt("soundOn") == 1) ? true : false;

        //btn_exit.onClick.AddListener(LevelManager.GotoMain);
        tog_music.onValueChanged.AddListener(OnMusicToggle);
        tog_sound.onValueChanged.AddListener(OnSoundToggle);
        btn_end.onClick.AddListener(LevelManager.GameEnd);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMusicToggle(bool isOn)
    {
        txt_music.text = isOn ? "켜짐" : "꺼짐";

        AudioManager.AudioManager.m_instance.SetMute(AudioManager.AudioManager.m_instance.m_backgroundMusicList,!isOn);
        AudioManager.AudioManager.m_instance.PlaySFX("Click");

        AudioManager.AudioManager.musicOn = isOn ? true:false;
        if (onMusicToggle != null)
            onMusicToggle(isOn);
    }

    void OnSoundToggle(bool isOn)
    {
        txt_sound.text = isOn ? "켜짐" : "꺼짐";
        AudioManager.AudioManager.m_instance.SetMute(AudioManager.AudioManager.m_instance.m_sfxList, !isOn);
        AudioManager.AudioManager.m_instance.PlaySFX("Click");

        AudioManager.AudioManager.soundOn = isOn ? true : false;
        if (onSoundToggle != null)
            onSoundToggle(isOn);
    
    }
}
