using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using UnityEngine.Events;



public class JumpNode : GameBaseNode,IPointerClickHandler {
  
    public float lifetime = 5;
    public float currentLifeTime;
    public float usedTime { get { return lifetime - currentLifeTime; } }
    public UnityAction<JumpNode,bool, float,Vector2> onComplete;

	// Use this for initialization
	void Start () {
        currentLifeTime = lifetime;
	}
	
	// Update is called once per frame
	void Update () {
        if (interactable)
        {
            currentLifeTime -= Time.deltaTime;
            if (currentLifeTime < 0)
            {
                InvokeComplete(false,false,Vector2.zero);
            }
        }
	}

    public void OnPointerClick(PointerEventData eventData)
    {
        if (interactable)
        {
            InvokeComplete(true, true, eventData.position);
        }
    }

    void InvokeComplete(bool isSuccess,bool isClick,Vector2 clickPostion)
    {
        interactable = false;
        animator.gameObject.SetActive(false);
        if(isClick) particles.SetActive(true);
        if (onComplete != null)
            onComplete(this,isSuccess, usedTime, clickPostion);
        StartCoroutine(WaitDestroy(isClick ? 0.4f : 0));
    }

}
