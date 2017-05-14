using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightIntensity : MonoBehaviour, IOutputModule {

	[SerializeField] private Light _light;

	public void SubscribeToInput (Knob input) {

		input.OnValueChange += UpdateLightIntensity;

	}

	void UpdateLightIntensity(float value) {

		_light.intensity = value;

	}

}
