using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class UITouchLine : UIBaseView
{
    public UICircle circlePrefab;
    public UILine linePrefab;
    public Sprite spr_start;
    public Sprite spr_middle;
    public Sprite spr_end;
    public CanvasGroup canvasGroup;
    public float lifetime=5;
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
    public UnityAction<bool> onComplete;
    private Tween tween;

    // Use this for initialization
    void Start()
    {
        circlePrefab.SetActive(false);
        linePrefab.SetActive(false);
        Create();
    }

    private void Update()
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
        lifetime -= Time.deltaTime;
        if(lifetime<1 && tween==null){
            tween = canvasGroup.DOFade(0, 1);
        }else if(lifetime<0){
            tween = null;
            if(isTouch)
            {
                Debug.Log("Failure");
                if (onComplete != null)
                {
                    onComplete(false);
                }
            }
            Destroy(gameObject);
        }
    }

    void InitTouch(){
        isTouch = false;
        currentTouchCircleId = -1;
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
        if (isTouch)
        {
            if (circle.id - currentTouchCircleId == 1)
            {
                circle.img_circle.color = Color.red;
                currentTouchCircleId = circle.id;
                if (circle.id == circleCount - 1)
                {
                    InitTouch();
                    Debug.Log("Success");
                    if (onComplete != null)
                    {
                        onComplete(true);
                    }
                }
            }else{
                InitTouch();
                Debug.Log("Failure");
                if(onComplete!=null)
                {
                    onComplete(false);
                }
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
        circle.img_circle.color = Color.white;
    }
}
