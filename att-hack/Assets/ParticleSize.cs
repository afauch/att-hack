using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSize : MonoBehaviour, IOutputModule {

	public Board _board;

	public void SubscribeToInput(IInputModule input) {

		// Is this a Knob? Subscribe to Input
		if(input._inputType == InputType.Knob)
			input.OnValueChange += SetBoardParticleSize;

		// If it's Velocity, toggle the Board bool
		if(input._inputType == InputType.Velocity)
			SetVelocityToSize(true);

	}

	private void SetVelocityToSize(bool activate) {

		_board._velocityToSize = activate;

	}

	private void SetBoardParticleSize(float value) {

		_board._particlePrefab.transform.localScale = new Vector3 (value, value, value);

	}


}
