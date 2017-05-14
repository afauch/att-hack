using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IoConnector : MonoBehaviour {

	#region Singleton
	public static IoConnector _instance;
	#endregion

	public TextMesh _labelI;
	public TextMesh _labelO;

	public List<IoConnection> _connections;

	private GameObject _tempInputNode;
	private GameObject _tempOutputNode;
	private GameObject _tempInputObject;										// use this to store the input temporarily before creating the IoConnection instance
	private GameObject _tempOutputObject;										// use this to store the output temporarily before creating the IoConnection instance
	private IoLine _tempLine;
	private GameObject _tempLineObject;


	private bool _inputSelected;

	[Header("Connector Formatting")]
	[SerializeField] private float _lineWidth;
	[SerializeField] private Color _lineColor;

	void Awake () {
		_instance = this;
		_inputSelected = false;
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

		SelectionInteraction._instance.Play ();

		//create a ray cast and set it to the mouses cursor position in game
		float distance = 50.0f; // this might need to be tweaked
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit, distance)) {
			OnSelect (hit.transform.gameObject);
		} else {
			// if no hit
			if(_inputSelected)
				DestroyLine ();
		}
	}


	private void OnSelect(GameObject g) {

		// is this a node?
		if (g.CompareTag ("Node")) {

			// If we haven't already selected an input
			if (!_inputSelected) {
				SelectInput (g);
				_inputSelected = true;
			} else {
				SelectOutput (g);
				_inputSelected = false;
			}


		} else {

			print ("NOT A NODE");
			DestroyLine ();

		}

	}


	public void SelectInput(GameObject g) {

		print ("SELECT INPUT CALLED");

		_tempInputNode = g;
		_tempInputObject = g.transform.parent.gameObject;

		_labelI.text = g.name;

		_tempLineObject = new GameObject ();
		_tempLineObject.transform.SetParent (g.transform);
		IoLine line = _tempLineObject.AddComponent<IoLine> ();
		_tempLine = line;

		// Create a new GameObject
		line.Init(_tempLineObject, _lineWidth, _lineColor, g);

		// Assign for realtime management


	}

	public void SelectOutput(GameObject g) {

		_tempOutputNode = g;
		_tempOutputObject = g.transform.parent.gameObject;

		print ("SELECT OUTPUT CALLED");

		_labelO.text = g.name;
		_tempLine.EndLine (g);

		// Create a new connection Instance and add it to the list
		Debug.Log(string.Format("_tempInputObject is {0} and _tempOutputObject is {1}", _tempInputObject, _tempOutputObject));
		IoConnection newConnection = new IoConnection(_tempInputObject, _tempOutputObject);
		_connections.Add (newConnection);

	}

	private void DestroyLine () {

		Destroy (_tempLineObject);
		DestroyTempVars ();
		_inputSelected = false;

	}

	private void DestroyTempVars () {

		_tempInputNode = null;
		_tempInputObject = null;
		_tempLine = null;
		_tempLineObject = null;
		_tempOutputNode = null;
		_tempOutputObject = null;

	}


}
