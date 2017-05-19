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
		GameObject newBoardIoGameObject = GameObject.Instantiate(_boardIoPrefab, _boardIoPrefab.transform.position, Quaternion.identity, _boardIoRoot.transform);
		BoardIO newBoardIo = newBoardIoGameObject.GetComponent<BoardIO> ();
		newBoardIo._board = board;
		newBoardIo.Init ();

		_boardIoDictionary.Add (board, newBoardIo);

	}


	public void DestroyBoardIO (BoardIO boardIo) {

		// Destroy all the outputs
		foreach (GameObject o in boardIo._outputModuleGameObjects) {
			// Unsubscribe from all inputs
			foreach (GameObject i in boardIo._inputModuleGameObjects) {
				o.GetComponent<IOutputModule> ().UnsubscribeFromInput(i.GetComponent<IInputModule>());

			}
			GameObject.Destroy (o);
		}

		// Destroy all the inputs
		foreach (GameObject i in boardIo._inputModuleGameObjects) {
			i.GetComponent<IInputModule> ().DestroyInput ();
			GameObject.Destroy (i);
		}


		// Once all inputs and outputs are unsubscribed and destroyed, destroy the BoardIo itself
		GameObject.Destroy(boardIo._handle.gameObject);
		GameObject.Destroy(boardIo.gameObject);


	}

}
