using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultUI : RecordUI {
    public Button btn_replay;
    public Text txt_miss;
    public Text txt_bad;
    public Text txt_nice;
    public Text txt_great;
    public Text txt_perfect;

	// Use this for initialization
	void Start () {

        btn_replay.onClick.AddListener(LevelManager.Replay);
    }

    // Update is called once per frame
    void Update () {
    }

    public void SetMiss(int num)
    {
        txt_miss.text = num.ToString();
    }

    public void SetBad(int num)
    {
        txt_bad.text = num.ToString();
    }

    public void SetNice(int num)
    {
        txt_nice.text = num.ToString();
    }

    public void SetGreat(int num)
    {
        txt_great.text = num.ToString();
    }

    public void SetPerfect(int num)
    {
        txt_perfect.text = num.ToString();
    }
}
