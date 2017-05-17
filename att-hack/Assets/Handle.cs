using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handle : MonoBehaviour {

	public GameObject _transformToHandle;

	// Class to contain any handle-specific methods

	void Start () {
		
		// Subscribe to the Handle's move events
		this.GetComponent<DragObject>().OnMove += OnDrag;

	}

	void OnDrag (GameObject g) {

		_transformToHandle.transform.position = g.transform.position;

	}



}
