using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleColorR : MonoBehaviour, IOutputModule {

	private Material _material;
	public Board _board { get; set; }

	void Start() {

		// Get the Prefab Material
		_material = _board._particleMaterial;

	}

	public void SubscribeToInput (IInputModule input) {

		input.OnValueChange += UpdateParticleMaterialR;

	}


	public void UnsubscribeFromInput (IInputModule input) {

		input.OnValueChange -= UpdateParticleMaterialR;

	}

	void UpdateParticleMaterialR(float value) {

		// print ("Updating Material");

		Color currentColor = _material.GetColor ("_EmissionColor");
		_material.SetColor("_EmissionColor", new Color(value, currentColor.g, currentColor.b));
		// _board._particlePrefab.GetComponent<Renderer> ().sharedMaterial = _material;

	}

}
