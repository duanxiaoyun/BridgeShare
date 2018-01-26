using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenuController : MonoBehaviour {
    public Button btn_back;
    //public Text txt_title;
    public List<UIGameSelectItem> gameUIList;
    public List<GameCategory> gameDataList;
   
    // Use this for initialization
    void Start () {

        FindObjectOfType<BgSound>().GetComponent<AudioSource>().mute = false;

        //gameDataList[0].starNum = GameArchive.GetJumpStar();

        btn_back.onClick.AddListener(OnClickBack);
        for (int i = 0; i < gameDataList.Count;i++){
            if (gameDataList[i].sceneName == LevelName.Jump) {
                gameDataList[i].starNum = GameArchive.jumpRecord.GetStar();
            }
            if (gameDataList[i].sceneName == LevelName.PushBall)
            {
                gameDataList[i].starNum = GameArchive.pushBallRecord.GetStar();
            }
            SetGameItem(gameUIList[i],gameDataList[i]);
        }
	}
	

    void SetGameItem(UIGameSelectItem item, GameCategory data){
        item.SetIcon(data.icon);
        item.SetTitle(data.name);
        item.SetStarNum(data.starNum);
        item.gameSence = data.sceneName;
        item.onStartGame = OnStarGame;
        item.onReset = OnReset;
    }

    void OnStarGame(LevelName sceneName)
    {
        LevelManager.GotoLevel(sceneName);
    }

    void OnReset(UIGameSelectItem item,LevelName sceneName)
    {
        int star = 0;
        item.SetStarNum(star);
        switch (sceneName) {
            case LevelName.Jump:
                GameArchive.jumpRecord.CleanRecord();
                break;
            case LevelName.PushBall:
                GameArchive.pushBallRecord.CleanRecord();
                break;
            case LevelName.FarJump:
                //GameArchive.SetFarJumpStar(star);
                break;
        }
    }

    void OnClickBack(){
        LevelManager.GotoLevel(LevelName.Main);
    }
}
