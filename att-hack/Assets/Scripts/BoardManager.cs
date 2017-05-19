using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiJack;

public class BoardManager : MonoBehaviour {

	public static BoardManager _instance;

	public List<Board> _boards;
	[HideInInspector] public int _boardCount;
	public Format _defaultFormat;
	public float _defaultSpacing;
	public GameObject _defaultHandle;
	public GameObject _paramsRoot;
	public float _defaultYHeight;

	public GameObject _defaultParticlePrefab;
	public Material _defaultParticleMaterial;



	void Awake () {

		_instance = this;

	}

	void Start () {

		_boards = new List<Board>();
		_boardCount = _boards.Count;

	}


	public void AddBoard(int midiChannelInt) {

		// Instantiate a new Board as a child of this GameObject
		GameObject newBoardGameObject = new GameObject();
		newBoardGameObject.transform.SetParent (this.transform);
		newBoardGameObject.transform.position = new Vector3(0.0f, _defaultYHeight, 0.0f);
		newBoardGameObject.name = "b" + _boardCount;

		// Add a Board component
		Board newBoard = newBoardGameObject.AddComponent<Board>();
		_boardCount += 1;
		newBoard._boardId = _boardCount; // Assign it the current Board Count index
		newBoard._channel = midiChannelInt;
		newBoard._format = _defaultFormat;
		newBoard._spacing = _defaultSpacing;
		newBoard._particlePrefab = _defaultParticlePrefab;
		newBoard._particleMaterial = _defaultParticleMaterial;

		// Add a Root Component
		AddRoot(newBoard);

		// Add Handle Prefab
		AddHandle(newBoard);

		// Add the BoardIO Controls, and link them to this Board
		BoardIOManager._instance.AddBoardIO(newBoard);

		// Initialize Board
		newBoard.Init();

	}


	public void DestroyBoard (Board board) {

		print ("DestroyBoard called on this board: " + board.gameObject.name);

		// Destroy all the notes
		foreach (Note n in board._notes) {
			n.DestroyNote ();
			GameObject.Destroy (n.gameObject);
		}

		// Destroy the BoardIOs and unsubscribe from all events
		BoardIO thisBoardIo = BoardIOManager._instance._boardIoDictionary[board];
		print ("thisBoardIo is: " + thisBoardIo.gameObject.name);
		BoardIOManager._instance.DestroyBoardIO (thisBoardIo);
		print ("thisBoardIo is now: " + thisBoardIo.gameObject.name);
		BoardIOManager._instance._boardIoDictionary.Remove (board);
		print ("root about to destroy is : " + board._root.gameObject.name);
		GameObject.Destroy (board._root);
		print ("handle about to destroy is : " + board._handle.gameObject.name);
		GameObject.Destroy (board._handle.gameObject);
		print ("boarda about about to destroy is : " + board.gameObject.name);
		GameObject.Destroy (board.gameObject);

	}



	private void AddRoot(Board board) {

		GameObject newRoot = new GameObject ();
		newRoot.transform.SetParent (board.gameObject.transform);
		newRoot.transform.position = board.gameObject.transform.position;
		newRoot.gameObject.name = "Root";

		board._root = newRoot;

	}

	private void AddHandle(Board board) {

		GameObject newHandleGameObject = GameObject.Instantiate (_defaultHandle, board.gameObject.transform.position, _defaultHandle.transform.rotation, board.transform);
		Handle newHandle = newHandleGameObject.GetComponent<Handle> ();
		newHandle._isBoardHandle = true;
		newHandle._transformToHandle = board.gameObject;

		// Assign the label for the board
		foreach(Transform child in newHandle.transform)
		{
			if (child.gameObject.name == Labels.ch_label) {
				child.gameObject.GetComponent<TextMesh> ().text = "CH" + board._channel;
			}
		}

		board._handle = newHandle;

	}

}
