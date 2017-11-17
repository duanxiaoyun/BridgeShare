using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneManageMe : MonoBehaviour {


	
	// Update is called once per frame
	void Update () {
	
	}
	public void LoadScene_Games()
	{
		SceneManager.LoadScene ("games");
	}
	public void LoadScene_Jump()
	{
		SceneManager.LoadScene ("jump");
	}
	public void LoadScene_Main()
	{
		SceneManager.LoadScene ("Main");
	}

}
