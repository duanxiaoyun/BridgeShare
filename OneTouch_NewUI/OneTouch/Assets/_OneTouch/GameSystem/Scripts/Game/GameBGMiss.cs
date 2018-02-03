using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameBGMiss : UIBaseView
{
    public Image img_miss;
    public float lifetime = 0.4f;
    public float currentLifeTime;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (img_miss.enabled)
        {
            currentLifeTime -= Time.deltaTime;
            if (currentLifeTime < 0)
            {
                img_miss.enabled = false;
            }
        }
    }

    public void ShowMiss() {
        img_miss.enabled = true;
        currentLifeTime = lifetime;
    }
}
