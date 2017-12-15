using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Scenes_And_UI : MonoBehaviour {

    [SerializeField]
    private GameObject Pause;

    private void Awake()
    {
        UIManageryun.Instance.Scenes_And_UI = this;
    }

    // Update is called once per frame
    void Update () {
	
	}

    public void Pause_Games()
    {
        Pause.SetActive(true);
        Time.timeScale = 0;
    }

    public void In_Pause_Games()
    {
        Pause.SetActive(false);
        Time.timeScale = 1;
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
    public void LoadScene_PushBall()
    {
        SceneManager.LoadScene("PushBall");
    }
}
