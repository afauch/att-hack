using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiJack;

public class KnobListener : MonoBehaviour {

	public int _knobNumber;


	// Update is called once per frame
	void Update () {

		if(MidiMaster.GetKnob(MidiChannel.Ch1, _knobNumber, 0.0f) > 0.0f) {
			float knobValue = MidiMaster.GetKnob (MidiChannel.Ch1, _knobNumber, 0.0f);
			Debug.Log (knobValue);
		}
		
	}
}
