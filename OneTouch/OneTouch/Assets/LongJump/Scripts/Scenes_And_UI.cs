using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class Scenes_And_UI : MonoBehaviour
{

    public AudioClip buttonSound;

    AudioSource myAudio;
    DateTime nowTime;


    public GameObject dailyWanning;
    TimeSpan overTime;

    private void Awake()
    {
        myAudio = GetComponent<AudioSource>();
    }

    void Start()
    {
        dailyWanning.SetActive(false);
    }
    public void DailyTable_Off()
    {
        dailyWanning.SetActive(false);
    }
    public void BonusGames()
    {
        myAudio.PlayOneShot(buttonSound);
        SceneManager.LoadScene("BonusGames");
    }
    /*public void MainGames()
    {
        myAudio.PlayOneShot(buttonSound);
        SceneManager.LoadScene("GameMenu");
    }
    public void Main()
    {
        myAudio.PlayOneShot(buttonSound);
        SceneManager.LoadScene("Main");
    }*/

    public void Check_Limit()
    {

        if (PlayerPrefs.GetInt("FarJump_limit") >= 3 && PlayerPrefs.GetInt("FarJump_limit") != 0)
        {
            Debug.Log(PlayerPrefs.GetString("PreTime"));
            myAudio.PlayOneShot(buttonSound);
            string data = PlayerPrefs.GetString("PreTime");
            DateTime dt = Convert.ToDateTime(data);

            nowTime = System.DateTime.Now;
            Debug.Log(nowTime);
            overTime = nowTime - dt;
            Debug.Log(overTime.TotalSeconds);
            if (overTime.TotalSeconds > 60 * 1)
            {
                PlayerPrefs.SetInt("FarJump_limit", 0);
                Debug.Log(nowTime);
            }
            Debug.Log(PlayerPrefs.GetInt("FarJump_limit"));

        }
        if (PlayerPrefs.GetInt("FarJump_limit") >= 0 && PlayerPrefs.GetInt("FarJump_limit") < 3)
        {
            SceneManager.LoadScene("FarJump");

        }
        else
        {
            dailyWanning.SetActive(true);
        }
    }
}
