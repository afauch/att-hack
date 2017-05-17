using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBoard : MonoBehaviour {

	public int _midiChannelInt;
	private Vector3 _spawnPoint;

	// Use this for initialization
	void Start () {

		_spawnPoint = GameObject.FindGameObjectWithTag (Tags.SpawnPoint).transform.position;

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (0)) {

			OnClick ();

		}
	}

	void OnClick () {

		// Instantiate a new Board with the transform of spawn point


	}

}
