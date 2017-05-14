using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiJack;

public class Note : MonoBehaviour {

	private Board _board;
	private MidiChannel _midiChannel;
	[SerializeField] private int _midiChannelInt;
	[SerializeField] private int _note;
	private GameObject _gameObject;

	// Use this for initialization
	void Start () {

		InitializeGameObject ();

		// Subscribe this class's to the OnKnob event
		MidiMaster.noteOnDelegate += OnNoteOn;

		// Cast the int as a MidiChannel.
		_midiChannel = (MidiChannel)(_midiChannelInt - 1);

		// TODO: Temporary, delete, a Note should be instantiated by a Board
		if (_board == null) {
			_board = GetComponentInParent<Board> ();
		}
		
	}

	private void InitializeGameObject () {

		_gameObject = this.gameObject;

		string idString = string.Format ("{0}/{1}", _midiChannelInt, _note);
		_gameObject.name = "n" + idString;

	}

	public void OnNoteOn(MidiChannel channel, int note, float velocity) {

		if (_midiChannel == channel && note == _note) {

			// Debug.Log (string.Format ("Channel {0} and Note {1} were played", channel, note));
			InstantiateNote(_board._prefab, channel, note, velocity);

		}

	}

	private void InstantiateNote(GameObject prefab, MidiChannel channel, int note, float velocity) {

		GameObject g = GameObject.Instantiate(prefab, _gameObject.transform.position, _gameObject.transform.rotation);

	}


}
