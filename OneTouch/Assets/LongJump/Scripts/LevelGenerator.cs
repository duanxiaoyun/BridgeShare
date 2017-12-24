using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

	public static LevelGenerator instance;
	//앞으로 복사해서 사용할 모든 레벨 조각의 청사진
	public List<LevelPiece> levelPrefabs = new List<LevelPiece>();
	// 맨 처음 레벨 조각의 시작 위치
	public Transform levelStartPoint;
	// 현재 레벨 안에 있는 모든 레벨조각
	public List<LevelPiece> pieces = new List<LevelPiece>();

	void Awake(){
		instance = this;
	}
	void Start(){
		GenerateInitialPieces ();
	}
	public void GenerateInitialPieces(){
		for(int i=0; i<2; i++){
			AddPiece();
		}
	}
	public void AddPiece(){
		// 난수를 선택한다.
		int randomIndex = Random.Range (0, levelPrefabs.Count);

		// levelPrefabs에서 임의의 레벨 조각의 복사본을 인스턴스화해서
		// piece 변수에 저장한다
		LevelPiece piece = (LevelPiece)Instantiate (levelPrefabs [randomIndex]);
		piece.transform.SetParent (this.transform, false);

		Vector3 spawnPosition = Vector3.zero;

		if (pieces.Count == 0) {
			spawnPosition = levelStartPoint.position;
		} else {
			spawnPosition = pieces[pieces.Count-1].exitPoint.position;
		}

		piece.transform.position = spawnPosition;
		pieces.Add(piece);
	}
	public void RemoveOldstPiece(){

		LevelPiece oldestPiece = pieces [0];

		pieces.Remove (oldestPiece);
		Destroy (oldestPiece.gameObject);
	}
}
