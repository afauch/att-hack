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
			r.drag = Mathf.Lerp (100.0f, 0.0f, velocity);
		}
			
		// Instantiate
		GameObject g = GameObject.Instantiate(_board._particlePrefab, gameObject.transform.position, Quaternion.identity);
		g.transform.SetParent (_board.gameObject.transform);
//
//		// Velocity to Opacity
//		if (_board._velocityToOpacity) {
//			Renderer r = g.GetComponent<Renderer> ();
//			Material m = r.material;
//			m.color = new Color (m.color.r, m.color.g, m.color.b, velocity);
//		}

	}



}
