using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Choice : MonoBehaviour {

	Animator animator;
	public RuntimeAnimatorController boy;
	public RuntimeAnimatorController girl;

	public int character_ID;


	// Use this for initialization
	void Awake(){
        
        if (GameArchive.user.sex == Sex.Boy)
        {
            character_ID = 1;
        }
        else if (GameArchive.user.sex == Sex.Girl)
        {
            character_ID = 0;
        }

    }

	void Start () {
		
		animator = this.transform.gameObject.GetComponent<Animator> ();

		if( character_ID == 0){
			animator.runtimeAnimatorController = girl;

		}else if(character_ID == 1){
			animator.runtimeAnimatorController = boy;
		}


	}
	
	// Update is called once per frame
	void Update () {
		

	}
}
