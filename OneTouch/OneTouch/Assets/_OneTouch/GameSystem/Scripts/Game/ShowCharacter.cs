using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowCharacter : MonoBehaviour {

    public Image character_Sex;

    public UIMainMenuItem menu_user;

    public Button exit_button;

    // Use this for initialization
    void Start () {
        character_Sex.overrideSprite = (Sprite)Resources.Load("idle_" + GameArchive.user.sex.ToString(), typeof(Sprite));
    }
	
	// Update is called once per frame
	void Update () {
        character_Sex.overrideSprite = (Sprite)Resources.Load("idle_" + GameArchive.user.sex.ToString(), typeof(Sprite));
    }

    public void ShowGirl()
    {
        AudioManager.AudioManager.m_instance.PlaySFX("Click");
        menu_user.transform.GetChild(1).gameObject.GetComponent<Image>().overrideSprite = (Sprite)Resources.Load("User_Girl", typeof(Sprite));
        GameArchive.user.sex = Sex.Girl;
        GameArchive.SaveUser();
    }

    public void ShowBoy()
    {
        AudioManager.AudioManager.m_instance.PlaySFX("Click");
        menu_user.transform.GetChild(1).gameObject.GetComponent<Image>().overrideSprite = (Sprite)Resources.Load("User_Boy", typeof(Sprite));
        GameArchive.user.sex = Sex.Boy;
        GameArchive.SaveUser();
    }


}
