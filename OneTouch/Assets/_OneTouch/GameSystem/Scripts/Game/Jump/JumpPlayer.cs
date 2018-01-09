using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpPlayer : MonoBehaviour {

    public GameObject Player;
    private  Animator PlayerAnim;

    public Image LevelImage;

    public Sprite[] LeveliPics;

    public GameController_Jump GameController2;

    // Use this for initialization
    void Start () {

        PlayerAnim = Player.GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {

        if (GameController2.isGameOver && GameController2.playerHP.currentHP >= 0)
        {
            PlayerAnim.SetBool("Win", true);
        }

    }

    public void OnNodeComplete(bool isSuccess, ScoreType type){
        switch (type)
        {
            case ScoreType.Perfect:
                LevelImage.overrideSprite = LeveliPics[0];
                PlayerAnim.SetTrigger("Jump");
                break;
            case ScoreType.Great:
                LevelImage.overrideSprite = LeveliPics[1];
                PlayerAnim.SetTrigger("Jump");
                break;
            case ScoreType.Nice:
                LevelImage.overrideSprite = LeveliPics[2];
                PlayerAnim.SetTrigger("Jump");
                break;
            case ScoreType.Bad:
                LevelImage.overrideSprite = LeveliPics[3];
                break;
            case ScoreType.Miss:
                //Debug.Log("在这里播放 Miss 的动画");
                LevelImage.overrideSprite = LeveliPics[4];
                PlayerAnim.SetTrigger("Miss");
                break;
        }
    }
}
