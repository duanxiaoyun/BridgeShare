using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using System.Collections;

public enum TouchLineStatus
{
    Normal,
    Line,
    PartComplete,
    SuccessComplete,
    OutComplete,
    FailureComplete
}
public class UITouchLine : UIBaseView
{
    public bool interactable = true;
    public UICircle circlePrefab;
    public UILine linePrefab;
    public NodeSkin skin_start;
    public NodeSkin skin_middle;
    public NodeSkin skin_end;
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
    public bool isTouch { get; private set; }
    private int currentTouchCircleId = -1;
    /// <summary>
    /// 连线状态。
    /// </summary>
    public UnityAction<TouchLineStatus, ScoreType, int> onComplete;
    public UnityAction<TouchLineStatus, UITouchLine,UICircle, Vector2> onStartClickPosition;
    public UnityAction onNodeDestroy;

    public float usedTime { get { return lifetime - currentLifeTime + clickTime; } }
    private float clickTime=0;
    private Tween tween;

    public TouchLineStatus lineStatus { get; private set; }
    public UICircle lastTouchCircle;
    public float leftSide=0;
    public ScoreType scoreType { get; private set; }
    float lastCirclePosX;


    // Use this for initialization
    void Start()
    {
        circlePrefab.SetActive(false);
        linePrefab.SetActive(false);
        Create();
        currentLifeTime = lifetime;
    }

    private Vector2 pos;
    public float speed;
    private void Update()
    {
        if (interactable)
        {
            if (isTouch)
            {
#if UNITY_EDITOR
                if (!Input.anyKey)
                {
#elif UNITY_ANDROID || UNITY_IOS
                if(Input.touches.Length == 0){
#else
                if(!Input.anyKey){
#endif
                    InitTouch();
                    if (lineStatus == TouchLineStatus.Line && lastTouchCircle != null)
                    {
                        lineStatus = TouchLineStatus.PartComplete;
                        InvokeComplete(lineStatus, lastTouchCircle.id);
                    }
                }
            }
            //currentLifeTime -= Time.deltaTime;
            //if (currentLifeTime < 1 && tween == null)
            //{
            //    tween = canvasGroup.DOFade(0, 1);
            //}
            //else if (currentLifeTime < 0)
            //{
            //    tween = null;
            //    //Debug.Log("Failure");
            //    lineStatus = TouchLineStatus.Failure;
            //    InvokeComplete(lineStatus, circleList[0].rectTransform.anchoredPosition, circleList[0].id);
            //}

            pos = rectTransform.anchoredPosition;
            pos.x -= Time.deltaTime * speed;
            rectTransform.anchoredPosition = pos;
            if (pos.x < leftSide - lastCirclePosX && lineStatus!= TouchLineStatus.OutComplete)
            {
                lineStatus = TouchLineStatus.OutComplete;
                InvokeComplete(lineStatus, 0);
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
        lastCirclePosX = lastCircle.center.x + lastCircle.radius;
        circleList.Add(lastCircle);
    }

    UICircle CreateCircle(int index, Vector2 pos){
        UICircle circle = Instantiate(circlePrefab) as UICircle;
        circle.rectTransform.SetParent(rectTransform, false);
        circle.SetActive(true);
        circle.radius = realRadius;
        circle.center = pos;
        circle.id = index;
        circle.name = string.Format("Circle_{0}",index);
        circle.onStartCircle = OnStartCircle;
        circle.onEnterCircle = OnEnterCircle;
        circle.onExitCircle = OnExitCircle;
        if (index == 0)
        {
            circle.SetNode(skin_start);
        }
        else if (index == circleCount - 1)
        {
            circle.SetNode(skin_end);
        }
        else
        {
            circle.SetNode(skin_middle);
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
    void OnStartCircle(UICircle circle, float time, Vector2 position)
    {
        //只有从点击第一个圆，才能开始连线
        isTouch = circle.id==0;
        lineStatus = isTouch ? TouchLineStatus.Line : TouchLineStatus.FailureComplete;
        if (onStartClickPosition != null)
        {
            onStartClickPosition(lineStatus,this, circle, position);
        }
        if (!isTouch)
        {
            InvokeComplete(lineStatus, 0);
        }
        

        //Debug.Log("OnStartCircle:" + circle.name);
    }

    /// <summary>
    /// 进入圆圈事件
    /// </summary>
    /// <param name="circle">Circle.</param>
    /// <param name="time">Time.</param>
    void OnEnterCircle(UICircle circle, float time, Vector2 position)
    {
        //Debug.Log("OnEnterCircle:" + circle.name);
        if (!interactable)
            return;
        if (isTouch)
        {
            lastTouchCircle = circle;
            circle.SetGrayEffect();
            if (circle.id - currentTouchCircleId == 1)
            {
                if (circle.id == 0)
                {
                    clickTime = currentLifeTime;
                }
                currentTouchCircleId = circle.id;
                if (circle.id == circleCount - 1)
                {
                    InitTouch();
                    //Debug.Log("Success");
                    lineStatus = TouchLineStatus.SuccessComplete;
                    InvokeComplete(lineStatus, circle.id);
                }
                else {
                    lineStatus = TouchLineStatus.Line;
                    //InvokeComplete(lineStatus, circle.id);
                }
            }
            else{
                InitTouch();
                //Debug.Log("Failure");
                lineStatus = TouchLineStatus.PartComplete;
                InvokeComplete(lineStatus, circle.id);
            }
        }
    }

    /// <summary>
    /// 退出圆圈事件
    /// </summary>
    /// <param name="circle">Circle.</param>
    /// <param name="time">Time.</param>
    void OnExitCircle(UICircle circle, float time, Vector2 position)
    {
        //if (!interactable)
            //return;
        //circle.SetNormalEffect();

        //Debug.Log("OnExitCircle:" + circle.name);
    }

    public void SetScoreType(ScoreType type)
    {
        scoreType = type;
    }

    void InvokeComplete(TouchLineStatus status,int index)
    {
        interactable = (status == TouchLineStatus.Normal || status == TouchLineStatus.Line);
        if (onComplete != null)
            onComplete(status, scoreType, index);
        if (!interactable)
        {
            StartCoroutine(WaitDestroy(0.4f));
        }
    }

    protected IEnumerator WaitDestroy(float time)
    {
        yield return new WaitForSeconds(time);
        if (onNodeDestroy != null)
            onNodeDestroy();
        Destroy(gameObject);
    }
}
