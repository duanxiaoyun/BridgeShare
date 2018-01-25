using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SplashManager : MonoBehaviour {
    public RawImage background;
    public Button startGame;
    public Image touch_Text;

    void Start() {
        Tween tween = background.DOFade(1, 0.5f);
        tween.OnComplete(StartGame);
    }

    void StartGame()
    {
        StartCoroutine(ActiveTouchHit());
        startGame.onClick.AddListener(LevelManager.GotoMain);
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


}
