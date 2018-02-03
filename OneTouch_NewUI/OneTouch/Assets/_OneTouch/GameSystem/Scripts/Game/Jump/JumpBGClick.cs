using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JumpBGClick : GameBGMiss, IPointerDownHandler {

    public Canvas canvas;
    public UnityAction onClickBackground;
    

    public void OnPointerDown(PointerEventData eventData)
    {
        ShowMiss();
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, eventData.position,canvas.worldCamera,out pos);
        pos.y += img_miss.rectTransform.rect.height;
        img_miss.rectTransform.anchoredPosition = pos;
        if (onClickBackground != null)
            onClickBackground();
    }


}
