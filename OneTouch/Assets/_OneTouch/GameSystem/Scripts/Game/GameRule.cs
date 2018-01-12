using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameRule  {

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

    public static JumpRuleData GetJumpRuleData(ScoreType type)
    {
        JumpRuleData ruleData = new JumpRuleData();
        switch (type)
        {
            case ScoreType.Perfect:
                ruleData.SetData(ScoreType.Perfect, 50, 0);
                break;
            case ScoreType.Great:
<<<<<<< HEAD
                ruleData.SetData(ScoreType.Great, 40, 0);
                break;
            case ScoreType.Nice:
                ruleData.SetData(ScoreType.Nice, 20, 0);
=======
                ruleData.SetData(ScoreType.Great, 20, 0);
                break;
            case ScoreType.Nice:
                ruleData.SetData(ScoreType.Nice, 10, 0);
>>>>>>> c4da8e9d2da7157464ddb789010b6c34d059dfff
                break;
            case ScoreType.Bad:
                ruleData.SetData(ScoreType.Bad, 0, 0);
                break;
            default:
<<<<<<< HEAD
                ruleData.SetData(ScoreType.Miss, -10, -10);
=======
                ruleData.SetData(ScoreType.Miss, -20, -10);
>>>>>>> c4da8e9d2da7157464ddb789010b6c34d059dfff
                break;
        }
        return ruleData;
    }

    public static JumpRuleData GetJumpResult(bool isSuccess, float usedTime,float distance)
    {
        return GetJumpRuleData(GetJumpScoreType(isSuccess,usedTime,distance));
    }

    public static JumpRuleData ClickJumpBackground() {
        return GetJumpRuleData(ScoreType.Miss);
    }

    public static float GetWaterDoubleScoreTime() {
        return Random.Range(3f,5f);
    }

    public static int GetBreadHPCount() {
        return Random.Range(3,5);
    }
}
