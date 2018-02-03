using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GamePropController : MonoBehaviour {
    public RectTransform content;
    public GameProp prefab;
    public int maxCount = 5;
    public int currentCount = 0;
    public float nextTime = 0;

    public Image hp_plus;
    public Image score_times;

    public List<Sprite> propSpriteList;

    public UnityAction<float> onPickWater;
    public UnityAction<int> onPickBread;

    // Use this for initialization
    void Start () {
        nextTime = Random.Range(3, 8);
    }

    /// <summary>
    /// 在游戏进行中的时候，在Update里面调用
    /// </summary>
    public void UpdateCreate()
    {
        nextTime -= Time.deltaTime;
        if (nextTime < 0)
        {
            if (currentCount < maxCount)
            {
                Create();
                nextTime = Random.Range(5, 8);
            }
        }
    }

    void Create() {
        Vector2 pos = content.rect.size * 0.5f;
        pos.x -= 200;
        pos.x = Random.Range(-pos.x, pos.x);
        pos.y -= 400;
        pos.y = Random.Range(-pos.y, pos.y);
        GameProp temp = Instantiate(prefab) as GameProp;
        temp.rectTransform.SetParent(content, false);
        temp.rectTransform.anchoredPosition = pos;
        //빵과 물 생성 비율
        GamePropType type = Random.Range(0, 100) > 50 ? GamePropType.Water : GamePropType.Bread;
        temp.Set(type, propSpriteList[(int)type]);
        temp.onPickProp = OnPickProp;
        currentCount++;
    }

    void OnPickProp(GamePropType type) {
        switch (type) {
            case GamePropType.Water:
                if (onPickWater != null) {
                    //score_times.gameObject.SetActive(true);
                    StartCoroutine(WaitSomeSeconds(3.0f, score_times));
                    //score_times.gameObject.SetActive(false);
                    onPickWater(GameRule.GetWaterDoubleScoreTime());
                }
                break;
            case GamePropType.Bread:
                if (onPickBread != null)
                {
                    //hp_plus.gameObject.SetActive(true);
                    StartCoroutine(WaitSomeSeconds(3.0f,hp_plus));
                    //hp_plus.gameObject.SetActive(false);
                    onPickBread(GameRule.GetBreadHPCount());
                }
                break;
        }
    }

    IEnumerator WaitSomeSeconds(float time,Image image)
    {
        image.gameObject.SetActive(true);
        yield return new WaitForSeconds(time);
        image.gameObject.SetActive(false);
    }
}
