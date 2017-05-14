﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxColorR : MonoBehaviour, IOutputModule {

	private Material _skybox;
	[SerializeField] private float _shadeFactor;

	void Start() {

		// Get the Skybox Material
		_skybox = RenderSettings.skybox;

	}

	public void SubscribeToInput (Knob input) {

		input.OnValueChange += UpdateSkyboxR;

	}

	void UpdateSkyboxR(float value) {

		Color currentColor2 = _skybox.GetColor ("_Color2");
		_skybox.SetColor("_Color2", new Color(value, currentColor2.g, currentColor2.b));

		Color currentColor1 = _skybox.GetColor ("_Color1");
		_skybox.SetColor("_Color1", new Color((value-_shadeFactor), (currentColor2.g-_shadeFactor), (currentColor2.b-_shadeFactor)));

		RenderSettings.skybox = _skybox;

	}

}