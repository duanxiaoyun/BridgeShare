using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour {
    public RectTransform uiRootRect;
    public GameController game;
    public JumpPlayer player;
    public RectTransform content;
    public JumpNode nodePrefab;
    public int maxNodeCount = 5;
    public int currentNodeCount = 0;
    public float nextTime = 0;
    public List<JumpNodeSkin> skinList;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (game.isGameStart && !game.isGameOver)
        {
            nextTime -= Time.deltaTime;
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
        Vector2 pos = uiRootRect.rect.size * 0.5f;
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

    void OnComplete(JumpNode node,bool isSuccess,float usedTime){
        ScoreType type = ScoreType.Miss;
        int score = -20, hp = -5;
        if (isSuccess)
        {
            if (usedTime <= 1)
            {
                type = ScoreType.Perfect;
                score = 50;
                hp = 0;
            }
            else if (usedTime <= 2)
            {
                type = ScoreType.Great;
                score = 20;
                hp = 0;
            }
            else if (usedTime <= 3)
            {
                type = ScoreType.Nice;
                score = 10;
                hp = 0;
            }
            else if (usedTime <= 4)
            {
                type = ScoreType.Bad;
                score = 0;
                hp = 0;
            }
        }
        //Debug.Log(type + "  :  " + score + "  :  " + usedTime);
        node.ShowResult(type);
        game.AddScore(type, score, hp);
        player.OnNodeComplete(isSuccess, type);
    }

    void OnNodeDestroy(){
        nextTime = 0;
        currentNodeCount--;
    }
}
