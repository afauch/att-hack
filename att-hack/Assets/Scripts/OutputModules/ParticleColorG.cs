using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleColorG : MonoBehaviour, IOutputModule {

	private Material _material;
	public Board _board;

	void Start() {

		// Get the Skybox Material
		_material = _board._particleMaterial;

	}

	public void SubscribeToInput (IInputModule input) {

		input.OnValueChange += UpdateParticleMaterialG;

	}

	public void UnsubscribeFromInput (IInputModule input) {

		input.OnValueChange -= UpdateParticleMaterialG;

	}

	void UpdateParticleMaterialG(float value) {

		// print ("Updating Material");

		Color currentColor = _material.GetColor ("_EmissionColor");
		_material.SetColor("_EmissionColor", new Color(currentColor.r, value, currentColor.b));
		// _board._particlePrefab.GetComponent<Renderer> ().sharedMaterial = _material;

	}

}
