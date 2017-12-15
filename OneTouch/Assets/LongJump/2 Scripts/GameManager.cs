using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum GameState {
	menu,
	inGame,
	gameOver
}

public class GameManager : MonoBehaviour {

	public GameState currentGameState = GameState.menu;
	public static GameManager instance;
	public static int Count;

	//public Canvas menuCanvas;

	void Awake(){
		instance = this;
	}

	// Use this for initialization
	void Start() {
		
	}

	void Update(){
		
	}

	public void StartGame(){
		SceneManager.LoadScene ("LongJump");
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
