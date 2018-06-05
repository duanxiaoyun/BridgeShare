using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordUI : UIBaseView {

    public Text txt_current;
    public Text txt_bast;
    public List<Toggle> starList;

    public void SetStarNum(int starCount)
    {
        starCount = Mathf.Clamp(starCount, 0, starList.Count);
        for (int i = 0; i < starCount; i++)
        {
            starList[i].isOn = true;
        }
        for (int i = starCount; i < starList.Count; i++)
        {
            starList[i].isOn = false;
        }
    }

    public void SetBestScore(int score)
    {
        txt_bast.text = score.ToString();
    }

    public void SetCurrentScore(int score)
    {
        txt_current.text = score.ToString();
    }
}
