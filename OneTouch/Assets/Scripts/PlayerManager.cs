using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    JumpControll _JumpControll;

    public JumpControll JumpControll
    {
        get
        {
            return _JumpControll;
        }
        set
        {
            _JumpControll = value;
        }
    }

    //******Main******

    public int Coin;
    public int Card;
    public int Shoes;
    public int Today_play_times=0;


    //******Jump******

    public int JumpLevelStar = 0;
    public int JumpScore = 0;
    public int JumpHighScore = 0;

    //******FarJump******

    public int FarJumpStar = 0;
    public int FarJumpScore = 0;
    public int FarJumpHighScore = 0;

    //******PushBall******

    public int PushBallStar = 0;
    public int PushBallScore = 0;
    public int PushBallHighScore = 0;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
