using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardIOManager : MonoBehaviour {

	public static BoardIOManager _instance;

	public Dictionary<Board, BoardIO> _boardIoDictionary;

	public List<BoardIO> _boardIos;
	public GameObject _boardIoRoot;
	public GameObject _boardIoPrefab;

	void Awake () {

		_instance = this;
		_boardIoDictionary = new Dictionary<Board, BoardIO> (); 

	}

	public void AddBoardIO(Board board) {

		// Instantiate the prefab
		GameObject newBoardIoGameObject = GameObject.Instantiate(_boardIoPrefab, _boardIoRoot.transform.position, Quaternion.identity, _boardIoRoot.transform);
		BoardIO newBoardIo = newBoardIoGameObject.GetComponent<BoardIO> ();
		newBoardIo._board = board;
		newBoardIo.Init ();

		_boardIoDictionary.Add (board, newBoardIo);

	}

}
