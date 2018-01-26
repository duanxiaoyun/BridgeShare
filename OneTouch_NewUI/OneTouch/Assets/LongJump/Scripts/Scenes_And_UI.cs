using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class Scenes_And_UI : MonoBehaviour {

   
	DateTime nowTime;


	public GameObject dailyWanning;
	TimeSpan overTime;

	void Start(){
		dailyWanning.SetActive (false);
	}

    public void Back_To_Main()
    {
        SceneManager.LoadScene("Main");
    }

	public void Check_Limit(){


		if (PlayerPrefs.GetInt ("FarJump_limit") >= 3 && PlayerPrefs.GetInt ("FarJump_limit") != 0) {
			Debug.Log (PlayerPrefs.GetString ("PreTime"));
			string data = PlayerPrefs.GetString ("PreTime");
			DateTime dt = Convert.ToDateTime (data);

			nowTime = System.DateTime.Now;

			overTime = nowTime - dt;
			Debug.Log (overTime.TotalMinutes);
			if (overTime.TotalSeconds > 60 * 1) {
				PlayerPrefs.SetInt ("FarJump_limit",0);
				Debug.Log (nowTime);
			}
		}

		if(PlayerPrefs.GetInt ("FarJump_limit")>= 3){
			

			dailyWanning.SetActive (true);	

		} else {
			SceneManager.LoadScene ("FarJump");
		}
	}
}
