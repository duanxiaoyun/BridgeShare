using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SplashManager : MonoBehaviour {
    public RawImage background;

    // Use this for initialization
    //IEnumerator Start () {
    //       yield return new WaitForSeconds(2);
    //       LevelManager.GotoMain();
    //   }

    void Start() {

        Tween tween = background.DOFade(1, 2);
        tween.OnComplete(LevelManager.GotoMain);
    }
}
