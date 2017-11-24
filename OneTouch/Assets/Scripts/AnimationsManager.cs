using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsManager : MonoBehaviour {

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {
		//if (Input.GetKey(KeyCode.Space))
		//{
		//    anim.SetInteger("States", 2);
		//}
		if (Input.GetMouseButtonDown(0))
		{
			//anim.SetInteger("States", 2);
			anim.SetBool("IsJump", true);
		}
		if (Input.GetMouseButtonUp(0))
		{
			anim.SetBool("IsJump", false);
		}
		if (Input.GetKey(KeyCode.I))
		{
			anim.SetInteger("States", 1);
		}
		if (Input.GetKey(KeyCode.M))
		{
			anim.SetInteger("States", 3);
		}
		if (Input.GetKey(KeyCode.W))
		{
			anim.SetInteger("States", 4);
		}
	}
}
