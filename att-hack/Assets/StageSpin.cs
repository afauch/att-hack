using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSpin : MonoBehaviour, IOutputModule {

	public GameObject _stage;
	private Rotate _rotate;

	public void SubscribeToInput (Knob input) {

		input.OnValueChange += UpdateStageRotation;

	}

	void Start () {

		_rotate = _stage.GetComponent<Rotate> ();

	}

	void UpdateStageRotation(float value) {

		_rotate.rotationRate = new Vector3 (0.0f, Mathf.Lerp(0.0f, 10.0f, value) , 0.0f);

	}

}
