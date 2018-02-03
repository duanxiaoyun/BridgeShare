using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Push : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
    public Sprite pushOn;
    public Sprite pushOff;    
    
    public void OnPointerDown(PointerEventData eventData)
    {
        gameObject.GetComponent<Image>().sprite = pushOff;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        gameObject.GetComponent<Image>().sprite = pushOn;
    }
    
    
}

