﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxColorG : MonoBehaviour, IOutputModule {

	public Board _board { get; set; }
	private Material _skybox;
	[SerializeField] private float _shadeFactor;

	void Start() {

		// Get the Skybox Material
		_skybox = RenderSettings.skybox;

	}

	public void SubscribeToInput (IInputModule input) {

		input.OnValueChange += UpdateSkyboxG;

	}

	public void UnsubscribeFromInput (IInputModule input) {

		input.OnValueChange -= UpdateSkyboxG;

	}

	void UpdateSkyboxG(float value) {

		Color currentColor2 = _skybox.GetColor ("_Color2");
		_skybox.SetColor("_Color2", new Color(currentColor2.r ,value, currentColor2.b));

		Color currentColor1 = _skybox.GetColor ("_Color1");
		_skybox.SetColor("_Color1", new Color((currentColor2.r-_shadeFactor), (value-_shadeFactor), (currentColor2.b-_shadeFactor)));

		RenderSettings.skybox = _skybox;

	}

}
