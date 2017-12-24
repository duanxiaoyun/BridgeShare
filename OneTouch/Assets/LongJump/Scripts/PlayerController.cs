using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class PlayerController : MonoBehaviour {

	public static PlayerController instance;
	// Slider 값 변수
	public Slider sliderBar;
	//타이머 UI Text
	//public Text counterText;
	//타이머 변수형태 변환을 위한 변수
	public float seconds;

	//점프하는 힘
	public float jumpForce;
	//뛰는 힘
	public float runningSpeed;
	//애니메이션 매개
	public Animator animator;

	//RigidBody2D 매개
	private Rigidbody2D rigidBody;
	//출발 지점 값(이동거리 계산), 
	private Vector3 startingPosition;
	//도착 지점 값(이동거리 계산)
	private Vector3 target;

	// 타이머 변수
	public float timer;
	// 점프 여부 판단
	private bool isJump = false;

	//현재 스코어
	public float nowScore = 0;
	public float topScore;
	public GameObject scoreTable;
	public GameObject playTable;
	public GameObject startTable;

	private Vector3 nowPos;
	private Vector3 prePos;
	private float down;
	private bool isEnd;

	private int count;

	public DateTime preTime;

	void Awake(){
		rigidBody = GetComponent<Rigidbody2D> ();
		//counterText = GetComponent<Text>() as Text;
		instance = this;
		startingPosition = this.transform.position;

		//터치 시간 10초 설정
		timer = 33.2f;
	}
	void Start(){
		topScore = UIManager.topScore;
		scoreTable.SetActive (false);
		playTable.SetActive (false);
		startTable.SetActive (true);
		prePos = new Vector3 (transform.position.x, transform.position.y, transform.position.z);

		jumpForce = 2000.0f;
		runningSpeed = 2000.0f;

		isEnd = false;

	}
	/*public void StartGame(){
		animator.SetBool ("isAlive", true);
		this.transform.position = startingPosition;
	}*/
	// Update is called once per frame
	void Update () {
		//Debug.Log (GameManager.Count);
		sliderBar.value = runningSpeed;
		seconds = (int)timer+1;
		//counterText.text = seconds.ToString("00");
		Minor ();
		timer -= Time.deltaTime;

		if(timer < 0.4f && timer > 0.0f){
			animator.SetBool("isReady", true);
		}
		if (timer >= 0 && timer <= 30) {
			
			startTable.SetActive (false);
			playTable.SetActive (true);

		} else if (timer < 0 && isJump == false) {
			playTable.SetActive (false);
			//GameManager.instance.menuCanvas.enabled = false;
			animator.SetBool ("isJump", true);
			rigidBody.AddForce (Vector2.up * jumpForce, ForceMode2D.Impulse);
			rigidBody.AddForce (Vector2.right * runningSpeed, ForceMode2D.Impulse);
			isJump = true;

			//rigidBody.velocity = new Vector2 (runningSpeed, rigidBody.velocity.y);
		}
		if (IsGrounded ()) {
			animator.SetBool ("isGround", true);
			Destroy (rigidBody);
			//runningSpeed = 0.0f;
			target = this.transform.position;
			this.transform.position = target;
			Score ();

			StartCoroutine (Wait ());
		}
			

	}
	void LateUpdate(){
		animator.SetBool ("isTouch", false);
		nowPos = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		down = nowPos.y - prePos.y;
		if (down < 0) {
			if (Physics2D.Raycast (this.transform.position, Vector2.down, 510.0f, groundLayer.value)) {
				animator.SetBool ("isGround", true);
			}

		}
		prePos = nowPos;

	}

	// 터치 시 점프 힘 추가
	public void Jump(){
		animator.SetBool ("isTouch", true);
		jumpForce += 50.0f;
		runningSpeed += 50.0f;
	}

	// 게이지 구간 별 줄어듦
	public void Minor(){
		
		if (runningSpeed > 2000.0f && runningSpeed < 4000.0f) {
			jumpForce -= 1.0f;
			runningSpeed -= 1.0f;

		} else if (runningSpeed > 4000.0f && runningSpeed < 7000.0f) {
			jumpForce -= 3.0f;
			runningSpeed -= 3.0f;

		} else if (runningSpeed > 7000.0f && runningSpeed < 8000.0f) {
			jumpForce -= 5.0f;
			runningSpeed -= 5.0f;

		} else if (runningSpeed > 10000.0f) {
			runningSpeed = 10000.0f;
		}
	}

	//이동한 거리만큼 계산
	public void Score(){
		nowScore = (target.x - startingPosition.x)/300;
		if(UIManager.topScore < nowScore){
			UIManager.topScore = nowScore;
		}
	}

	public void Reward(){
	}


	//Ground 판별을 위한 layer값 저장 변수
	public LayerMask groundLayer;


	// 캐릭터 기준 아래 땅 판별 True or False
	bool IsGrounded(){

		if(Physics2D.Raycast(this.transform.position, Vector2.down, 255.0f, groundLayer.value)){
			return true;
		}
		else {
			return false;
		}
	}
	// 착지후 기다림 및 기록 측정
	IEnumerator Wait(){
		if (isEnd == false) {
			isEnd = true;

			/*count = PlayerPrefs.GetInt ("FarJump_limit");
			count += 1;
			PlayerPrefs.SetInt ("FarJump_limit", count);

			if (count == 3) {
				preTime = System.DateTime.Now;

			}*/

			yield return new WaitForSeconds (2);
			scoreTable.SetActive (true);
		}
	}

}
