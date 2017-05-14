using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleWeight : MonoBehaviour, IOutputModule {

	public Board _board;

	public void SubscribeToInput(IInputModule input) {

		// Is this a Knob? Subscribe to Input
		if(input._inputType == InputType.Knob)
			input.OnValueChange += SetBoardParticleWeight;

		// If it's Velocity, toggle the Board bool
		if(input._inputType == InputType.Velocity)
			SetVelocityToWeight(true);

	}

	private void SetVelocityToWeight(bool activate) {

		_board._velocityToWeight = activate;

	}

	private void SetBoardParticleWeight(float value) {

		Rigidbody r = _board._particlePrefab.GetComponent<Rigidbody> ();
		r.mass = Mathf.Lerp (0.01f, 10000.0f, value);
		r.drag = Mathf.Lerp (10.0f, 0.0f, value);
	}

}
