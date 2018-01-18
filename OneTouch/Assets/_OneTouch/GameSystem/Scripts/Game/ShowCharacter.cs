using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCharacter : MonoBehaviour {

    public GameObject girl;
    public GameObject boy;

	// Use this for initialization
	void Start () {
        girl.SetActive(false);
        boy.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {

	}

    public void ShowGirl()
    {
        girl.SetActive(true);
        boy.SetActive(false);
        GameArchive.user.sex = Sex.Girl;
        GameArchive.SaveUser();
    }

    public void ShowBoy()
    {
        boy.SetActive(true);
        girl.SetActive(false);
        GameArchive.user.sex = Sex.Boy;
        GameArchive.SaveUser();
    }


}
