using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILine : UIBaseView {
    public float radius;
    public float angle;
    public float length;
    public Vector2 endPoint { get; private set; }
    public Image img_line;

	// Use this for initialization
	void Start () {
        UpdateGraphs();
	}
	
	// Update is called once per frame
	void Update () {
        //if (!Mathf.Approximately(angle, rectTransform.eulerAngles.z) 
        //    || !Mathf.Approximately(length,img_line.rectTransform.sizeDelta.x) 
        //    || !Mathf.Approximately(radius,rectTransform.sizeDelta.x))
        //{
        //    UpdateGraphs();
        //}
	}

    public void UpdateGraphs(){
        img_line.rectTransform.sizeDelta = new Vector2(length, img_line.rectTransform.sizeDelta.y);
        rectTransform.sizeDelta = new Vector2(radius,rectTransform.sizeDelta.y);
        rectTransform.eulerAngles = new Vector3(0, 0, angle);
    }

    public Vector2 GetEndPosition()
    {
        float r = radius * 2 + length;
        float a = angle * Mathf.Deg2Rad; //Mathf.Deg2Rad:度到弧度的转化常量
        Vector2 end = rectTransform.anchoredPosition;
        end.x = end.x + r * Mathf.Cos(a);
        end.y = end.y + r * Mathf.Sin(a);
        return end;
    }

    public void SetPosition(Vector2 pos)
    {
        rectTransform.anchoredPosition = pos;
    }

    public Vector2 SetParameter(float radius,float angle,float length)
    {
        this.radius = radius;
        this.angle = angle;
        this.length = length;
        endPoint = GetEndPosition();
        UpdateGraphs();
        return endPoint;
    }
}
