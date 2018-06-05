using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[Serializable]
public class NodeSkin
{
    public Sprite circle;
    public Sprite triangle1;
    public Sprite triangle2;
    public Color startColor1;
    public Color startColor2;
}

public class GameBaseNode : UIBaseView
{
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
    public Material mat_gray;

    public ScoreType scoreType { get; private set; }
    public Image img_level;
    public Sprite[] sprLevelList;


    public float radius { get { return rectTransform.sizeDelta.x * 0.5f; } set { rectTransform.sizeDelta = new Vector2(2*value, 2*value); } }
    public Vector2 center { get { return rectTransform.anchoredPosition; } set { rectTransform.anchoredPosition = value; } }
    
    public UnityAction onNodeDestroy;

    
    public void SetGrayEffect()
    {
        img_circle.material = mat_gray;
        img_triangle1.material = mat_gray;
        img_triangle2.material = mat_gray;
    }

    public void SetNormalEffect()
    {
        img_circle.material = null;
        img_triangle1.material = null;
        img_triangle2.material = null;
    }

    public void SetNode(NodeSkin skin)
    {
        SetNodeSprite(skin.circle, skin.triangle1, skin.triangle2);
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

    public void ShowResult(ScoreType type)
    {
        scoreType = type;
        img_level.overrideSprite = sprLevelList[((int)type)];
        img_level.enabled = true;
    }

    protected IEnumerator WaitDestroy(float time)
    {
        yield return new WaitForSeconds(time);
        if (onNodeDestroy != null)
            onNodeDestroy();
        Destroy(gameObject);
    }

    //protected IEnumerator WaitShowLevel(float time)
    //{
    //    LevelImage.gameObject.SetActive(true);
    //    yield return new WaitForSeconds(time);
    //    LevelImage.gameObject.SetActive(false);
    //}
}
