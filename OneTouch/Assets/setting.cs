using UnityEngine;
using System.Collections;

public class setting : MonoBehaviour {

	public GameObject settingpad;

	// Use this for initialization
	void Start () {
		settingpad.SetActive (false);
	}


	// Update is called once per frame
	void Update () {
	
	}
	public void LoadSetting()
	{
		settingpad.SetActive (true);
	}
	public void CloseSetting()
	{
		settingpad.SetActive (false);
	}
}
