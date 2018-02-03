using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameRule  {

    public static float jumpdistance;

    //public static int ncount;
    //public static int nscore;

    #region JumpRule
    public static ScoreType GetJumpScoreType(bool isSuccess, float usedTime, float distance)
    {
        ScoreType type = ScoreType.Miss;
        if (isSuccess)
        {
            if (usedTime <= 1)
            {
                type = ScoreType.Perfect;
            }
            else if (usedTime <= 2)
            {
                type = ScoreType.Great;
            }
            else if (usedTime <= 3)
            {
                type = ScoreType.Nice;
            }
            else if (usedTime <= 4)
            {
                type = ScoreType.Bad;
            }

        }
        return type;
    }

    public static int AddScore(float distance)
    {
        int _addScore=0;

        if (distance > 0 && distance < 20)
        {
            _addScore = 50;
            Debug.Log(_addScore);
        }
        else if (distance >= 20 && distance <= 40)
        {
            _addScore = 40;
            Debug.Log(_addScore);
        }
        else if (distance >= 40 && distance <= 60)
        {
            _addScore = 30;
            Debug.Log(_addScore);
        }
        else if (distance >= 60 && distance <= 80)
        {
            _addScore = 20;
            Debug.Log(_addScore);
        }
        else if (distance >= 80 && distance <= 100)
        {
            _addScore = 10;
            Debug.Log(_addScore);
        }
        return _addScore;
    }

    public static GameRuleData GetJumpRuleData(ScoreType type)
    {
        

        GameRuleData ruleData = new GameRuleData();
        switch (type)
        {
            case ScoreType.Perfect:
                ruleData.SetData(ScoreType.Perfect, AddScore(jumpdistance), 0);
                break;
            case ScoreType.Great:
                ruleData.SetData(ScoreType.Great, AddScore(jumpdistance)/*40*/, 0);
                break;
            case ScoreType.Nice:
                ruleData.SetData(ScoreType.Nice, AddScore(jumpdistance)/*20*/, 0);
                break;
            case ScoreType.Bad:
                ruleData.SetData(ScoreType.Bad, AddScore(jumpdistance)/*0*/, 0);
                break;
            default:
                ruleData.SetData(ScoreType.Miss, AddScore(jumpdistance)/*0*/, -20);
                break;
        }
        return ruleData;
    }

    public static GameRuleData GetJumpResult(bool isSuccess, float usedTime,float distance)
    {
        return GetJumpRuleData(GetJumpScoreType(isSuccess,usedTime,distance));
    }

    public static GameRuleData ClickJumpBackground() {
        return GetJumpRuleData(ScoreType.Miss);
    }
    #endregion

    #region PropRule
    public static float GetWaterDoubleScoreTime() {
        return Random.Range(3f,5f);
    }

    public static int GetBreadHPCount() {
        return Random.Range(3,5);
    }
    #endregion

    #region PushBallRule
    public static ScoreType GetPushBallScoreType(bool isSuccess, float distance)
    {
        Debug.Log("distance:" + distance);
        ScoreType type = ScoreType.Miss;
        if (isSuccess)
        {
            if (distance <= 150)
            {
                type = ScoreType.Perfect;
            }
            else if (distance > 150 && distance <= 190)
            {
                type = ScoreType.Great;
            }
            else if (distance > 190 && distance <= 230)
            {
                type = ScoreType.Nice;
            }
            else if (distance > 230 && distance <= 270)
            {
                type = ScoreType.Bad;
            }
        }
        //return isSuccess? ScoreType.Perfect : ScoreType.Miss;
        return isSuccess ? type : ScoreType.Miss;
    }

    public static GameRuleData GetPushBallRuleData(ScoreType type,int count)
    {
        GameRuleData ruleData = new GameRuleData();
        switch (type)
        {
            case ScoreType.Perfect:
                ruleData.SetData(ScoreType.Perfect, 50, 0);
                break;
            case ScoreType.Great:
                ruleData.SetData(ScoreType.Great, 40, 0);
                break;
            case ScoreType.Nice:
                ruleData.SetData(ScoreType.Nice, 20, 0);
                break;
            case ScoreType.Bad:
                ruleData.SetData(ScoreType.Bad, 0, 0);
                break;
            default:
                ruleData.SetData(ScoreType.Miss, 0, -20);
                break;
        }
        ruleData.score *= count;
        Debug.Log("count:"+count + "  score="+ ruleData.score);
        //ncount = count;
        //nscore = ruleData.score;
        return ruleData;
    }
    #endregion
}
