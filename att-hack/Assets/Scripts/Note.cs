using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiJack;

public class Note : MonoBehaviour {

	public Board _board;
	public MidiChannel _midiChannel;
	public int _midiChannelInt;
	public int _note;
	public GameObject _gameObject;

	public void InitNote () {

		InitializeGameObject ();

		// Subscribe this class's to the OnKnob event
		MidiMaster.noteOnDelegate += OnNoteOn;

		// Cast the int as a MidiChannel.
		_midiChannel = (MidiChannel)(_midiChannelInt - 1);

	}

	public void DestroyNote () {

		// Unsubscribe from the OnNoteOnEvent
		MidiMaster.noteOnDelegate -= OnNoteOn;

	}

	private void InitializeGameObject () {

		_gameObject = this.gameObject;

		string idString = string.Format ("{0}/{1}", _midiChannelInt, _note);
		_gameObject.name = "n" + idString;

	}

	public void OnNoteOn(MidiChannel channel, int note, float velocity) {

		if (_midiChannel == channel && note == _note) {

			// Debug.Log (string.Format ("Channel {0} and Note {1} were played", channel, note));
			InstantiateNote(_board._particlePrefab, channel, note, velocity);

		}

	}

	private void InstantiateNote(GameObject prefab, MidiChannel channel, int note, float velocity) {


		// Velocity to Scale
		if (_board._velocityToSize) {
			_board._particlePrefab.transform.localScale = new Vector3 (velocity, velocity, velocity);
		}

		// Note to Scale
		if (_board._noteToScale) {
			float scale = ((128.0f - (float)_note) / 128.0f);
			_board._particlePrefab.transform.localScale = new Vector3 (scale, scale, scale);
		}

		// Velocity to Weight
		if (_board._velocityToWeight) {
			Rigidbody r = _board._particlePrefab.GetComponent<Rigidbody> ();
			r.mass = Mathf.Lerp (0.01f, 1000.0f, velocity);
			r.drag = Mathf.Lerp (10.0f, 0.0f, velocity);
		}

		// Velocity to Bounce
		if (_board._velocityToWeight) {
			Collider c = _board._particlePrefab.GetComponent<Collider> ();
			c.material.bounciness = Mathf.Lerp(0.0f, 1.0f, velocity);
		}
			
		// Instantiate
		GameObject g = GameObject.Instantiate(_board._particlePrefab, gameObject.transform.position, Quaternion.identity);
		// g.transform.SetParent (_board.gameObject.transform);
		g.GetComponent<Renderer>().material = new Material(_board._particleMaterial);


	}



}
