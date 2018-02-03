using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PushBallPlayer : GameBasePlayer
{
    public Image ballImage;
    public GameBGMove backGround;

    public GameController gameController;

    public bool isRunning;

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        isRunning = false;
     
    }

    // Update is called once per frame
    void Update() {
        if (isRunning)
        {
            ballImage.transform.Rotate(new Vector3(0, 0, 1), -5f);
            backGround.ResumeGame();
        }
       
        else 
        {
            backGround.PauseGame();
        }
       
    }
    
    public void OnTouchLineComplete(TouchLineStatus status, ScoreType type)
    {
        switch (type){
            case ScoreType.Perfect:
                playerAnim.SetBool("IsRun", true);
                isRunning = true;
                //StartRunAnim(5f);

                break;
            case ScoreType.Great:
                playerAnim.SetBool("IsRun", true);
                isRunning = true;
                //StartRunAnim(5f);

                break;
            case ScoreType.Nice:
                playerAnim.SetBool("IsRun", true);
                isRunning = true;
                //StartRunAnim(4f);

                break;
            case ScoreType.Bad:
                playerAnim.SetBool("IsRun", true);
                isRunning = true;
                //StartRunAnim(1f);

                break;
            case ScoreType.Miss:
                //Debug.Log("Miss ");
                isRunning = false;
                playerAnim.SetBool("IsRun", false);
                //playerAnim.SetTrigger("Miss");
                PlayMiss();
                break;
        }
    }

    //void StartRunAnim(float time)
    //{
    //    isRunning = true;
    //    StartCoroutine(StopRunAnim(time));
    //}

    //IEnumerator StopRunAnim(float time)
    //{
    //    while (isRunning)
    //    {
    //        yield return new WaitForSeconds(time);
    //        playerAnim.SetBool("IsRun", false);
    //        isRunning = false;
    //    }
    //}

}
