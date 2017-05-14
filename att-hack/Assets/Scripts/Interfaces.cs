using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IOutputModule {

	// Any Output module must have an implementation
	// for SubscribeToInput
	void SubscribeToInput(Knob input);


}