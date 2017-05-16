using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleBounce : MonoBehaviour, IOutputModule {

	public Board _board;

	public void SubscribeToInput(IInputModule input) {

		// Is this a Knob? Subscribe to Input
		if(input._inputType == InputType.Knob)
			input.OnValueChange += SetBoardParticleBounce;

		// If it's Velocity, toggle the Board bool
		if(input._inputType == InputType.Velocity)
			SetVelocityToBounce(true);

	}

	private void SetVelocityToBounce(bool activate) {

		_board._velocityToWeight = activate;

	}

	private void SetBoardParticleBounce(float value) {

		Collider c = _board._particlePrefab.GetComponent<Collider> ();
		c.material.bounciness = Mathf.Lerp (0.0f, 1.0f, value);
	}

}
