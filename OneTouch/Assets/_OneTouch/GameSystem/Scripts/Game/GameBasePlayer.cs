using UnityEngine;

public class GameBasePlayer : MonoBehaviour {

    public GameObject player;
    protected Animator playerAnim;
    
    // Use this for initialization
    protected virtual void Start()
    {
        playerAnim = player.GetComponent<Animator>();
    }    

    public void PlayWin()
    {
        playerAnim.SetBool("Win", true);
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

}
