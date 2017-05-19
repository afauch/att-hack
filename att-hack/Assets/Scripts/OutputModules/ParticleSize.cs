using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSize : MonoBehaviour, IOutputModule {

	public Board _board { get; set; }

	public void SubscribeToInput(IInputModule input) {

		input.OnValueChange += SetBoardParticleSize;

	}


	public void UnsubscribeFromInput (IInputModule input) {

		input.OnValueChange -= SetBoardParticleSize;

	}

	private void SetBoardParticleSize(float value) {

		float scale = Mathf.Lerp (0.05f, 2.0f, value);
		_board._particlePrefab.transform.localScale = new Vector3 (scale, scale, scale);

	}


}
