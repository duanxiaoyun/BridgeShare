using UnityEngine;

public class GameBasePlayer : MonoBehaviour {

    private RectTransform m_RectTransform;
    public RectTransform rectTransform { get { return m_RectTransform ?? (m_RectTransform = GetComponent<RectTransform>()); } }

    public GameObject player;
    public Animator playerAnim;
    
    // Use this for initialization
    protected virtual void Start()
    {
        playerAnim = player.GetComponent<Animator>();
    }    

    public void PlayJumpWin()
    {
        playerAnim.SetBool("Win", true);
    }
    public void PlayPushBallWin()
    {
        playerAnim.SetTrigger("Win");
        
    }

    public void PlayHighScore()
    {
        playerAnim.SetTrigger("HighScore");
    }

    public void PlayLose()
    {
        playerAnim.SetTrigger("GameOver");
    }

    public void PlayMiss()
    {
        playerAnim.SetTrigger("Miss");
    }


    public static GameObject LoadPlayer(LevelName level,Sex sex) {
        string path = string.Format("{0}_{1}", level,sex);
        Debug.Log(path);
        return Instantiate(Resources.Load(path)) as GameObject;
    }
}
