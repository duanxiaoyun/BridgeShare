using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class UICircle : GameBaseNode, IPointerDownHandler,IPointerEnterHandler,IPointerExitHandler
{

    public UnityAction<UICircle, float,Vector2> onEnterCircle,onExitCircle,onStartCircle;

	// Use this for initialization
	void Start () {
		
	}
    
    public void OnPointerDown(PointerEventData eventData)
    {

        if (!isActiveAndEnabled || !interactable)
            return;

        if (onStartCircle != null)
        {
            onStartCircle(this, Time.time, eventData.position);
        }
        OnPointerEnter(eventData);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!isActiveAndEnabled || !interactable)
            return;

        if(onEnterCircle!=null)
        {
            onEnterCircle(this, Time.time, eventData.position);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!isActiveAndEnabled || !interactable)
            return;

        if (onExitCircle != null)
        {
            onExitCircle(this, Time.time, eventData.position);
        }
    }
}
