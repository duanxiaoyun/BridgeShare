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
    public List<JumpNodeSkin> skinList;
    public float doubleScoreTime = 0;
 

<<<<<<< HEAD
=======

>>>>>>> c4da8e9d2da7157464ddb789010b6c34d059dfff
    // Use this for initialization
    void Start () {
        bgClick.onClickBackground += OnClickBackground;
        propController.onPickWater += OnPickWater;
        propController.onPickBread += OnPickBread;
        doubleScoreTime = 0;

        gameController.highRecord = GameArchive.GetJumpRecord();
        gameController.UpdateStar();
        gameController.onGameOver += OnGameOver;

    }
    
    // Update is called once per frame
    void Update () {
        if (gameController.isGameStart && !gameController.isGameOver)
        {
            doubleScoreTime -= Time.deltaTime;
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
        float distance = float.MaxValue;
        if (isSuccess) {
			Vector2 pos;
			if (RectTransformUtility.ScreenPointToLocalPointInRectangle (content, clickPosition, canvas.worldCamera, out pos)) {
				distance = Vector2.Distance (pos, node.center);
			}
        }
        JumpRuleData result = GameRule.GetJumpResult(isSuccess, usedTime, distance);
        CalculateScore(result, doubleScoreTime);
        node.ShowResult(result.type);
        player.OnNodeComplete(isSuccess, result.type);
    }

    void OnPickWater(float doubleScoreTime) {
        if (this.doubleScoreTime < 0)
            this.doubleScoreTime = 0;
        this.doubleScoreTime += doubleScoreTime;
    }

    void OnPickBread(int hp)
    {
        gameController.playerHP.AddHP(hp);
    }

    private void OnClickBackground()
    {
        player.PlayMiss();
        CalculateScore(GameRule.ClickJumpBackground(), doubleScoreTime);
    }

    void CalculateScore(JumpRuleData data, float doubleScoreTime) {
        if (doubleScoreTime > 0 && data.score > 0)
            data.score *= 2;
        gameController.AddScore(data.type, data.score, data.hp);
    }

    void OnNodeDestroy(){
        nextTime = 0;
        currentNodeCount--;
    }


    void OnGameOver(bool isWin)
    {
        if (isWin)  //!gameController.playerHP.isDead
        {
            if (GameArchive.IsHighRecord())
            {
                player.PlayHighScore();
            }
            else
            {
                player.PlayWin();
            }
            GameArchive.AddJumpStar(1);
        }
        else { 
            player.PlayLose();
        }

        GameArchive.SetJumpScore(gameController.gameData.totalScore);
    }

}
