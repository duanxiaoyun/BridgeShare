using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Jump : MonoBehaviour {
	
	//float force = 250.0f;
	//bool isJump =false;

	Button Notes;
	Animator anim;

	//创建一个数组,在界面那里把预制物体拖进NotePrefab里
	public GameObject[] NotePrefabs;

    public GameObject StartEffect;
    public GameObject OverEffect;

    //计时器
    float timer = 0;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
        Destroy(StartEffect,1.5f);
    }
    private IEnumerator ShowA()
    {
        yield return new WaitForSeconds(2);
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
            Vector3 point = Camera.main.ViewportToWorldPoint (new Vector3 (Random.value, Random.value,-Camera.main.transform.position.z));

			//生成预制体
            GameObject notes = Instantiate(NotePrefab, point, NotePrefab.transform.rotation) as GameObject;
            notes.transform.SetParent(FindObjectOfType<Canvas>().transform);

            notes.GetComponent<Button> ().onClick.AddListener (delegate() {
				Destroy (notes);

				//StartCoroutine(Anim());
				anim.CrossFade("Jump",1.0f);
			});

			//五秒销毁预制体
			Destroy (notes, 5);
		}
	} 
}
