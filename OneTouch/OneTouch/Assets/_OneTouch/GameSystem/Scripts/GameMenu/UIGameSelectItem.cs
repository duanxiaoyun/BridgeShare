using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIGameSelectItem : UIBaseView {
    public LevelName gameSence;
    public Text txt_title;
    public Image img_icon;
    public Button btn_start;
    public Button btn_resetStar;
    public UIStarController starController;
    public UnityAction<LevelName> onStartGame;
    public UnityAction<UIGameSelectItem, LevelName> onReset;

    // Use this for initialization
    void Start () {
        btn_start.onClick.AddListener(OnClickStart);
        btn_resetStar.onClick.AddListener(OnClickReset);
    }

    public void SetTitle(string title){
        txt_title.text = title;
    }

    public void SetStarNum(int starCount){
        starController.SetStarNum(starCount);
    }

    public void SetIcon(Sprite spr_icon){
        img_icon.overrideSprite = spr_icon;
    }

    void OnClickStart(){
        if (onStartGame != null)
            onStartGame(gameSence);
    }

    void OnClickReset() {
        if (onReset != null)
            onReset(this,gameSence);
    }
}
