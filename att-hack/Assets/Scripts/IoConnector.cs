using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IoConnector : MonoBehaviour {

	#region Singleton
	public static IoConnector _instance;
	#endregion

	public List<IoConnection> _connections;

	private GameObject _tempStartNode;
	private GameObject _tempEndNode;
	private GameObject _tempStartObject;									// use this to store the input temporarily before creating the IoConnection instance
	private GameObject _tempEndObject;										// use this to store the output temporarily before creating the IoConnection instance
	private IoLine _tempLine;
	private GameObject _tempLineObject;

	private GameObject _tempInputObject;
	private GameObject _tempOutputObject;

	private bool _startSelected;

	[Header("Connector Formatting")]
	[SerializeField] private float _lineWidth;
	[SerializeField] private Color _lineColor;
	public Material _lineMaterial;

	void Awake () {
		_instance = this;
		_startSelected = false;
	}

	void Start () {

		_connections = new List<IoConnection> ();

	}

	void Update () {

		// Temporary input module
		if (Input.GetMouseButtonDown (0)) {
			OnClick();
		}

	}


	// Click Handling - meat of logic is in OnSelect
	private void OnClick() {

		//create a ray cast and set it to the mouses cursor position in game
		float distance = 50.0f; // this might need to be tweaked
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit, distance)) {
			OnSelect (hit.transform.gameObject);
		} else {
			// if no hit
			if(_startSelected)
				DestroyLine ();
		}
	}


	private void OnSelect(GameObject g) {

		// is this a node?
		if (g.CompareTag ("Node")) {

			// If we haven't already selected an input
			if (!_startSelected) {
				SelectStart (g);
				_startSelected = true;
			} else {
				SelectEnd (g);
				_startSelected = false;
			}


		} else {

			// print ("NOT A NODE");
			if (_startSelected) {
				DestroyLine ();
			}

		}

	}


	public void SelectStart(GameObject g) {

		SelectionInteraction._instance.Play (g);

		_tempStartNode = g;
		_tempStartObject = g.transform.parent.gameObject;


		if (CheckValidStartConnection (_tempStartObject)) {

			_tempLineObject = new GameObject ();
			_tempLineObject.transform.SetParent (g.transform);
			IoLine line = _tempLineObject.AddComponent<IoLine> ();
			_tempLine = line;

			// Create a new GameObject to hold the line
			line.Init (_tempLineObject, _lineWidth, _lineColor, g);

		} else {

			// Debug.Log ("Not a valid input/output");
			DestroyLine ();

		}

	}

	public void SelectEnd(GameObject g) {

		SelectionInteraction._instance.Play (g);

		_tempEndNode = g;
		_tempEndObject = g.transform.parent.gameObject;

		// print ("SELECT END CALLED");

		_tempLine.EndLine (g);
		if (CheckValidEndConnection (_tempStartObject, _tempEndObject)) {

			// check which is which and create a new connection
			print("Valid connection");
			IoConnection newConnection = new IoConnection (_tempInputObject, _tempOutputObject, _tempLine);
			_connections.Add (newConnection);

		} else {
			print ("Invalid connection, try again");
			DestroyLine ();
		}

	}


	private bool CheckValidStartConnection (GameObject start) {

		// Is this a valid input or output node?
		if (start.GetComponent<IOutputModule> () != null) {
			print ("HAS AN IOUTPUT MODULE");
			_tempOutputObject = start;
			return true;
		} else if (start.GetComponent<IInputModule> () != null) { // TODO: Change this to a generic Input interface
			_tempInputObject = start;
			return true;
		} else {
			Debug.Log ("Not a valid input/output");
			return false;
		}

	}


	private bool CheckValidEndConnection(GameObject start, GameObject end) {

		// If we already have an input object
		if (_tempInputObject != null) {
			if (_tempEndObject.GetComponent<IOutputModule> () == null) {
				print ("Not an output object");
				return false;
			} else {
				_tempOutputObject = end;
				return true;
			}
		} else if (_tempOutputObject != null) {
			if (_tempEndObject.GetComponent<IInputModule> () == null) {
				print ("Not an input object");
				return false;
			} else {
				_tempInputObject = end;
				return true;
			}
		} else {
			return false;
		}

	}


	private void DestroyLine () {

		Destroy (_tempLineObject);
		DestroyTempVars ();
		_startSelected = false;

	}

	private void DestroyTempVars () {

		_tempStartNode = null;
		_tempStartObject = null;
		_tempLine = null;
		_tempLineObject = null;
		_tempEndNode = null;
		_tempEndObject = null;

	}


}
