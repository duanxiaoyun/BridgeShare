using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenuController : MonoBehaviour {
<<<<<<< HEAD
=======

>>>>>>> bf7561bdaa9840ce0e7233db83b007e51388f214
    public Button btn_back;
    //public Text txt_title;
    public List<UIGameSelectItem> gameUIList;
    public List<GameModel> gameDataList;

	// Use this for initialization
	void Start () {
        btn_back.onClick.AddListener(OnClickBack);
        for (int i = 0; i < gameDataList.Count;i++){
            SetGameItem(gameUIList[i],gameDataList[i]);
        }
	}
	

    void SetGameItem(UIGameSelectItem item, GameModel data){
        item.SetIcon(data.icon);
        item.SetTitle(data.name);
        item.SetStarNum(data.starNum);
        item.gameSence = data.sceneName;
        item.onStartGame = OnStarGame;
    }

    void OnStarGame(LevelName sceneName)
    {
        LevelManager.GotoLevel(sceneName);
    }

    void OnClickBack(){
        LevelManager.GotoLevel(LevelName.Main);
    }
}
