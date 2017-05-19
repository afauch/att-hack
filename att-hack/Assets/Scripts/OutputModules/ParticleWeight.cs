using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleWeight : MonoBehaviour, IOutputModule {

	public Board _board { get; set; }

	public void SubscribeToInput(IInputModule input) {

		// Is this a Knob? Subscribe to Input
		if(input._inputType == InputType.Knob)
			input.OnValueChange += SetBoardParticleWeight;

		// If it's Velocity, toggle the Board bool
		if(input._inputType == InputType.Velocity)
			SetVelocityToWeight(true);

	}

	public void UnsubscribeFromInput (IInputModule input) {


		// Is this a Knob? Unsubscribe from Input
		if(input._inputType == InputType.Knob)
			input.OnValueChange -= SetBoardParticleWeight;

		// If it's Velocity, toggle the Board bool
		if(input._inputType == InputType.Velocity)
			SetVelocityToWeight(false);


	}

	private void SetVelocityToWeight(bool activate) {

		_board._velocityToWeight = activate;

	}

	private void SetBoardParticleWeight(float value) {

		_board._instantiationMass = Mathf.Lerp (0.01f, 10000.0f, value);
		_board._instantiationDrag = Mathf.Lerp (10.0f, 0.0f, value);


	}

}
