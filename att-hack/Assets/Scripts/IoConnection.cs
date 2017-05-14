using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IoConnection {

	public GameObject _input;
	public GameObject _output;
	private IoLine _ioLine;

	public IoConnection (GameObject input, GameObject output, IoLine ioLine) {

		_input = input;
		_output = output;

		_ioLine = ioLine;

		Debug.Log (string.Format ("Input is {0} and output is {1}", _input, _output));

		Init ();

	}

	public void Init () {

		// Register the output for the input's event listeners
		// ## THIS IS THE CORE BIT OF LINKING CODE ##
		_output.GetComponent<IOutputModule>().SubscribeToInput(_input.GetComponent<Knob>());

		// Register for OnMove events from both of the GameObjects
		_input.GetComponent<DragObject>().OnMove += OnMove;
		_output.GetComponent<DragObject>().OnMove += OnMove;
		_input.GetComponent<Hover> ().OnMove += OnMove;
		_output.GetComponent<Hover> ().OnMove += OnMove;


	}

	// If either of the GameObjects move, make sure the connector lines move with them
	public void OnMove (GameObject g) {

		_ioLine.UpdateLinePositions ();

	}

}
