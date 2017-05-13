using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiJack;

public class KnobListener : MonoBehaviour {

	private const string _idLabelName = "id_label";
	private const string _valLabelName = "val_label";

	private MidiChannel _midiChannel;
	public int _midiChannelInt;
	public int _knobNumber;
	private float _knobValue;

	private GameObject _gameObject;
	private TextMesh _idLabel;
	private TextMesh _valLabel;

	// 

	void Start () {

		InitializeGameObject ();

		// Cast the int as a MidiChannel.
		_midiChannel = (MidiChannel)(_midiChannelInt - 1);

		// Subscribe this class's to the OnKnob event
		MidiMaster.knobDelegate += OnKnob;

	}

	void InitializeGameObject() {

		_gameObject = this.gameObject;
		TextMesh[] tm = _gameObject.GetComponentsInChildren<TextMesh> ();

		foreach (TextMesh t in tm) {

			if (t.gameObject.name.ToLower() == _idLabelName)
				_idLabel = t;

			if (t.gameObject.name.ToLower() == _valLabelName)
				_valLabel = t;

		}

		string idString = string.Format ("{0}/{1}", _midiChannelInt, _knobNumber);
		_idLabel.text = idString;
		_gameObject.name = "k" + idString;

	}


	void OnKnob(MidiChannel channel, int knobNumber, float knobValue) {

		// is this the right knob?
		if (_midiChannel == channel && _knobNumber == knobNumber) {

			_knobValue = knobValue;
			UpdateValue ();

		}

	}

	void UpdateValue() {

		_valLabel.text = _knobValue.ToString();

	}
		

}
