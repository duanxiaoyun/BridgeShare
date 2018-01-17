using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class JumpController : MonoBehaviour {
    public Canvas canvas;
    public JumpBGClick bgClick;
    public GameController gameController;
    public GamePropController propController;
    public JumpPlayer player;
    public RectTransform content;
    public JumpNode nodePrefab;
    public int maxNodeCount = 5;
    public int currentNodeCount = 0;
    public float nextTime = 0;
    public List<NodeSkin> skinList;
 

    // Use this for initialization
    void Start () {
        bgClick.onClickBackground += OnClickBackground;
        propController.onPickWater += gameController.OnPickWater;
        propController.onPickBread += gameController.OnPickBread;

        gameController.highRecord = GameArchive.jumpRecord.GetRecord();
        gameController.UpdateStar();
        gameController.onGameOver += OnGameOver;

    }
    
    // Update is called once per frame
    void Update () {
        if (gameController.isGaming)
        {
            nextTime -= Time.deltaTime;
            propController.UpdateCreate();
            if (nextTime < 0)
            {
                if (currentNodeCount < maxNodeCount)
                {
                    Create();
                    nextTime = Random.Range(2, 4);
                }
            }
        }
	}

    void Create()
    {
        Vector2 pos = content.rect.size * 0.5f;
        pos.x -= 200;
        pos.x = Random.Range(-pos.x, pos.x);
        pos.y -= 400;
        pos.y = Random.Range(-pos.y, pos.y);
        JumpNode temp = Instantiate(nodePrefab) as JumpNode;
        temp.rectTransform.SetParent(content, false);
        temp.center = pos;
        temp.SetNode(skinList[Random.Range(0,skinList.Count-1)]);
        temp.onComplete = OnComplete;
        temp.onNodeDestroy = OnNodeDestroy;
        currentNodeCount++;
    }

    void OnComplete(JumpNode node,bool isSuccess,float usedTime,Vector2 clickPosition){
        if (gameController.isGaming)
        {
            float distance = float.MaxValue;
            if (isSuccess)
            {
                Vector2 pos;
                if (RectTransformUtility.ScreenPointToLocalPointInRectangle(content, clickPosition, canvas.worldCamera, out pos))
                {
                    distance = Vector2.Distance(pos, node.center);
                }
            }
            GameRuleData result = GameRule.GetJumpResult(isSuccess, usedTime, distance);
            gameController.CalculateScore(result);
            node.ShowResult(result.type);
            player.OnNodeComplete(isSuccess, result.type);
        }
    }

    private void OnClickBackground()
    {
        player.PlayMiss();
        gameController.CalculateScore(GameRule.ClickJumpBackground());
    }

    void OnNodeDestroy(){
        //nextTime = 0;
        currentNodeCount--;
    }


    void OnGameOver(bool isWin)
    {
        if (isWin)  //!gameController.playerHP.isDead
        {
            if (GameArchive.jumpRecord.IsHighRecord())
            {
                player.PlayHighScore();
            }
            else
            {
                player.PlayWin();
            }
            GameArchive.jumpRecord.AddStar(1);
        }
        else { 
            player.PlayLose();
        }

        GameArchive.jumpRecord.SetScore(gameController.gameData.totalScore);
    }

}
