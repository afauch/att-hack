using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBoard : MonoBehaviour {

	public int _midiChannelInt;

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(_midiChannelInt.ToString())) {

			OnSelect (this.gameObject);

		}
	}


	void OnSelect (GameObject g) {

		SelectionInteraction._instance.Play (this.gameObject);

		// Instantiate a new Board with the transform of spawn point
		BoardManager._instance.AddBoard(_midiChannelInt);

	}

}
