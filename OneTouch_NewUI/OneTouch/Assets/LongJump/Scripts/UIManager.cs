using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UIManager : MonoBehaviour {

	public static UIManager instance;
	public Text nowScoreText;
	public float nowScore;

	public Text topScoreText;
	public static float topScore;

	public Sprite[] numbers;
	int[] nums = new int[2];
	public GameObject timeNum;


	void Awake(){
		instance = this;
	}

	// Use this for initialization
	void Start () {
		

	}
	void Update(){
		if (PlayerController.instance.timer <= 30 && PlayerController.instance.timer >= 0) {
			timeNum.SetActive (true);
		} else {
			timeNum.SetActive (false);
		}
		if (PlayerController.instance.timer >= 0) {
			for (int i = 0; i < 2; i++) {
				nums [0] = Convert.ToInt32 (PlayerController.instance.seconds.ToString ("0.0").Split ('.') [0]) / 10;
				nums [1] = Convert.ToInt32 (PlayerController.instance.seconds.ToString ("0.0").Split ('.') [0]) % 10;
				timeNum.transform.GetChild (i).GetComponent<Image> ().sprite = numbers [nums [i]];
			}
		}
	
	}
	
	// Update is called once per frame
	void LateUpdate () {



		nowScore = PlayerController.instance.nowScore;
		//topScore = PlayerController.instance.topScore;

		nowScoreText.text = nowScore.ToString("0.0"+ "M");
		topScoreText.text = topScore.ToString ("0.0" + "M");


	}
}
