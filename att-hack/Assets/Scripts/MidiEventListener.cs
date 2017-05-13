using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiJack;

public class MidiEventListener : MonoBehaviour {

	// research how to do this the 'right' way with Instance
	public static MidiEventListener _instance;
	// public static event MidiDriver.KnobDelegate OnKnob;


	void Awake () {

		_instance = this;

	}

	void Start () {

		// Add this method to the knobDelegate
		// MidiMaster.knobDelegate += PrintKnobToDebug;

	}

	void Update () {

	}


	// Note that this has the same signature as the event
	// void PrintKnobToDebug (MidiChannel channel, int knobNumber, float knobValue) {

		// Debug.Log (string.Format("Channel: {0}, Knob Number:{1}, KnobValue {2}", channel, knobNumber, knobValue));
		

	// }


}
