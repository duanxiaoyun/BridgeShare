using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBaseView : MonoBehaviour {
    public int id;
    private RectTransform m_RectTransform;
    public RectTransform rectTransform{ get { return m_RectTransform ?? (m_RectTransform = GetComponent<RectTransform>()); } }

    public bool activeSelf{ get { return gameObject.activeSelf; }}

    public bool activeInHierarchy{ get { return gameObject.activeInHierarchy; } }

    public void SetActive(bool value)
    {
        if(activeSelf!=value)
            gameObject.SetActive(value);
    }

    public void Show(){
        SetActive(true);
    }

    public void Hide(){
        SetActive(false);
    }
}
