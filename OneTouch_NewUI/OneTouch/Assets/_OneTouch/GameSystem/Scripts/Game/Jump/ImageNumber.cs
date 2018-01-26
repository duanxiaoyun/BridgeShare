using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageNumber : UIBaseView {
    public List<Sprite> numberList;
    public Image img_2;
    public Image img_1;


    public void SetTime(float time){
        int t =(int)Mathf.Ceil(time);
        int t2 =Mathf.Clamp(t/10,0,9);
        int t1 = t % 10;
        img_2.overrideSprite = numberList[t2];
        img_1.overrideSprite = numberList[t1];
    }
}
