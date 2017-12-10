using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{

    Scenes_And_UI _Scenes_And_UI;
    public Scenes_And_UI Scenes_And_UI
    {
        get
        {
            return _Scenes_And_UI;
        }
        set
        {
            _Scenes_And_UI = value;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
