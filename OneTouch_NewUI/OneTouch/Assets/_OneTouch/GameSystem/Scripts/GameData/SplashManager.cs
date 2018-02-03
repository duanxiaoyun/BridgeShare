using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using AudioManager;

public class SplashManager : MonoBehaviour {
    public RawImage background;
    public Button startGame;
    public Image touch_Text;

    private void Awake()
    {
        AudioManager.AudioManager.m_instance.PlayMusic("MainBg");
        AudioManager.AudioManager.m_instance.SetMute(AudioManager.AudioManager.m_instance.m_backgroundMusicList, !(PlayerPrefs.GetInt("musicOn") == 1));

        AudioManager.AudioManager.m_instance.SetMute(AudioManager.AudioManager.m_instance.m_sfxList, !(PlayerPrefs.GetInt("soundOn") == 1));
    }

    void Start() {
        Tween tween = background.DOFade(1, 0.5f);
        tween.OnComplete(StartGame);
    }

    void StartGame()
    {
        StartCoroutine(ActiveTouchHit());
        startGame.onClick.AddListener(GotoMain);
    }

    private IEnumerator ActiveTouchHit()
    {
        touch_Text.gameObject.SetActive(true);
        while (true)
        {
            touch_Text.gameObject.SetActive(true);
            yield return new WaitForSeconds(1.0f);
            touch_Text.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }
    }
    void GotoMain()
    {
        AudioManager.AudioManager.m_instance.PlaySFX("Click");
        LevelManager.GotoLevel(LevelName.Main);
    }

}
