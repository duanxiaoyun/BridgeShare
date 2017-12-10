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


    //******Jump******

    public int JumpLevelStar = 0;
    public int JumpScore = 0;
    public int JumpHighScore = 0;


    //******FarJump******






    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
