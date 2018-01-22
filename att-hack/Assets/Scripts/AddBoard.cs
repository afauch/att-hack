using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class AddBoard : MonoBehaviour {

	public int _midiChannelInt;

    // Subscribe to interactable object 'use' event
    void Start()
    {
        GetComponent<VRTK_InteractableObject>().InteractableObjectUsed += OnSelect;
    }

    // Update is called once per frame
    void Update () {

		if (Input.GetKeyDown(_midiChannelInt.ToString())) {

            OnSelect();

		}
	}

    // On Controller Interaction
    private void OnSelect(object o, InteractableObjectEventArgs e)
    {
        Debug.Log("Used");
        OnSelect();
    }

    // not sure why I included a GameObject parameter here ... could be deleted
    void OnSelect () {

		SelectionInteraction._instance.Play (this.gameObject);

		// Instantiate a new Board with the transform of spawn point
		BoardManager._instance.AddBoard(_midiChannelInt);

	}

}
