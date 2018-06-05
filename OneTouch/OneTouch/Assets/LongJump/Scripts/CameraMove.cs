using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {
	public static CameraMove instance;
	private Transform camPos;


	// Use this for initialization
	void Awake () {
		camPos = GetComponent<Transform> ();



	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (this.transform.position.x <= PlayerController.instance.transform.position.x) {
			camPos.position = new Vector3 (PlayerController.instance.transform.position.x, PlayerController.instance.transform.position.y, transform.position.z);
		}
		if (PlayerController.instance.transform.position.y >= 0) {
			camPos.position = new Vector3 (transform.position.x, PlayerController.instance.transform.position.y, transform.position.z);
		} else if (PlayerController.instance.transform.position.y <= 0) {
			camPos.position = new Vector3 (transform.position.x, 0, transform.position.z);
		}
	}
}
