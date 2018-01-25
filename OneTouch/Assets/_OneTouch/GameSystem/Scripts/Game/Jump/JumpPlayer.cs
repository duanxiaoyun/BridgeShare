
public class JumpPlayer : GameBasePlayer
{
    public void OnNodeComplete(bool isSuccess, ScoreType type){
        switch (type)
        {
            case ScoreType.Perfect:
                playerAnim.SetTrigger("Jump");
                break;
            case ScoreType.Great:
                playerAnim.SetTrigger("Jump");
                break;
            case ScoreType.Nice:
                playerAnim.SetTrigger("Jump");
                break;
            case ScoreType.Bad:
                playerAnim.SetTrigger("Jump");
                break;
            case ScoreType.Miss:
                PlayMiss();
                break;
        }
    }
}
