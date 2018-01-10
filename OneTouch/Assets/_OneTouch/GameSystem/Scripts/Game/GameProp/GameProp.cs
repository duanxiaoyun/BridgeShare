using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class GameProp : UIBaseView {

    public GamePropType type;
    [SerializeField]
    private Button button;
    [SerializeField]
    private Image image;

    public float lifetime = 5;
    public float currentLifeTime;
    public UnityAction<GamePropType> onPickProp;


	// Use this for initialization
	void Start () {
        button.onClick.AddListener(PickProp);
        currentLifeTime = lifetime;
    }

    private void Update()
    {
        currentLifeTime -= Time.deltaTime;
        if (currentLifeTime < 0)
        {
            Destroy(gameObject);
        }
    }

    void PickProp() {
        if (onPickProp != null)
            onPickProp(type);
        Destroy(gameObject);
    }

    public void Set(GamePropType type, Sprite sprite) {
        this.type = type;
        SetSprite(sprite);
    }

    public void SetSprite(Sprite sprite) {
        image.overrideSprite = sprite;
        image.SetNativeSize();
    }
}
