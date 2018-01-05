﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void OnNodeComplete(bool isSuccess, ScoreType type){
        switch (type)
        {
            case ScoreType.Perfect:
                Debug.Log("在这里播放 Perfect 的动画");
                PlayerAnim.SetTrigger("Jump");
                break;
            case ScoreType.Great:
                Debug.Log("在这里播放 Great 的动画");
                PlayerAnim.SetTrigger("Jump");
                break;
            case ScoreType.Nice:
                Debug.Log("在这里播放 Nice 的动画");
                PlayerAnim.SetTrigger("Jump");
                break;
            case ScoreType.Bad:
                Debug.Log("在这里播放 Bad 的动画");
                break;
            case ScoreType.Miss:
                Debug.Log("在这里播放 Miss 的动画");
                PlayerAnim.SetTrigger("Miss");
                break;
        }
    }
}
