using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameCategory
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


public enum GamePropType
{
    Water,
    Bread
}


public struct GameRuleData
{
    public ScoreType type;
    public int score;
    public int hp;

    public void SetData(ScoreType type, int score, int hp)
    {
        this.type = type;
        this.score = score;
        this.hp = hp;
    }
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
/// <summary>
/// 游戏记录，
/// </summary>
[Serializable]
public class GameRecord {
    /// <summary>
    /// 分数
    /// </summary>
    public int score;
    /// <summary>
    /// 星星
    /// </summary>
    public int star;
}

public enum Sex {
    Girl,
    Boy
}

[Serializable]
public class User {
    public Sex sex;
    public string name;
    public int coin;
    // GameName_Sex
    // Ex:  Jump_Girl
    // Ex:  Jump_Boy
}


