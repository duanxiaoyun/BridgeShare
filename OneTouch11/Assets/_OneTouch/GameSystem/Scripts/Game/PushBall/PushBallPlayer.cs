//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PushBallPlayer : MonoBehaviour
{

    public Image PlayerImage;
    public Image BallImage;
    public GameBGMove bg1;

    public GameController GameController1;

    public Image LevelImage;

    public Sprite[] LeveliPics;

    private Animator Playeranim;

    bool isRunning;

    //private  animator Playerani;
    // Use this for initialization
    void Start () {

        Playeranim = PlayerImage.GetComponent<Animator>();
        isRunning = false;

    }
	
	// Update is called once per frame
	void Update () {
        if (isRunning)
        {
            BallImage.transform.Rotate(new Vector3(0, 0, 1), -5f);
            bg1.ResumeGame();
        }
        else
        {
            bg1.PauseGame();
        }

        if (GameController1.isGameOver && GameController1.playerHP.currentHP >= 0)
        {
            Playeranim.SetBool("Win", true);
        }
	}

    public void OnTouchLineComplete(bool isSuccess,ScoreType type)
    {
        switch (type){
            case ScoreType.Perfect:
                //Debug.Log("Perfect ");
                Playeranim.SetBool("IsRun", true);
                LevelImage.overrideSprite = LeveliPics[0];
                
                StartRunAnim(5f);

                break;
            case ScoreType.Great:
                //Debug.Log(" Great ");
                Playeranim.SetBool("IsRun", true);
                LevelImage.overrideSprite = LeveliPics[1];
                StartRunAnim(5f);

                break;
            case ScoreType.Nice:
                //Debug.Log(" Nice ");
                Playeranim.SetBool("IsRun", true);
                LevelImage.overrideSprite = LeveliPics[2];
                StartRunAnim(4f);

                break;
            case ScoreType.Bad:
                //Debug.Log(" Bad ");
                LevelImage.overrideSprite = LeveliPics[3];

                StartRunAnim(1f);

                break;
            case ScoreType.Miss:
                //Debug.Log("Miss ");
                LevelImage.overrideSprite = LeveliPics[4];
                isRunning = false;

                Playeranim.SetTrigger("Miss");

                break;
        }
    }

    void StartRunAnim(float time)
    {
        isRunning = true;
        StartCoroutine(StopRunAnim(time));
    }

    IEnumerator StopRunAnim(float time)
    {
        while (isRunning)
        {
            yield return new WaitForSeconds(time);
            Playeranim.SetBool("IsRun", false);
            isRunning = false;
        }
    }

   

}
