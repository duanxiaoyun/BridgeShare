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
    public List<Toggle> starList;
    public UnityAction<LevelName> onStartGame;

	// Use this for initialization
	void Start () {
        btn_start.onClick.AddListener(OnClickStart);
	}

    public void SetTitle(string title){
        txt_title.text = title;
    }

    public void SetStarNum(int starCount){
        starCount = Mathf.Clamp(starCount, 0, starList.Count);
        for (int i = 0; i < starCount; i++)
        {
            starList[i].isOn = true;
        }
        for (int i = starCount; i < starList.Count; i++)
        {
            starList[i].isOn = false;
        }
    }

    public void SetIcon(Sprite spr_icon){
        img_icon.overrideSprite = spr_icon;
    }

    void OnClickStart(){
        if (onStartGame != null)
            onStartGame(gameSence);
    }
}
