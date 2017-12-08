using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEditor;
using System;

public class JumpControll : MonoBehaviour {

    bool isJump = false;

    Button Notes;

    Animator Playeranim;
    Animation startAnim;

    //数组,NotePrefabs
    public GameObject[] NotePrefabs;
    public GameObject[] NotePrefabsEffs;

    int noteTimer = 5;
    public Image notelevel;
    public Sprite[] NoteLevels;

    GameObject notes;
    GameObject notesEff;

    public GameObject StartEffect;
    public GameObject OverEffect;

    //计时器
    float timer = 0;

    //HP
    public int PlayerHp = 1000;
    public Text PlayerHpUI;

    // Use this for initialization
    void Start ()
    {
        Playeranim = GetComponent<Animator>();
        Destroy(StartEffect,4f);
    }
    private IEnumerator ShowA()
    {
        yield return new WaitForSeconds(5);
        Update();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        PlayerHpUI.text = PlayerHp.ToString();

        if (timer >= 2)
        {
            timer = 0;

                //找到预制体
            int noteindex = UnityEngine.Random.Range(0, 4);

            GameObject NotePrefab = NotePrefabs[noteindex];

                //随机预制体的位置和范围
            //Vector2 point = Camera.main.ViewportToWorldPoint (new Vector2 (Random.value, Random.value));

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

                //notes 爆炸效果
                notesEff = Instantiate(NotePrefabsEffs[noteindex], point, NotePrefab.transform.rotation) as GameObject;
                Destroy(notesEff, 2);
                notelevel.GetComponent<Image>().sprite = Instantiate(NoteLevels[4], point, NotePrefab.transform.rotation) as Sprite;
                notelevel.transform.position = point;
            });

                //五秒销毁预制体
            Destroy(notes, noteTimer);
            timer -= Time.deltaTime;
            noteTimer = Convert.ToInt32(timer.ToString("0.0").Split('.')[0]);   
            if (noteTimer == 0)
            {
                notelevel.GetComponent<Image>().sprite = Instantiate(NoteLevels[4], point, NotePrefab.transform.rotation) as Sprite;
                notelevel.transform.position = point;
            }
            
        }

            //按下鼠标左键时响应该方法 
        if (isJump == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Playeranim.SetInteger("State", 1);
            }

            if (Input.GetMouseButtonUp(0))
            {
                Playeranim.SetInteger("State", 0);
            }
        }
    }
}
