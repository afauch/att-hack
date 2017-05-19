using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiJack;

public class Velocity : MonoBehaviour, IInputModule {

	public InputType _inputType { get; set; }
	public Board _board { get; set; }
	public event ValueChange OnValueChange;

	void Awake () {

		_inputType = InputType.Velocity;

	}

	void Start () {

		// Subscribe to noteOn
		MidiMaster.noteOnDelegate += OnNoteOn;

	}


	public void DestroyInput () {

		// Unsubscribe
		MidiMaster.noteOnDelegate -= OnNoteOn;

	}

	private void OnNoteOn(MidiChannel channel, int note, float velocity) {

		if (OnValueChange != null) {
			// then call OnValueChange which will populate value to all subscribers

			if ((int)channel == _board._channel) {

				OnValueChange (velocity);

			}

		}

	}


}
