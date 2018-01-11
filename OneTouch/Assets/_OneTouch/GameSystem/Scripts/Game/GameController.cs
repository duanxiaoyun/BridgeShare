using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour {
    public GameBGMove background;
    public GameUI gameUI;
    public PauseUI pauseUI;
    public ResultUI resultUI;
    public GameTime gameTime;
    public PlayerHP playerHP;
    public GameData gameData;
    public bool isGameStart{ get { return gameTime.isStart; }}
    public bool isGameOver;
    public GameRecord highRecord;
    public UnityAction onGameStart;
    public UnityAction<bool> onGameOver;

    public GameObject[] gameEffs;

    // Use this for initialization
    IEnumerator Start () {
        gameUI.btn_pause.onClick.AddListener(PauseGame);
        pauseUI.btn_resume.onClick.AddListener(ResumeGame);
        gameTime.onTimeOver += OnTimeOver;
        playerHP.onPlayerDead += OnPlayerDead;
        playerHP.onHPChanged += OnHPChanged;

        gameEffs[0].SetActive(true);
        yield return new WaitForSeconds(3.25f);
        gameEffs[0].SetActive(false);

        StartGame();
        gameUI.SetMaxHP(playerHP.maxHP);
        gameUI.SetCurrentHP(playerHP.currentHP);
        gameUI.SetScore(gameData.totalScore);
	}
	
	// Update is called once per frame
	void Update () {
        if (!isGameOver && gameTime.isStart && !gameTime.isTimeOver)
        {
            gameUI.SetTime(gameTime.currentTime);
        }
	}

    void StartGame()
    {
        isGameOver = false;
        gameData.StartGame();
        playerHP.StartGame();
        gameTime.StartGame();

        if(background!=null)
            background.StartGame();
        if (onGameStart != null)
            onGameStart();
    }

    void PauseGame()
    {
        gameTime.PauseGame();
        pauseUI.Show();
        pauseUI.SetCurrentScore(gameData.totalScore);
        pauseUI.SetStarNum(highRecord.star);
        pauseUI.SetBestScore(highRecord.score);
        gameUI.Hide();
        if (background != null)
            background.PauseGame();
    }

    void ResumeGame()
    {
        pauseUI.Hide();
        gameUI.Show();
        gameTime.ResumeGame();
        if (background != null)
            background.ResumeGame();
    }

    public void UpdateStar() {
        gameUI.SetStarNum(highRecord.star);
    }

    void OnTimeOver()
    {
        gameUI.SetTime(gameTime.currentTime);
        isGameOver = true;
        WaitShowResult();
        if (onGameOver != null)
            onGameOver(true);
    }

    void OnPlayerDead()
    {
        isGameOver = true;
        WaitShowResult();
        if (onGameOver != null)
            onGameOver(false);
    }

    void OnHPChanged(int hp)
    {
        gameUI.SetCurrentHP(playerHP.currentHP);
    }

    void WaitShowResult()
    {
        StartCoroutine(WaitShowResult(3f));
    }

    IEnumerator WaitShowResult(float time)
    {
        yield return new WaitForSeconds(time);//播放角色的gameover的动画

        gameEffs[1].SetActive(true);
        yield return new WaitForSeconds(2.0f);// 播放游戏的gameover的动画效果。
        gameEffs[1].SetActive(false);

        ShowResult();
    }

    void ShowResult()
    {
        gameUI.Hide();

        resultUI.Show();
        
        resultUI.SetStarNum(highRecord.star);
        resultUI.SetBestScore(highRecord.score);

        resultUI.SetCurrentScore(gameData.totalScore);
        resultUI.SetPerfect(gameData.perfect.count);
        resultUI.SetGreat(gameData.great.count);
        resultUI.SetNice(gameData.nice.count);
        resultUI.SetBad(gameData.bad.count);
        resultUI.SetMiss(gameData.miss.count);
    }


    public void AddScore(ScoreType type,int score,int hp){
        gameData.AddScore(type,score,hp);
        gameUI.SetScore(gameData.totalScore);
        playerHP.AddHP(hp);
    }
}
