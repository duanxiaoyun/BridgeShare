using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCount : MonoBehaviour {

    public float _TimeCount;

	// Use this for initialization
	void Start () {

        _TimeCount = 0;

    }
	
	// Update is called once per frame
	void Update () {

        _TimeCount += Time.deltaTime;
	}
}
