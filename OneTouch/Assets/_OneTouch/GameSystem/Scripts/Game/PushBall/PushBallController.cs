using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBallController : MonoBehaviour {
    public GameController_PushBall game;
    public PushBallPlayer player;
    public RectTransform content;
    public UITouchLine linePrefab;
    public Rect startRect;
    public int currentIndex = 0;
    public float nextTime = 0;
    public int count=0;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if(game.isGameStart && !game.isGameOver){
            nextTime -= Time.deltaTime; 
            if(nextTime<0){
                if (count < 2)
                {
                    Create(startRect, currentIndex % 2 == 0);
                    nextTime = Random.Range(2, 5);
                    currentIndex++;
                }
                //else
                    //nextTime = Random.Range(3, 5);
            }
        }
	}


    void Create(Rect rect,bool isLeft){
        Vector2 pos = new Vector2(Random.Range(rect.xMin, rect.xMax), Random.Range(rect.yMin, rect.yMax));
        pos.y -= rect.height * 0.5f;
        if (isLeft) pos.x -= content.rect.width * 0.5f;
        //Debug.Log(pos);
        UITouchLine temp = Instantiate(linePrefab) as UITouchLine;
        temp.rectTransform.SetParent(content,false);
        temp.rectTransform.anchoredPosition = pos;
        //temp.circleCount = 2;
        temp.onComplete = OnComplete;
        count++;
    }

    void OnComplete(bool isSuccess,float usedTime,Vector2 lastPos){
        ScoreType type = ScoreType.Miss;
        int score = -20, hp = -5;
        if(isSuccess){
            if(usedTime<=1)
            {
                type = ScoreType.Perfect;
                score = 50;
                hp = 0;
            }
            else if(usedTime<=2)
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
        nextTime = 0;
        count--;
        //Debug.Log(type + "  :  " + score + "  :  " + usedTime);
        game.AddScore(type, score, hp);
        player.OnTouchLineComplete(isSuccess,type);
    }
}
