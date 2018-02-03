using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameBGMove : UIBaseView {
    public RectTransform content;
    public RawImage rawImg_bg1;
    public RawImage rawImg_bg2;

    public PushBallPlayer player;

    bool isMoveUV = false;
    public float speed=10;
    Rect uvRect;
    bool isPause = false;
    Tween tweenMove;

	// Use this for initialization
	void Start () {
        
	}

    private void OnMoveEnd()
    {
        isMoveUV = true;
        uvRect = rawImg_bg2.uvRect;
    }

    // Update is called once per frame
    void Update () {
        if(isMoveUV && !isPause){
            uvRect.x += Time.deltaTime / speed;
            if (uvRect.x > 1) uvRect.x -= 1;
            rawImg_bg2.uvRect = uvRect;
        }
	}

    public void StartGame(){

        content.sizeDelta = new Vector2(rectTransform.rect.width * 2, rectTransform.rect.height);
        rawImg_bg1.rectTransform.anchoredPosition = new Vector2(0, 0);
        rawImg_bg1.rectTransform.SetParent(content);
        rawImg_bg2.rectTransform.anchoredPosition = new Vector2(rectTransform.rect.width, 0);
        rawImg_bg2.rectTransform.SetParent(content);
        rawImg_bg2.uvRect = new Rect(0, 0, 1, 1);

        isMoveUV = false;
        isPause = false;

        tweenMove = content.DOAnchorPos(new Vector2(-rectTransform.rect.width, 0), speed);
        tweenMove.SetEase(Ease.Linear);
        tweenMove.OnComplete(OnMoveEnd);
    }

    public void PauseGame(){
        isPause = true;
        if (tweenMove != null && tweenMove.IsPlaying())
            tweenMove.Pause();
    }

    public void ResumeGame(){
        isPause = false;
        if (tweenMove != null && !tweenMove.IsComplete())
            tweenMove.Play();
    }
}
