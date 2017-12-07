using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class JumpControll : MonoBehaviour {

    bool isJump = false;

    Button Notes;
    Animator Playeranim;
    Animation startAnim;

    //创建一个数组,在界面那里把预制物体拖进NotePrefab里
    public GameObject[] NotePrefabs;

    public GameObject StartEffect;
    public GameObject OverEffect;

    //计时器
    float timer = 0;

    //HP
    public int PlayerHp = 1000;
    public Text PlayerHpUI;

  

    // Use this for initialization
    void Start () {

        Playeranim = GetComponent<Animator>();
        Destroy(StartEffect,4f);
    }
    private IEnumerator ShowA()
    {
        yield return new WaitForSeconds(5);
        Update();
    }

    // Update is called once per frame
    void Update () {

		timer += Time.deltaTime;
        PlayerHpUI.text = PlayerHp.ToString();

        if (timer >= 2)
        {
            timer = 0;
        
        //找到预制体
        //GameObject NotePrefab = Resources.Load<GameObject>("note" + Random.Range(0, 3));
        GameObject NotePrefab = NotePrefabs[Random.Range(0, 4)];

        //随机预制体的位置
        //Vector2 point = Camera.main.ViewportToWorldPoint (new Vector2 (Random.value, Random.value));
        float x = Random.Range(-1100, 1100);
        float y = Random.Range(-300, 500);
        //float x1 = Random.Range(-400, 400);
        //float y1 = Random.Range(-300, 400);
        Vector2 point = new Vector2(x, y);

        //生成预制体

        GameObject notes = Instantiate(NotePrefab, point, NotePrefab.transform.rotation) as GameObject;

        notes.transform.SetParent(FindObjectOfType<Canvas>().transform);

        //点击note响应事件
        //notes.GetComponent<Button>().onClick.AddListener(delegate ()
        //{
        //    Destroy(notes);
        //    isJump = true;
        //    Playeranim.SetInteger("State", 2);

        //    AnimatorStateInfo animatorInfo;

        //    animatorInfo = Playeranim.GetCurrentAnimatorStateInfo(0);
        //    if ((animatorInfo.normalizedTime > 1) && (animatorInfo.IsName("Jump")))
        //    {
        //        Playeranim.SetInteger("State", 0);
        //    }
        //});

        
        //五秒销毁预制体
        Destroy (notes, 5);
        }

        //按下鼠标左键时响应该方法 
        if (isJump == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("~~~");
                Playeranim.SetInteger("State", 1);

                AnimatorStateInfo animatorInfo;

                animatorInfo = Playeranim.GetCurrentAnimatorStateInfo(0);

                if (animatorInfo.normalizedTime >= 1.0f && (animatorInfo.IsName("Miss")))
                {
                    Playeranim.SetInteger("State", 0);
                }
            }
        }
    }

}
