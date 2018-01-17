using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PushBallPlayer : GameBasePlayer
{
    public Image ballImage;
    public GameBGMove backGround;
    
    bool isRunning;

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
                //Debug.Log("Perfect ");
                playerAnim.SetBool("IsRun", true);
                
                StartRunAnim(5f);

                break;
            case ScoreType.Great:
                //Debug.Log(" Great ");
                playerAnim.SetBool("IsRun", true);
                StartRunAnim(5f);

                break;
            case ScoreType.Nice:
                //Debug.Log(" Nice ");
                playerAnim.SetBool("IsRun", true);
                StartRunAnim(4f);

                break;
            case ScoreType.Bad:
                //Debug.Log(" Bad ");

                StartRunAnim(1f);

                break;
            case ScoreType.Miss:
                //Debug.Log("Miss ");
                isRunning = false;

                playerAnim.SetTrigger("Miss");

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
            playerAnim.SetBool("IsRun", false);
            isRunning = false;
        }
    }

   

}
