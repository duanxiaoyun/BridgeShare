using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//using UnityEditor;
using System;

public class JumpControll : MonoBehaviour
{

    bool isJump = false;
    private bool isMiss;

    private Animator Playeranim;
    Animation startAnim;

    //数组,NotePrefabs
    [SerializeField]
    private GameObject[] NotePrefabs;
    [SerializeField]
    private GameObject[] NotePrefabsEffs;

    int noteTimer = 5;
    GameObject notelevel;

    [SerializeField]
    private GameObject[] NoteLevels;

    GameObject notes;
    GameObject notesEff;

    [SerializeField]
    private GameObject StartEffect;
    [SerializeField]
    private GameObject OverEffect;

    [SerializeField]
    private Sprite[] numbers;
    [SerializeField]

    int[] nums = new int[2];

    [SerializeField]
    private GameObject TimeNum;
    [SerializeField]
    private float timer = 30.0f;

    private int Score;

    [SerializeField]
    private GameObject ScoreUI;

    [SerializeField]
    private GameObject ResultUI;

    //计时器
    float Notetimer = 0;

    //HP
    [SerializeField]
    private int PlayerHp = 1000;
    [SerializeField]
    private Text PlayerHpUI;

    private void Awake()
    {
        PlayerManager.Instance.JumpControll= this;
    }

        // Use this for initialization
    void Start ()
    {
        Playeranim = GetComponent<Animator>();
        Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Notetimer += Time.deltaTime;

        PlayerHpUI.text = PlayerHp.ToString();

        PlayerHpUI.GetComponentInParent<Slider>().value = PlayerHp / 1000.0f;

        if (Notetimer >= 2)
        {
            Notetimer = 0;

                  //指定随机预制体
            int noteindex = UnityEngine.Random.Range(0, 4);

            GameObject NotePrefab = NotePrefabs[noteindex];

                   //随机预制体的位置和范围
            //Vector2 point = Camera.main.ViewportToWorldPoint(new Vector2(Random.value, Random.value));

            float x = UnityEngine.Random.Range(-1100, 1100);
            float y = UnityEngine.Random.Range(-300, 500);
            //float x1 = Random.Range(-400, 400);
            //float y1 = Random.Range(-300, 400);

            Vector2 point = new Vector2(x, y);

                  //在指定范围生成note预制体
            notes = Instantiate(NotePrefab, point, NotePrefab.transform.rotation) as GameObject;
            notes.transform.SetParent(FindObjectOfType<Canvas>().transform);

                  //获取note组件
            if (notes != null)
            {
                TimeCount _TimeCountScript= notes.AddComponent<TimeCount>();
            }

                    //点击note响应事件
            notes.GetComponent<Button>().onClick.AddListener(delegate ()
            {
                Score += 5;
                Playeranim.SetTrigger("Jump");

                Notetimer += notes.GetComponent<TimeCount>()._TimeCount;
                
                GameObject NoteLevelPrefab = NoteLevels[Convert.ToUInt32(Notetimer.ToString().Split('.')[0])];

                //notes 爆炸效果
                notesEff = Instantiate(NotePrefabsEffs[noteindex], point, 
                    NotePrefab.transform.rotation) as GameObject;
                
                //删除note
                Destroy(notes,0.0f);

                //删除note爆炸
                Destroy(notesEff, 1.0f);

                //生成notelevel
                notelevel = Instantiate(NoteLevelPrefab, new Vector2(point.x, point.y + 200), 
                    NoteLevelPrefab.transform.rotation) as GameObject;

                notelevel.transform.SetParent(FindObjectOfType<Canvas>().transform);

                //销毁notelevel预制体
                Destroy(notelevel, 0.5f);
            });

                //五秒销毁预制体
            Destroy(notes, 5);

        }

        if (timer >= 0.1f)
        {
            timer -= Time.deltaTime;

            for (int i = 0; i < 2; i++)
            {
                nums[0] = Convert.ToInt32(timer.ToString("0.0").Split('.')[0]) / 10;
                nums[1] = Convert.ToInt32(timer.ToString("0.0").Split('.')[0]) % 10;
                TimeNum.transform.GetChild(i).GetComponent<Image>().sprite = numbers[nums[i]];
            }
        }
        if (timer < 0.1f)
        {
            Time.timeScale = 0;
            ResultUI.SetActive(true);
        }

        ScoreUI.transform.GetChild(1).GetComponent<Image>().sprite = numbers[Score % 10];
        ScoreUI.transform.GetChild(2).GetComponent<Image>().sprite = numbers[(Score / 10)%10];
        ScoreUI.transform.GetChild(3).GetComponent<Image>().sprite = numbers[Score / 100];

        HandleInput();
        Miss();
        ResetValues();
    }

    private void Miss()
    {
        if (isMiss)
        {
            Playeranim.SetTrigger("Miss");
        }
    }
    private void ResetValues()
    {
        isMiss = false;
    }

    private void HandleInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider.tag == "bg")
            {
                isMiss = true;
                PlayerHp -= 10;
            }
            else 
            {
                //Debug.Log("Target Position: " + Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z + 200.0f)));
            }
        }

    }


}
