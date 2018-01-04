using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameModel
{
    public string name;
    public LevelName sceneName;
    public Sprite icon;

    public int starNum;
    //public bool enabled;
}


public enum ScoreType
{
    Miss,
    Bad,
    Nice,
    Great,
    Perfect
}

[Serializable]
public class ScoreItem{
    public int totalScore;
    public int totalHP;
    public int count;
    public ScoreType type { get; private set; }

    public ScoreItem(ScoreType t){
        type = t;
        totalScore = 0;
        totalHP = 0;
        count = 0;
    }

    public void Add(int score,int hp){
        totalScore += score;
        totalHP += hp;
        count++;
    }
}