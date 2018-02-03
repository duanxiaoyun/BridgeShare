using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHP : MonoBehaviour {
    private int m_CurrentHP;
    public int currentHP { 
        get { return m_CurrentHP; } 
        private set
        {
            if(m_CurrentHP!=value) {
                int hp = value - m_CurrentHP;
                m_CurrentHP = value;
                if(onHPChanged!=null){
                    onHPChanged(hp);
                }
                CheckDead();
            }
        } 
    }
    public int maxHP;
    public bool isDead { get { return currentHP<=0; }}
    public UnityAction onPlayerDead;
    public UnityAction<int> onHPChanged;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetMaxHP(int hp)
    {
        maxHP = hp;
    }

    public void StartGame(){
        currentHP = maxHP;
    }

    public void AddHP(int hp){
        currentHP = Mathf.Clamp(currentHP + hp, 0, maxHP);
    }

    public void DelHP(int hp){
        currentHP = Mathf.Clamp(currentHP - hp, 0, maxHP);
    }

    void CheckDead(){
        if (isDead && onPlayerDead != null)
        {
            onPlayerDead();
        }
    }
}
