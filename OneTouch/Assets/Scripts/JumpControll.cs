using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEditor;
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
    [SerializeField]
    private Image notelevel;
    [SerializeField]
    private Sprite[] NoteLevels;

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

    //计时器
    float Notetimer = 0;

    //HP
    [SerializeField]
    private int PlayerHp = 1000;
    [SerializeField]
    private Text PlayerHpUI;

    private void Awake()
    {
        GameManagers.Instance.JumpControll= this;
    }

        // Use this for initialization
        void Start ()
    {
        Playeranim = GetComponent<Animator>();
        Destroy(StartEffect,4f);//游戏开始特效
    }
    private IEnumerator ShowA()
    {
        yield return new WaitForSeconds(5);//游戏5秒后再开始
        Update();
    }



    // Update is called once per frame
    void Update()
    {
        Notetimer += Time.deltaTime;

        PlayerHpUI.text = PlayerHp.ToString();

        if (Notetimer >= 2)
        {
            Notetimer = 0;

            //找到预制体
            int noteindex = UnityEngine.Random.Range(0, 4);

            GameObject NotePrefab = NotePrefabs[noteindex];

            //随机预制体的位置和范围
            //Vector2 point = Camera.main.ViewportToWorldPoint(new Vector2(Random.value, Random.value));

            float x = UnityEngine.Random.Range(-1100, 1100);
            float y = UnityEngine.Random.Range(-300, 500);
            //float x1 = Random.Range(-400, 400);
            //float y1 = Random.Range(-300, 400);

            Vector2 point = new Vector2(x, y);

            //生成预制体
            notes = Instantiate(NotePrefab, point, NotePrefab.transform.rotation) as GameObject;
            notes.transform.SetParent(FindObjectOfType<Canvas>().transform);

            //点击note响应事件
            notes.GetComponent<Button>().onClick.AddListener(delegate ()
            {
                Destroy(notes);
                isJump = true;
                Playeranim.SetTrigger("Jump");

                //notes 爆炸效果
                notesEff = Instantiate(NotePrefabsEffs[noteindex], point, NotePrefab.transform.rotation) as GameObject;
                Destroy(notesEff, 2);
                //notelevel.GetComponent<Image>().sprite = Instantiate(NoteLevels[4], point, NotePrefab.transform.rotation) as Sprite;
                //notelevel.transform.position = point;
            });

            //五秒销毁预制体
            Destroy(notes, noteTimer);
            //timer -= Time.deltaTime;
            //noteTimer = Convert.ToInt32(timer.ToString("0.0").Split('.')[0]);   
            //if (noteTimer == 0)
            //{
            //    notelevel.GetComponent<Image>().sprite = Instantiate(NoteLevels[4], point, NotePrefab.transform.rotation) as Sprite;
            //    notelevel.transform.position = point;
            //}
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
        if (!isJump)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isMiss = true;
            }
        } 

    }
}
