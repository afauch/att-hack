using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSize : MonoBehaviour, IOutputModule {

	public Board _board;

	public void SubscribeToInput(Knob knob) {

		// Don't actually do anything

		// Just toggle the boolean on Board
		SetVelocityToSize(true);

	}

	private void SetVelocityToSize(bool activate) {

		_board._velocityToSize = activate;

	}


}
