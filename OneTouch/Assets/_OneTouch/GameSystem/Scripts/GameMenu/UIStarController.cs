using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStarController : MonoBehaviour {

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
}
