using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightIntensity : MonoBehaviour, IOutputModule {

	[SerializeField] private Light _light;

	public void SubscribeToInput (IInputModule input) {

		input.OnValueChange += UpdateLightIntensity;

	}

	void UpdateLightIntensity(float value) {

		_light.intensity = Mathf.Lerp(0.0f, 3.0f,value);

	}

}
