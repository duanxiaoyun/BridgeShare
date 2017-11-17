using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Jump : MonoBehaviour {
	
	//float force = 250.0f;
	//bool isJump =false;

	Button Notes;
	Animator anim;

	//创建一个数组,在界面那里把预制物体拖进NotePrefab里
	GameObject[] NotePrefab;
	//计时器
	float timer = 0;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	 void Update () {

		//跳跃
		//if (Input.GetMouseButtonDown(0))  
		//{  
			//if (!isJump)//如果还在跳跃中，则不重复执行   허공일 때 Jump안됨 
			//{  
			///	GetComponent<Rigidbody>().AddForce(Vector3.up * force);  
			//	isJump = true;  
			//}  
		//}  

		timer += Time.deltaTime;

		if (timer >= 1) {
			
			timer = 0;

			//找到预制体
			GameObject NotePrefab = Resources.Load<GameObject> ("note" + Random.Range (0, 3));

			//随机预制体的位置
			Vector3 point = Camera.main.ViewportToWorldPoint (new Vector3 (Random.value, Random.value,-Camera.main.transform.position.z));

			//生成预制体
			GameObject notes = Instantiate (NotePrefab, point, NotePrefab.transform.rotation)as GameObject;
			notes.transform.SetParent (FindObjectOfType<Canvas>().transform);

			notes.GetComponent<Button> ().onClick.AddListener (delegate() {
				Destroy (notes);

				//StartCoroutine(Anim());
				anim.CrossFade("Jump",1.0f);
			});

			//五秒销毁预制体
			Destroy (notes, 5);
		}

//		if (Input.GetMouseButtonDown(0))  
//		{  
//			anim.CrossFade("Miss",1.0f);
//		} 

	}
//	IEnumerator Anim()
//	{
//		yield return new WaitForSeconds(0);
//		anim.CrossFade("Jump",1.0f);
//	}

//	public void OnButtonClick()
//	{
////		Image spr = Note.GetComponent<Image>();
////		Sprite sp = (Sprite)Resources.Load ("Buttons/Note_effect1",typeof (Sprite));
////		spr.sprite = sp;
//
////		anim.SetBool("IsJump", true);
//	}

	// 碰撞开始    
	//void OnCollisionEnter(Collision collision)  
	//{  
		//if (collision.collider.tag == "GameObject")//碰撞的是GameObject 지면과 충돌 하자마자 허공 상태 end   
		//{  
		//	isJump = false;  
		//}  
	//}  
}
