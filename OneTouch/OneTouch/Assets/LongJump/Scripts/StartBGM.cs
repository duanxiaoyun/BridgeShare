using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class StartBGM : MonoBehaviour
{
    public AudioClip bgm;

    AudioSource myAudio;

    // Use this for initialization
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
        AudioManager.AudioManager.m_instance.SetMute(AudioManager.AudioManager.m_instance.m_backgroundMusicList, !(PlayerPrefs.GetInt("musicOn") == 1));
        myAudio.mute = !(PlayerPrefs.GetInt("soundOn") == 1);

        //StartCoroutine(BGM());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator BGM()
    {
        yield return new WaitForSeconds(3);
        myAudio.clip = bgm;
        myAudio.Play();

    }
}
