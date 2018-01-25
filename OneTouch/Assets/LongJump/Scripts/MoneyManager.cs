using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour {
	public static MoneyManager instance;
	// Use this for initialization
	public int myGold;
	public int credit;
	public Text myGold_txt;
	public Text credit_txt;

	void Awake(){
		instance = this;

	}
	void Start () {
		myGold = PlayerPrefs.GetInt ("MyGold");
		//Debug.Log (myGold);
		credit = PlayerPrefs.GetInt ("Credit");
		//Debug.Log (credit);

		//myGold_txt = GetComponent<Text> () as Text;
		//credit_txt = GetComponent<Text> () as Text;*/
		myGold_txt.text = myGold.ToString("0000");
		credit_txt.text = credit.ToString("0000");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
