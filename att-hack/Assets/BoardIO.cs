using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardIO : MonoBehaviour {

	[Header("Parameters")]
	public Board _board;
	public Handle _handle;

	[Header("Input Modules")]
	#region InputModules#
	public GameObject _velocityPrefab;
	public GameObject _pitchPrefab;
	#endregion

	[Header("Output Modules")]
	#region OutputModules#
	public GameObject _particleSize;
	public GameObject _particleWeight;
	public GameObject _particleBounce;
	public GameObject _particleColorR;
	public GameObject _particleColorG;
	public GameObject _particleColorB;
	#endregion

	private List<GameObject> _inputModuleGameObjects;
	private List<GameObject> _outputModuleGameObjects;

	void Awake () {

		_inputModuleGameObjects = new List<GameObject> ();
		_inputModuleGameObjects.Add (_velocityPrefab);
		_inputModuleGameObjects.Add (_pitchPrefab);

		_outputModuleGameObjects = new List<GameObject> ();
		_outputModuleGameObjects.Add (_particleSize);
		_outputModuleGameObjects.Add (_particleWeight);
		_outputModuleGameObjects.Add (_particleBounce);
		_outputModuleGameObjects.Add (_particleColorR);
		_outputModuleGameObjects.Add (_particleColorG);
		_outputModuleGameObjects.Add (_particleColorB);

	}

	public void Init () {

		// Set the correct Board on the input modules
		foreach (GameObject i in _inputModuleGameObjects) {
			i.GetComponent<IInputModule> ()._board = _board;
			i.GetComponent<UiComponent> ()._handle = _handle;
		}

		// Set the correct Board on the output modules
		foreach (GameObject o in _outputModuleGameObjects) {
			o.GetComponent<IOutputModule> ()._board = _board;
			o.GetComponent<UiComponent> ()._handle = _handle;
		}

		// Set the Handle label
		foreach (Transform child in _handle.transform) {
			if (child.name == Labels.ch_label) {
				child.GetComponent<TextMesh> ().text = "CH" + _board._channel;
			}
		}

	}

}
