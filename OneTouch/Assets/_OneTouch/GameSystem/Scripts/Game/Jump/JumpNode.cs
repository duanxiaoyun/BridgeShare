using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using UnityEngine.Events;

[Serializable]
public class JumpNodeSkin{
    public Sprite circle;
    public Sprite triangle1;
    public Sprite triangle2;
    public Color startColor1;
    public Color startColor2;
}

public class JumpNode : UIBaseView,IPointerClickHandler {
    public bool interactable = true;
    public Animator animator;
    public Image img_circle;
    public Image img_triangle1;
    public Image img_triangle2;
    public GameObject particles;
    public ParticleSystem par_1;
    public ParticleSystem par_2;
    public ParticleSystem par_3;
    public ParticleSystem par_4;

    public Image img_level;
    public Sprite[] sprLevelList;


    public float radius{ get { return rectTransform.sizeDelta.x; } set { rectTransform.sizeDelta = new Vector2(value, value); } }
    public Vector2 center { get { return rectTransform.anchoredPosition; }  set{rectTransform.anchoredPosition = value; } }

    public float lifetime = 5;
    public float currentLifeTime;
    public float usedTime { get { return lifetime - currentLifeTime; } }
    public UnityAction<JumpNode,bool, float,Vector2> onComplete;
    public UnityAction onNodeDestroy;

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

    public void SetNode(JumpNodeSkin skin)
    {
        SetNodeSprite(skin.circle,skin.triangle1,skin.triangle2);
        SetParticleSystemStartColor(par_1, skin.startColor1);
        SetParticleSystemStartColor(par_2, skin.startColor1, skin.startColor2);
        SetParticleSystemStartColor(par_3, skin.startColor1);
        SetParticleSystemStartColor(par_4, skin.startColor1);
    }

    void SetNodeSprite(Sprite circle, Sprite triangle1, Sprite triangle2)
    {
        img_circle.overrideSprite = circle;
        img_triangle1.overrideSprite = triangle1;
        img_triangle2.overrideSprite = triangle2;
    }

    void SetParticleSystemStartColor(ParticleSystem particle, Color color)
    {
        ParticleSystem.MainModule main = particle.main;
        main.startColor = color;
    }

    void SetParticleSystemStartColor(ParticleSystem particle, Color color1, Color color2)
    {
        ParticleSystem.MainModule main = particle.main;
        ParticleSystem.MinMaxGradient start = particle.main.startColor;
        start.colorMin = color2;
        start.colorMax = color1;
        main.startColor = start;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(interactable){
            InvokeComplete(true,true, eventData.position);
        }
    }

    public void ShowResult(ScoreType type)
    {
        img_level.overrideSprite = sprLevelList[((int)type)];
        img_level.enabled = true;
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

    IEnumerator WaitDestroy(float time){
        yield return new WaitForSeconds(time);
        if (onNodeDestroy != null)
            onNodeDestroy();
        Destroy(gameObject);
    }

    //IEnumerator WaitShowLevel(float time)
    //{
    //    LevelImage.gameObject.SetActive(true);
    //    yield return new WaitForSeconds(time);
    //    LevelImage.gameObject.SetActive(false);
    //}

}
