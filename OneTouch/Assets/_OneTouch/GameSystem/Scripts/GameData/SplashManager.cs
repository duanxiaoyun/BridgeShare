using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SplashManager : MonoBehaviour {
    public RawImage background;
    public Button startGame;
    public Image touch_Text;

    // Use this for initialization
    //IEnumerator Start () {
    //       yield return new WaitForSeconds(2);
    //       LevelManager.GotoMain();
    //   }

    void Start() {

        Tween tween = background.DOFade(1, 0.5f);
        tween.OnComplete(StartGame);
    }

    void StartGame()
    {
        startGame.onClick.AddListener(LevelManager.GotoMain);
    }
   

    //IEnumerator ShowTouchText()
    //{
    //    touch_Text.gameObject.SetActive(true);
    //    yield return new WaitForSeconds(1f);
    //    touch_Text.gameObject.SetActive(false);
    //    yield return new WaitForSeconds(1f);
    //}


}
