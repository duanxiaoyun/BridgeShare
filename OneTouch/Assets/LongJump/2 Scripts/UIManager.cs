using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public static UIManager instance;
	public Text nowScoreText;
	public float nowScore;

	public Text topScoreText;
	public static float topScore;

	void Awake(){
		instance = this;
	}

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void LateUpdate () {
		nowScore = PlayerController.instance.nowScore;
		//topScore = PlayerController.instance.topScore;

		nowScoreText.text = nowScore.ToString("0000.0"+ "M");
		topScoreText.text = topScore.ToString ("0000.0" + "M");


	}
}
