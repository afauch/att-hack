using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiJack;

public class Board : MonoBehaviour {

	public int _boardId;
	public GameObject _particlePrefab;
	public Material _particleMaterial;
	public Handle _handle;
	public GameObject _root;

	#region BoardParams
	// there's a better way to do this:
	// transform velocity and pitch into a normalize float
	// and then assign them as modifiers

	public int _channel;
	public MidiJack.MidiChannel _midiChannel;
	public Format _format;
	public float _spacing;

	[HideInInspector]public bool _velocityToSize;
	[HideInInspector]public bool _velocityToColor;
	[HideInInspector]public bool _velocityToOpacity;
	[HideInInspector]public bool _velocityToWeight;
	[HideInInspector]public bool _velocityToBounce;
	[HideInInspector]public bool _noteToBounce;
	[HideInInspector]public bool _noteToScale;
	[HideInInspector]public bool _noteToWeight;
	#endregion

	#region InstantiationParameters
	[HideInInspector]public Vector3 _instantiationScale;
	[HideInInspector]public float _instantiationMass;
	[HideInInspector]public float _instantiationDrag;
	#endregion
	public List<Note> _notes;

	void Awake () {

		_notes = new List<Note> ();

	}

	public void Init () {

		for (int i = 0; i < 128; i++) {

			// Create the gameObject
			GameObject note = new GameObject("n" + _channel + "/" + i);

			// Layout the gameObjects
			switch (_format) {
			case Format.Grid:
				note.transform.position = _root.transform.position + new Vector3 (i % _spacing, i / _spacing, 0);
				break;
			case Format.Line:
				float offset = (_spacing * i)-((128/2)*_spacing);
				note.transform.position = _root.transform.position + new Vector3 (offset, 0, 0);
				break;
			default:
				note.transform.position = Vector3.zero;
				break;
			}

			note.transform.SetParent (_root.transform);

			note.AddComponent<Note> ();
			Note n = note.GetComponent<Note> ();

			n._board = this;
			n._midiChannelInt = _channel;
			n._note = i;
			n._gameObject = note;
			n.InitNote ();

			_notes.Add (n);

			// Initialize instantiation parameters
			_instantiationScale = _particlePrefab.transform.localScale;
			Rigidbody r = _particlePrefab.GetComponent<Rigidbody> ();
			_instantiationMass = r.mass;
			_instantiationDrag = r.drag;

			_midiChannel = (MidiChannel)(_channel - 1);

		}
			
	}

}
