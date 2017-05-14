using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiJack;

public class Velocity : MonoBehaviour, IInputModule {

	void Awake () {

		_inputType = InputType.Velocity;

	}

	void Start () {

		// Subscribe to noteOn
		MidiMaster.noteOnDelegate += OnNoteOn;

	}

	public InputType _inputType { get; set; }

	// TODO: This is currently needed for the interface but may not actually do anything
	public event ValueChange OnValueChange;


	private void OnNoteOn(MidiChannel channel, int note, float velocity) {

		// Later, determine if this is necessary

	}


}
