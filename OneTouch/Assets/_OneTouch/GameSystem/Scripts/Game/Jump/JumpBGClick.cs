using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JumpBGClick : UIBaseView,IPointerDownHandler {
    public Canvas canvas;
    public Image img_miss;
    public float lifetime = 0.4f;
    public float currentLifeTime;
    public UnityAction onClickBackground;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (img_miss.enabled)
        {
            currentLifeTime -= Time.deltaTime;
            if (currentLifeTime < 0){
                img_miss.enabled = false;
            }
         }
	}

    public void OnPointerDown(PointerEventData eventData)
    {
        img_miss.enabled = true;
        currentLifeTime = lifetime;
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, eventData.position,canvas.worldCamera,out pos);
        pos.y += img_miss.rectTransform.rect.height;
        img_miss.rectTransform.anchoredPosition = pos;
        if (onClickBackground != null)
            onClickBackground();
    }


}
