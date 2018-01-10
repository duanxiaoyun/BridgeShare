using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GamePropController : MonoBehaviour {
    public RectTransform content;
    public GameProp prefab;
    public int maxCount = 5;
    public int currentCount = 0;
    public float nextTime = 0;

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
        GamePropType type = Random.Range(0, 100) > 80 ? GamePropType.Water : GamePropType.Bread;
        temp.Set(type, propSpriteList[(int)type]);
        temp.onPickProp = OnPickProp;
        currentCount++;
    }

    void OnPickProp(GamePropType type) {
        switch (type) {
            case GamePropType.Water:
                if (onPickWater != null) {
                    onPickWater(GameRule.GetWaterDoubleScoreTime());
                }
                break;
            case GamePropType.Bread:
                if (onPickBread != null)
                {
                    onPickBread(GameRule.GetBreadHPCount());
                }
                break;
        }
    }
}
