using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class UICircle : UIBaseView,IPointerDownHandler,IPointerEnterHandler,IPointerExitHandler
{
    public Image img_circle;
    public float radius;
    public Vector2 center {
        get{
            return rectTransform.anchoredPosition;
        }
        set {
            rectTransform.anchoredPosition = value;
        }
    }

    public UnityAction<UICircle, float> onEnterCircle,onExitCircle,onStartCircle;

	// Use this for initialization
	void Start () {
		
	}

    public void SetSprite(Sprite sprite){
        img_circle.overrideSprite = sprite;
    }

    public void SetRadius(float r){
        radius = r;
        rectTransform.sizeDelta = new Vector2(2 * radius, 2 * radius);
    }

    public void SetPosition(Vector2 pos){
        center = pos;
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        if (!isActiveAndEnabled)
            return;

        if (onStartCircle != null)
        {
            onStartCircle(this, Time.time);
        }
        OnPointerEnter(eventData);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!isActiveAndEnabled)
            return;

        if(onEnterCircle!=null)
        {
            onEnterCircle(this, Time.time);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!isActiveAndEnabled)
            return;

        if (onExitCircle != null)
        {
            onExitCircle(this, Time.time);
        }
    }
}
