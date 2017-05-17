using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A simple hover effect to give the illusion of the chessboard floating in space.
/// </summary>
public class Hover : MonoBehaviour {

	float _y0;
	public float _amplitude;
	public float _speed;
	private float _offset;

	private Vector3 _currentPos;

	private bool _isBeingDragged;

	// Keep the IoLines updated
	public delegate void Moved (GameObject g);
	public event Moved OnMove;

	void Start () {

		_offset = Random.Range(0.0f,1.0f);
		_y0 = transform.position.y;

		InitDragSubscriptions ();

		_isBeingDragged = false;

	}

	void Update () {

		if (!_isBeingDragged) {

			_currentPos = transform.position;
			_currentPos = new Vector3 (_currentPos.x, _y0 + _amplitude * Mathf.Sin (_speed * (Time.time + _offset)), _currentPos.z);
			transform.position = _currentPos;

			// Publish the event
			if (OnMove != null) {
				OnMove (this.gameObject);
			}

		} else {

			_y0 = transform.position.y;

		}

		if (Input.GetMouseButtonUp (0)) {
			_isBeingDragged = false;
		}

	}

	void InitDragSubscriptions () {

		// This subscription means we'll turn off hovering if this gameobject is being dragged
		this.gameObject.GetComponent<DragObject>().OnMove += OnDrag;

		// This subscription means we'll turn off hovering if a parent object is being dragged
		var uiComponent = this.gameObject.GetComponent<UiComponent>();

		if (uiComponent != null && uiComponent._handle != null) {
			// Subscribe to the handle's OnMove
			uiComponent._handle.GetComponent<DragObject>().OnMove += OnDrag;

		}


	}

	void OnDrag (GameObject g) {

		_isBeingDragged = true;

	}

}
