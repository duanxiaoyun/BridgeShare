using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    //public GameObject StartEff;

	// Use this for initialization
	void Start () {
        gameUI.btn_pause.onClick.AddListener(PauseGame);
        pauseUI.btn_resume.onClick.AddListener(ResumeGame);
        gameTime.onTimeOver = OnTimeOver;
        playerHP.onPlayerDead = OnPlayerDead;
        playerHP.onHPChanged = OnHPChanged;
        StartGame();
        //StartCoroutine(WaitStartTime());

        gameUI.SetMaxHP(playerHP.maxHP);
        gameUI.SetCurrentHP(playerHP.currentHP);
        gameUI.SetScore(gameData.totalScore);
	}
	
	// Update is called once per frame
	void Update () {
        if (!isGameOver && gameTime.isStart && !gameTime.isEnd)
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
    }

    void PauseGame()
    {
        gameTime.PauseGame();
        pauseUI.Show();
        pauseUI.SetCurrentScore(gameData.totalScore);
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

    void OnTimeOver()
    {
        gameUI.SetTime(gameTime.currentTime);
        isGameOver = true;
        //ShowResult();
        StartCoroutine(WaitShowResult(3f));
    }

    void OnPlayerDead()
    {
        isGameOver = true;
        //ShowResult();
        StartCoroutine(WaitShowResult(3f));
    }

    void OnHPChanged(int hp)
    {
        gameUI.SetCurrentHP(playerHP.currentHP);
    }

    void ShowResult()
    {
        gameTime.PauseGame();
        gameUI.Hide();
        resultUI.Show();
        resultUI.SetCurrentScore(gameData.totalScore);
        resultUI.SetPerfect(gameData.perfect.count);
        resultUI.SetGreat(gameData.great.count);
        resultUI.SetNice(gameData.nice.count);
        resultUI.SetBad(gameData.bad.count);
        resultUI.SetMiss(gameData.miss.count);
    }

    IEnumerator WaitShowResult(float time)
    {
        yield return new WaitForSeconds(time);
        ShowResult();
    }

    //IEnumerator WaitStartTime()
    //{
    //    StartEff.SetActive(true);
    //    StartEff.transform.GetChild(0).GetComponent<Animator>().Play("StartEffAni", 0);
    //    yield return new WaitForSeconds(3.0f);
    //    StartGame();
    //    StartEff.SetActive(false);
    //}


    public void AddScore(ScoreType type,int score,int hp){
        gameData.AddScore(type,score,hp);
        gameUI.SetScore(gameData.totalScore);
        playerHP.AddHP(hp);
    }
}
