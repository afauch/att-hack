﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxColorB : MonoBehaviour, IOutputModule {

	// Just implement for the interface - better way of doing this?
	public Board _board { get; set; }

	private Material _skybox;
	[SerializeField] private float _shadeFactor;

	void Start() {

		// Get the Skybox Material
		_skybox = RenderSettings.skybox;

	}

	public void SubscribeToInput (IInputModule input) {

		input.OnValueChange += UpdateSkyboxB;

	}

	public void UnsubscribeFromInput (IInputModule input) {

		input.OnValueChange -= UpdateSkyboxB;


	}

	void UpdateSkyboxB(float value) {

		Color currentColor2 = _skybox.GetColor ("_Color2");
		_skybox.SetColor("_Color2", new Color(currentColor2.r, currentColor2.g, value));

		Color currentColor1 = _skybox.GetColor ("_Color1");
		_skybox.SetColor("_Color1", new Color((currentColor2.r-_shadeFactor), (currentColor2.g-_shadeFactor), (value-_shadeFactor)));

		RenderSettings.skybox = _skybox;

	}

}
