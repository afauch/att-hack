using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IoLine : MonoBehaviour {

	public LineRenderer _lr;
	private float _width;
	private Color _color;
	public Material _material;

	private GameObject _lineObject;
	private Vector3 _prevPosition;

	private GameObject _start;
	private GameObject _end;

	public bool _isDrawing;

	// Custom Init pseudo-constructor
	public void Init(GameObject lineObject, float width, Color color, GameObject start) {

		// Create a new GameObject as a child of the NodeConnector
		_lineObject = lineObject;
		_lineObject.transform.localPosition = Vector3.zero;
		_lineObject.name = "line";
		_lr = _lineObject.AddComponent<LineRenderer> ();

		// Create a new instance of the Line Renderer and start drawing the line
		_start = start;

		_width = width;
		_color = color;

		// Apply a standard diffuse material
		_lr.material = IoConnector._instance._lineMaterial;

		_lr.startWidth = _width;
		_lr.endWidth = _width;
		_lr.startColor = _color;
		_lr.endColor = _color;

		_isDrawing = false;

		BeginLine (_start);
	

	}
		
	public void BeginLine(GameObject startPos) {

		print ("BEGINLINE CALLED");

		_lr.positionCount = 2;

		// TODO: Clean this up, make more generic
		_lr.SetPosition (0, _start.transform.position);

		_isDrawing = true;

	}

	public void EndLine(GameObject endPos) {

		_end = endPos;

		_lr.SetPosition (1, _end.transform.position);
		_isDrawing = false;
		
	}

	void Update () {

		// print ("UPDATE");

		if (_lr != null && _isDrawing) {
		
			print ("IS DRAWING");

			Vector3 mousePos = Input.mousePosition;
			mousePos.z = Camera.main.nearClipPlane;
			Vector3 mouseWorld = Camera.main.ScreenToWorldPoint (mousePos);
			_lr.SetPosition (1, mouseWorld);

		}


	}

	public void UpdateLinePositions () {

		_lr.SetPosition (0, _start.transform.position);
		_lr.SetPosition (1, _end.transform.position);

	}


}
