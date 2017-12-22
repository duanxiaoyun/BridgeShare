using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public enum GameState {
	menu,
	inGame,
	gameOver
}

public class GameManager : MonoBehaviour {
	public GameObject dailyWanning;
//	public GameState currentGameState = GameState.menu;
	public static GameManager instance;


	//public Canvas menuCanvas;

	void Awake(){
		instance = this;
	}

	// Use this for initialization
	void Start() {
		dailyWanning.SetActive (false);
	}

	void Update(){
		
	}

	/*public void RetryGame(){
		nowTime = System.DateTime.Now;
		longjump_limit = preTime - nowTime;

		if (longjump_limit.TotalMinutes > 1) {
			Count = 0;
		}
		if (GameManager.Count >= 3) {
			dailyWanning.SetActive (true);
		} else {
			SceneManager.LoadScene ("FarJump");
		}
	}*/
	public void EndGame(){
		//SceneManager.LoadScene ("Main");
	}
	// Update is called once per frame
	/*public void StartGame() {
		PlayerController.instance.StartGame ();
		SetGameState (GameState.inGame);
	}

	public void GameOver() {
		SetGameState (GameState.gameOver);
	}

	public void BackToMenu(){
		SetGameState (GameState.menu);
	}

	void SetGameState (GameState newGameState){

		if (newGameState == GameState.menu) {
			menuCanvas.enabled = true;
		} else if (newGameState == GameState.inGame) {
			menuCanvas.enabled = false;
		} else if (newGameState == GameState.gameOver) {
			menuCanvas.enabled = false;
		}

		currentGameState = newGameState;
	}*/



}
