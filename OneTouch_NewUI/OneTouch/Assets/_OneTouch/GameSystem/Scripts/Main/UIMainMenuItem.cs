using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenuItem : UIBaseView {
    public Button button;
    public Text textComponent;

    public Image button_Avatar;
	// Use this for initialization
	void Start () {
        
	}
	
    public void SetText(string text){
        textComponent.text = text;
    }
}
