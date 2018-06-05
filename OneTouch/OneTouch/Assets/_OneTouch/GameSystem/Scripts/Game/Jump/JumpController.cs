using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class JumpController : MonoBehaviour {
    public Canvas canvas;
    public JumpBGClick bgClick;
    public JumpBGClick chClick;
    public GameController gameController;
    public GamePropController propController;
    public RectTransform rect_playerParent;
    public JumpPlayer player;
    public RectTransform content;
    public JumpNode nodePrefab;
    public int maxNodeCount = 5;
    public int currentNodeCount = 0;
    public float nextTime = 0;
    public List<NodeSkin> skinList;

    AudioSource jumpSounds;

    public AudioClip jumpSound;
    public AudioClip countSound;
    public AudioClip shotSound;
    public AudioClip missSound;

    public Text scoreText;
    private void Awake()
    {
        //GameArchive.user.coin = 100;
        //GameArchive.user.name = "PlayerName";
        //GameArchive.user.sex = Sex.Boy;
        //GameArchive.SaveUser();
        
        jumpSounds = GetComponent<AudioSource>();
        AudioManager.AudioManager.m_instance.SetMute(AudioManager.AudioManager.m_instance.m_backgroundMusicList, !(PlayerPrefs.GetInt("musicOn") == 1));
        jumpSounds.mute = !(PlayerPrefs.GetInt("soundOn") == 1);

        player = JumpPlayer.LoadPlayer(LevelName.Jump,GameArchive.user.sex).GetComponent<JumpPlayer>();
        player.rectTransform.SetParent(rect_playerParent,false);
    }

    // Use this for initialization
    IEnumerator Start () {

        //FindObjectOfType<BgSound>().GetComponent<AudioSource>().mute=true;
        AudioManager.AudioManager.m_instance.StopALL(AudioManager.AudioManager.m_instance.m_backgroundMusicList);
        jumpSounds.PlayOneShot(countSound);
        yield return new WaitForSeconds(2);
        jumpSounds.PlayOneShot(shotSound);
        jumpSounds.PlayDelayed(1.5f);

        //yield return new WaitForSeconds(3.25f);
        AudioManager.AudioManager.m_instance.PlayMusic("JumpBg");

        bgClick.onClickBackground += OnClickBackground;
        chClick.onClickBackground += OnClickBackground;
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
                    GameRule.jumpdistance = distance;
                    //Debug.Log(distance);
                    scoreText.text = ("+"+GameRule.AddScore(distance)).ToString();
                }
            }
            GameRuleData result = GameRule.GetJumpResult(isSuccess, usedTime, distance);
            gameController.CalculateScore(result);
            node.ShowResult(result.type);
            player.OnNodeComplete(isSuccess, result.type);
            jumpSounds.PlayOneShot(jumpSound);
        }
    }

    private void OnClickBackground()
    {
        player.PlayMiss();
        jumpSounds.PlayOneShot(missSound);
        gameController.CalculateScore(GameRule.ClickJumpBackground());
    }

    void OnNodeDestroy(){
        //nextTime = 0;
        currentNodeCount--;
    }


    void OnGameOver(bool isWin)
    {
        //Debug.Log(GameArchive.jumpRecord.IsHighRecord().ToString());
        Debug.Log(GameArchive.jumpRecord.GetHighScore().ToString());
        Debug.Log(gameController.gameData.totalScore.ToString());
        if (isWin)  //!gameController.playerHP.isDead
        {
            if (gameController.gameData.totalScore > GameArchive.jumpRecord.GetHighScore()/*GameArchive.jumpRecord.IsHighRecord()*/)
            {
                player.PlayHighScore();
            }
            else 
            {
                player.PlayJumpWin();
            }
            GameArchive.jumpRecord.AddStar(1);
        }
        else { 
            player.PlayLose();
        }
        
        GameArchive.jumpRecord.SetScore(gameController.gameData.totalScore);
    }

    //IEnumerator CountSound()
    //{
    //    jumpSounds.PlayOneShot(countSound);
    //    yield return new WaitForSeconds(2);
    //    //jumpSounds.Stop();
    //    jumpSounds.PlayOneShot(shotSound);
    //    jumpSounds.PlayDelayed(1f);
    //}
}
