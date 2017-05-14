using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IoConnection {

	public GameObject _input;
	public GameObject _output;

	public IoConnection (GameObject input, GameObject output) {

		_input = input;
		_output = output;

		Debug.Log (string.Format ("Input is {0} and output is {1}", _input, _output));

		Init ();

	}

	public void Init () {

		// Register the output for the input's event listeners
		_output.GetComponent<LightIntensity>().SubscribeToInput(_input.GetComponent<Knob>());

	}

}
