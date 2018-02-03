using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour {

    public ScoreItem perfect = new ScoreItem(ScoreType.Perfect);
    public ScoreItem great = new ScoreItem(ScoreType.Great);
    public ScoreItem nice = new ScoreItem(ScoreType.Nice);
    public ScoreItem bad = new ScoreItem(ScoreType.Bad);
    public ScoreItem miss = new ScoreItem(ScoreType.Miss);
    public int totalScore;

    public void StartGame()
    {
        totalScore = 0;
    }

    public void AddScore(ScoreType type, int score, int hp)
    {
        switch (type)
        {
            case ScoreType.Perfect:
                perfect.Add(score, hp);
                break;
            case ScoreType.Great:
                great.Add(score, hp);
                break;
            case ScoreType.Nice:
                nice.Add(score, hp);
                break;
            case ScoreType.Bad:
                bad.Add(score, hp);
                break;
            case ScoreType.Miss:
                miss.Add(score, hp);
                break;
        }
        totalScore += score;
    }
}
