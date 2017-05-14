using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// I need this to be an interface of a generic
// Output class
public class LightIntensity : MonoBehaviour {

	// public Knob _draftInputKnob;
	[SerializeField] private Light _light;

	// TODO: this shouldn't be start, it should be ON CONNECT
	void Start() {

		// Subscribe to this knob's OnInputChange
		// _draftInputKnob.OnValueChange += UpdateLightIntensity;

	}

	public void SubscribeToInput (Knob input) {

		input.OnValueChange += UpdateLightIntensity;

	}


	void UpdateLightIntensity(float value) {

		_light.intensity = value;

	}

}
