using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {
	
	float force = 250.0f;
	bool isJump =false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetMouseButtonDown(0))  
		{  
			if (!isJump)//如果还在跳跃中，则不重复执行   허공일 때 Jump안됨 
			{  
				GetComponent<Rigidbody>().AddForce(Vector3.up * force);  
				isJump = true;  
			}  
		}  
	}

	// 碰撞开始    
	void OnCollisionEnter(Collision collision)  
	{  
		if (collision.collider.tag == "GameObject")//碰撞的是GameObject 지면과 충돌 하자마자 허공 상태 end   
		{  
			isJump = false;  
		}  
	}  
}
