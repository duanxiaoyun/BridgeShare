using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameTime : MonoBehaviour {
    public float currentTime;
    public float timeLength = 30;

    public bool isStart { get; private set; }
    public bool isPause { get; private set; }
    public bool isEnd { get; private set; }
    public UnityAction onTimeOver;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if(isStart && !isPause && !isEnd){
            currentTime -= Time.deltaTime;
            if(currentTime<0){
                currentTime = 0;
                isEnd = true;
                if (onTimeOver != null)
                    onTimeOver();
            }
        }
	}

    public void SetTimeLength(float length){
        timeLength = length;
    }

    public void StartGame(){
        isStart = true;
        isEnd = false;
        isPause = false;
        currentTime = timeLength;
        Time.timeScale = 1;
    }

    public void PauseGame(){
        isPause = true;
        Time.timeScale = 0;
    }

    public void ResumeGame(){
        isPause = false;
        Time.timeScale = 1;
    }

    public void AddGameTime(float addTime){
        currentTime += addTime;
    }
}
