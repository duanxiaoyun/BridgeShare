using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneManageMe : MonoBehaviour {


	
	// Update is called once per frame
	void Update () {
	
	}
	public void LoadScene1()
	{
		SceneManager.LoadScene ("games");
	}
	public void LoadScene2()
	{
		SceneManager.LoadScene ("jump");
	}
	public void LoadScene3()
	{
		SceneManager.LoadScene ("Main");
	}

}
