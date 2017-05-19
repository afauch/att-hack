using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handle : MonoBehaviour {

	public GameObject _transformToHandle;
	public bool _isBoardHandle;

	void Awake () {

		_isBoardHandle = false;

	}

	void Start () {
		
		// Subscribe to the Handle's move events
		this.GetComponent<DragObject>().OnMove += OnDrag;

	}

	void OnDrag (GameObject g) {

		_transformToHandle.transform.position = g.transform.position;

	}

	void Update () {

		// Temporary input module
		if (Input.GetMouseButtonDown (0)) {

			if (Input.GetKey (KeyCode.LeftAlt) || Input.GetKey (KeyCode.RightAlt)) { 
				OnAltClick ();
			}
		}
				
	}

	// Alt click removes node connections
	private void OnAltClick() {

		float distance = 50.0f; // this might need to be tweaked
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit, distance)) {
			if (hit.collider.gameObject == this.gameObject && _isBoardHandle) {
				SelectionInteraction._instance.Play (hit.transform.gameObject);
				DestroyBoard();
			}
		}

	}

	private void DestroyBoard() {

		BoardManager._instance.DestroyBoard (this._transformToHandle.GetComponent<Board> ());
		// GameObject.Destroy (this.gameObject);

	}


}
