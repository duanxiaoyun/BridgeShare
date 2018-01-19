using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowCharacter : MonoBehaviour {

    public GameObject girl;
    public GameObject boy;

    public UIMainMenuItem menu_user;

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
        menu_user.transform.GetChild(1).gameObject.GetComponent<Image>().overrideSprite = (Sprite)Resources.Load("User_Girl", typeof(Sprite));
        GameArchive.user.sex = Sex.Girl;
        GameArchive.SaveUser();
    }

    public void ShowBoy()
    {
        boy.SetActive(true);
        girl.SetActive(false);
        menu_user.transform.GetChild(1).gameObject.GetComponent<Image>().overrideSprite = (Sprite)Resources.Load("User_Boy", typeof(Sprite));
        GameArchive.user.sex = Sex.Boy;
        GameArchive.SaveUser();
    }


}
