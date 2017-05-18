using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBoard : MonoBehaviour {

	public int _midiChannelInt;

	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (0)) {

			OnClick ();

		}
	}

	void OnClick () {

		//create a ray cast and set it to the mouse's cursor position in game
		float distance = 50.0f; // this might need to be tweaked
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit, distance)) {
			if(hit.transform.gameObject == this.gameObject){
				OnSelect (hit.transform.gameObject);
			}
		}

	}

	void OnSelect (GameObject g) {

		SelectionInteraction._instance.Play (this.gameObject);

		// Instantiate a new Board with the transform of spawn point
		BoardManager._instance.AddBoard(_midiChannelInt);

	}

}
