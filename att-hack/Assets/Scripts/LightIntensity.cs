using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightIntensity : MonoBehaviour {

	public Knob _draftInputKnob;
	[SerializeField] private Light _light;

	// TODO: this shouldn't be start, it should be ON CONNECT
	void Start() {

		// Subscribe to this knob's OnInputChange
		_draftInputKnob.OnValueChange += UpdateLightIntensity;

	}


	void UpdateLightIntensity(float value) {

		_light.intensity = value;

	}

}
