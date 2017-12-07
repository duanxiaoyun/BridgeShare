using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneManageMe : MonoBehaviour {

    public GameObject Pause;

	// Update is called once per frame
	void Update () {
	
	}

    public void Pause_Games()
    {
        Pause.SetActive(true);
    }

    public void In_Pause_Games()
    {
        Pause.SetActive(false);
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
    public void LoadScene_FarJump()
    {
        SceneManager.LoadScene("FarJump");
    }
}
