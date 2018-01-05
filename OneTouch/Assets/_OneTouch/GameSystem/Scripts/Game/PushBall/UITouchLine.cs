using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class UITouchLine : UIBaseView
{
    public bool interactable = true;
    public UICircle circlePrefab;
    public UILine linePrefab;
    public Sprite spr_start;
    public Sprite spr_middle;
    public Sprite spr_end;
    public CanvasGroup canvasGroup;
    public float lifetime = 5;
    public float currentLifeTime;
    public float circleRadius = 128;
    public float circlePadding = 0;
    public float minLineLength = 150;
    public float maxLineLength = 400;
    public float minAngle = -45;
    public float maxAngle = 45;
    [Range(2, 5)]
    public int circleCount = 3;
    public List<UICircle> circleList;
    public List<UILine> lineList;
    /// <summary>
    /// 真实半径
    /// </summary>
    /// <value>The real radius.</value>
    public float realRadius { get { return circleRadius + circlePadding; } }
    private bool isTouch;
    private int currentTouchCircleId = -1;
    /// <summary>
    /// 连线是否已经结束。 true：连线成功  false：连线失败
    /// </summary>
    public UnityAction<bool,float,Vector2> onComplete;
    public float usedTime { get { return lifetime - currentLifeTime + clickTime; } }
    private float clickTime=0;
    private Tween tween;

    // Use this for initialization
    void Start()
    {
        circlePrefab.SetActive(false);
        linePrefab.SetActive(false);
        Create();
        currentLifeTime = lifetime;
    }

    private void Update()
    {
        if (interactable)
        {
            if (isTouch)
            {
#if UNITY_EDITOR
                if (!Input.anyKey)
#elif UNITY_ANDROID || UNITY_IOS
                if(Input.touches.Length == 0)
#else
                if(!Input.anyKey)
#endif
                    InitTouch();
            }
            currentLifeTime -= Time.deltaTime;
            if (currentLifeTime < 1 && tween == null)
            {
                tween = canvasGroup.DOFade(0, 1);
            }
            else if (currentLifeTime < 0)
            {
                tween = null;
                //Debug.Log("Failure");
                InvokeComplete(false, circleList[0].rectTransform.anchoredPosition);
            }
        }
    }

    void InitTouch(){
        isTouch = false;
        currentTouchCircleId = -1;
        clickTime = 0;
    }

    public void Create(){
        if (circleList == null)
            circleList = new List<UICircle>();
        if (lineList == null)
            lineList = new List<UILine>();
        UICircle lastCircle = null;
        UILine lastLine = null;
        for (int i = 0; i < circleCount-1;i++)
        {
            lastCircle = CreateCircle(i,lastLine == null?Vector2.zero:lastLine.endPoint);
            circleList.Add(lastCircle);

            lastLine = CreateLine(i, lastCircle.center);
            lineList.Add(lastLine);
        }
        lastCircle = CreateCircle(circleCount - 1,lastLine.endPoint);
        circleList.Add(lastCircle);
    }

    UICircle CreateCircle(int index, Vector2 pos){
        UICircle circle = Instantiate(circlePrefab) as UICircle;
        circle.rectTransform.SetParent(rectTransform, false);
        circle.SetActive(true);
        circle.SetRadius(realRadius);
        circle.SetPosition(pos);
        circle.id = index;
        circle.name = string.Format("Circle_{0}",index);
        circle.onStartCircle = OnStartCircle;
        circle.onEnterCircle = OnEnterCircle;
        circle.onExitCircle = OnExitCircle;
        if (index == 0)
        {
            circle.SetSprite(spr_start);
        }
        else if (index == circleCount - 1)
        {
            circle.SetSprite(spr_end);
        }
        else
        {
            circle.SetSprite(spr_middle);
        }
        return circle;
    }

    UILine CreateLine(int index,Vector2 pos){
        UILine line = Instantiate(linePrefab) as UILine;
        line.rectTransform.SetParent(rectTransform, false);
        line.SetActive(true);
        line.id = index;
        line.name = string.Format("Line_{0}", index);
        line.SetPosition(pos);
        line.SetParameter(realRadius,Random.Range(minAngle,maxAngle),Random.Range(minLineLength,maxLineLength));
        return line;
    }

    /// <summary>
    /// 点击圆圈，开始连线
    /// </summary>
    /// <param name="circle">Circle.</param>
    /// <param name="time">Time.</param>
    void OnStartCircle(UICircle circle, float time)
    {
        //只有从点击第一个圆，才能开始连线
        isTouch = circle.id==0;
    }

    /// <summary>
    /// 进入圆圈事件
    /// </summary>
    /// <param name="circle">Circle.</param>
    /// <param name="time">Time.</param>
    void OnEnterCircle(UICircle circle, float time)
    {
        if (!interactable)
            return;
        if (isTouch)
        {
            if (circle.id - currentTouchCircleId == 1)
            {
                if (circle.id == 0)
                    clickTime = currentLifeTime;
                circle.img_circle.color = Color.red;
                currentTouchCircleId = circle.id;
                if (circle.id == circleCount - 1)
                {
                    InitTouch();
                    //Debug.Log("Success");
                    InvokeComplete(true, circle.rectTransform.anchoredPosition);
                }
            }else{
                InitTouch();
                //Debug.Log("Failure");
                InvokeComplete(false, circle.rectTransform.anchoredPosition);
            }
        }
    }

    /// <summary>
    /// 退出圆圈事件
    /// </summary>
    /// <param name="circle">Circle.</param>
    /// <param name="time">Time.</param>
    void OnExitCircle(UICircle circle, float time)
    {
        //if (!interactable)
            //return;
        circle.img_circle.color = Color.white;
    }

    void InvokeComplete(bool isSuccess,Vector2 pos)
    {
        interactable = false;
        if (onComplete != null)
            onComplete(isSuccess, usedTime, pos);
        //可改成延迟销毁
        Destroy(gameObject);
    }
}
