using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleColorB : MonoBehaviour, IOutputModule {

	private Material _material;
	public Board _board { get; set; }

	void Start() {

		// Get the Skybox Material
		_material = _board._particleMaterial;

	}

	public void SubscribeToInput (IInputModule input) {

		input.OnValueChange += UpdateParticleMaterialB;

	}

	public void UnsubscribeFromInput (IInputModule input) {

		input.OnValueChange -= UpdateParticleMaterialB;

	}

	void UpdateParticleMaterialB(float value) {

		// print ("Updating Material");

		Color currentColor = _material.GetColor ("_EmissionColor");
		_material.SetColor("_EmissionColor", new Color(currentColor.r, currentColor.g, value));
		// _board._particlePrefab.GetComponent<Renderer> ().sharedMaterial = _material;

	}

}
