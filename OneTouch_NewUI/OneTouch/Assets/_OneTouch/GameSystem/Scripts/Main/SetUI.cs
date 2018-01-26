using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

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

    AudioSource mainSound;

    private void Awake()
    {
        mainSound = mainController.GetComponent<AudioSource>();
    }

    // Use this for initialization
    void Start () {
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
        FindObjectOfType<BgSound>().GetComponent<AudioSource>().mute = isOn ? false : true;
        if (onMusicToggle != null)
            onMusicToggle(isOn);
    }

    void OnSoundToggle(bool isOn)
    {
        txt_sound.text = isOn ? "켜짐" : "꺼짐";
        mainSound.mute = isOn ? false : true;
        if (onSoundToggle != null)
            onSoundToggle(isOn);
    
    }
}
