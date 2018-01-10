using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpPlayer : MonoBehaviour {

    public GameObject Player;
    private  Animator PlayerAnim;


    // Use this for initialization
    void Start () {

        PlayerAnim = Player.GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {
        

    }

    public void PlayWin()
    {
        PlayerAnim.SetBool("Win", true);
    }

    public void PlayLose()
    {
        Debug.LogError("Add Lose Animation");
    }

    public void OnNodeComplete(bool isSuccess, ScoreType type){
        switch (type)
        {
            case ScoreType.Perfect:
                PlayerAnim.SetTrigger("Jump");
                break;
            case ScoreType.Great:
                PlayerAnim.SetTrigger("Jump");
                break;
            case ScoreType.Nice:
                PlayerAnim.SetTrigger("Jump");
                break;
            case ScoreType.Bad:
                break;
            case ScoreType.Miss:
                //Debug.Log("在这里播放 Miss 的动画");
                PlayerAnim.SetTrigger("Miss");
                break;
        }
    }
}
