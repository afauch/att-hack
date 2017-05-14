using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour {

	public GameObject _particlePrefab;
	public Material _particleMaterial;

	#region BoardParams
	// there's a better way to do this:
	// transform velocity and pitch into a normalize float
	// and then assign them as modifiers

	public int _channel;
	public Format _format;
	public float _spacing;

	public bool _velocityToSize;
	public bool _velocityToColor;
	public bool _velocityToOpacity;
	public bool _velocityToWeight;
	public bool _noteToScale;
	public bool _noteToWeight;
	#endregion

	void Awake () {

		for (int i = 0; i < 128; i++) {

			// Create the gameObject
			GameObject note = new GameObject("n" + _channel + "/" + i);

			// Layout the gameObjects

			switch (_format) {
			case Format.Grid:
				note.transform.position = gameObject.transform.position + new Vector3 (i % _spacing, i / _spacing, 0);
				break;
			case Format.Line:
				int offset = i - (128 / 2);
				note.transform.position = gameObject.transform.position + new Vector3 (offset + (i *_spacing), 0, 0);
				break;
			default:
				note.transform.position = Vector3.zero;
				break;
			}

			note.transform.SetParent (this.gameObject.transform);

			note.AddComponent<Note> ();
			Note n = note.GetComponent<Note> ();

			n._board = this;
			n._midiChannelInt = _channel;
			n._note = i;
			n._gameObject = note;
			n.InitNote ();

		}

	}



}
