﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PushBallController : MonoBehaviour
{
    public Canvas canvas;
    public GameController gameController;
    public GameBGMove backGround;
    public GameBGMiss bgMiss;
    public RectTransform rect_playerParent;
    public PushBallPlayer player;
    public RectTransform content;
    public UITouchLine linePrefab;
    public int maxNodeCount = 2;
    public int currentNodeCount = 0;
    public float nextTime = 0;

    public Text ScoreTimes;

    AudioSource pushBallSounds;

    public AudioClip runSound;
    public AudioClip countSound;
    public AudioClip shotSound;
    public AudioClip popSound;

    private void Awake()
    {
        //GameArchive.user.coin = 100;
        //GameArchive.user.name = "PlayerName";
        //GameArchive.user.sex = Sex.Girl;
        //GameArchive.SaveUser();

        pushBallSounds = GetComponent<AudioSource>();
        AudioManager.AudioManager.m_instance.SetMute(AudioManager.AudioManager.m_instance.m_backgroundMusicList, !(PlayerPrefs.GetInt("musicOn") == 1));
        pushBallSounds.mute = !(PlayerPrefs.GetInt("soundOn") == 1);

        player = PushBallPlayer.LoadPlayer(LevelName.PushBall, GameArchive.user.sex).GetComponent<PushBallPlayer>();
        player.rectTransform.SetParent(rect_playerParent, false); 
        player.backGround = backGround;
    }

    // Use this for initialization
    IEnumerator Start () {

        AudioManager.AudioManager.m_instance.StopALL(AudioManager.AudioManager.m_instance.m_backgroundMusicList);
        //FindObjectOfType<BgSound>().GetComponent<AudioSource>().mute = true;

        //StartCoroutine(CountSound());
        pushBallSounds.PlayOneShot(countSound);
        yield return new WaitForSeconds(2);
        pushBallSounds.Stop();
        pushBallSounds.PlayOneShot(shotSound);
        pushBallSounds.PlayDelayed(1.5f);

        
        AudioManager.AudioManager.m_instance.PlayMusic("PushBallBg");

        gameController.highRecord = GameArchive.pushBallRecord.GetRecord();
        gameController.UpdateStar();
        gameController.onGameOver += OnGameOver;

        yield return new WaitForSeconds(1f);
        player.playerAnim.SetBool("IsRun", true);
        player.isRunning = true;
    }
	
	// Update is called once per frame
	void Update () {
        if(gameController.isGaming)
        {
            nextTime -= Time.deltaTime;
            if (nextTime < 0)
            {
                if (currentNodeCount < maxNodeCount)
                {
                    Create();
                    nextTime = Random.Range(3, 4);//生成间隔时间
                }
            }
        }
	}


    void Create(){
        Vector2 pos = content.rect.size * 0.5f;
        pos.y = Random.Range(-200,200);//第一个点的位置范围。
        UITouchLine temp = Instantiate(linePrefab) as UITouchLine;
        temp.rectTransform.SetParent(content,false);
        temp.rectTransform.anchoredPosition = pos;
        temp.leftSide = -pos.x;
        temp.circleCount = Random.Range(2,5);
        temp.onComplete = OnComplete;
        temp.onStartClickPosition = OnStartClickNodePosition;
        currentNodeCount++;
    }

    void OnStartClickNodePosition(TouchLineStatus status, UITouchLine parent, UICircle circle, Vector2 clickPosition) {
        float distance = float.MaxValue;
        bool isSuccess = status == TouchLineStatus.Line;
        if (isSuccess)
        {
            Vector2 pos;
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(parent.rectTransform, clickPosition, canvas.worldCamera, out pos))
            {
                distance = Vector2.Distance(pos, circle.center);
            }
        }
        ScoreType type = GameRule.GetPushBallScoreType(isSuccess, distance);

        if (type == ScoreType.Perfect) ScoreTimes.text = "X 50";
        else if (type == ScoreType.Great) ScoreTimes.text = "X 40";
        else if (type == ScoreType.Nice) ScoreTimes.text = "X 30";
        else if (type == ScoreType.Bad) ScoreTimes.text = "X 20";
        else if (type == ScoreType.Miss) ScoreTimes.text = "X 0";
        //ScoreTimes.text = (GameRule.nscore + "x" + GameRule.ncount).ToString();

        parent.SetScoreType(type);
        circle.ShowResult(type);
        pushBallSounds.PlayOneShot(popSound);
    }

    void OnComplete(TouchLineStatus status, ScoreType scoreType, int index){
        if (status != TouchLineStatus.Normal && status != TouchLineStatus.Line && gameController.isGaming)
        {
            currentNodeCount--;
            //nextTime = 0;
            //Debug.Log(type + "  :  " + score + "  :  " + usedTime);
            GameRuleData result = GameRule.GetPushBallRuleData(scoreType, index+1);
            pushBallSounds.PlayOneShot(popSound);
            gameController.CalculateScore(result);
            player.OnTouchLineComplete(status, scoreType);
            if (status == TouchLineStatus.OutComplete)
                bgMiss.ShowMiss();
            pushBallSounds.PlayOneShot(runSound);
            
        }
    }
    
    void OnGameOver(bool isWin)
    {
        
        if (isWin)  //!gameController.playerHP.isDead
        {
            if (gameController.gameData.totalScore > GameArchive.pushBallRecord.GetHighScore()/*GameArchive.pushBallRecord.IsHighRecord()*/)
            {
                player.PlayHighScore();
                player.isRunning = false;
            }
            else
            {
                player.PlayPushBallWin();
                player.isRunning = false;
                
            }
            GameArchive.pushBallRecord.AddStar(1);
        }
        else
        {
            player.PlayLose();
        }

        GameArchive.pushBallRecord.SetScore(gameController.gameData.totalScore);
    }

    IEnumerator CountSound()
    {
        pushBallSounds.PlayOneShot(countSound);
        yield return new WaitForSeconds(2);
        pushBallSounds.Stop();
        pushBallSounds.PlayOneShot(shotSound);
        pushBallSounds.PlayDelayed(1f);
    }
}
