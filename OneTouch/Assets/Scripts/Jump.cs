﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Jump : MonoBehaviour {
	
	//float force = 250.0f;
	//bool isJump =false;

	Button Notes;
    Animator Playeranim;
    Animation startAnim;

    //创建一个数组,在界面那里把预制物体拖进NotePrefab里
    public GameObject[] NotePrefabs;

    public GameObject StartEffect;
    public GameObject OverEffect;

    //计时器
    float timer = 0;

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

		if (timer >= 2) {
			
			timer = 0;

            //找到预制体
            //GameObject NotePrefab = Resources.Load<GameObject>("note" + Random.Range(0, 3));
            GameObject NotePrefab = NotePrefabs[Random.Range(0, 4)];

            //随机预制体的位置
            Vector2 point = Camera.main.ViewportToWorldPoint (new Vector2 (Random.value, Random.value));

			//生成预制体
            GameObject notes = Instantiate(NotePrefab, point, NotePrefab.transform.rotation) as GameObject;

            notes.transform.SetParent(FindObjectOfType<Canvas>().transform);

            //五秒销毁预制体
            Destroy (notes, 5);
		}

        //点击note响应事件
        //notes.GetComponent<Button>().onClick.AddListener(delegate ()
        //{
        //    Destroy(notes);
        //    Playeranim.SetBool("IsJump", true);
        //});

        if (Playeranim == null) return;

        AnimatorStateInfo stateInfo = Playeranim.GetCurrentAnimatorStateInfo(0);

        //按下鼠标左键时响应该方法  
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("~~~");
            Playeranim.SetInteger("States", 1);
        }

        if (stateInfo.normalizedTime >= 1.0f)
        {
            //播放完毕，要执行的内容
            //Playeranim.SetBool("IsJump", false);
            Playeranim.SetInteger("States", 0);
        }
    } 
}