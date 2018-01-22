﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class AddBoard : MonoBehaviour {

	public int _midiChannelInt;

    // Subscribe to controller events
    void Start()
    {

    }

    // Update is called once per frame
    void Update () {

		if (Input.GetKeyDown(_midiChannelInt.ToString())) {

			OnSelect (this.gameObject);

		}
	}

    // On Controller Interaction
    private void OnSelect(object o, InteractableObjectEventArgs e)
    {
        OnSelect((GameObject)o);
    }

    // not sure why I included a GameObject parameter here ... could be deleted
    void OnSelect (GameObject g) {

		SelectionInteraction._instance.Play (this.gameObject);

		// Instantiate a new Board with the transform of spawn point
		BoardManager._instance.AddBoard(_midiChannelInt);

	}

}
