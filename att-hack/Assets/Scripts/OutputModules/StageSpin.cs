using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSpin : MonoBehaviour, IOutputModule {

	public GameObject _stage;
	private Rotate _rotate;

	void Start () {

		_rotate = _stage.GetComponent<Rotate> ();

	}

	public void SubscribeToInput (IInputModule input) {

		input.OnValueChange += UpdateStageRotation;

	}

	public void UnsubscribeFromInput (IInputModule input) {

		input.OnValueChange -= UpdateStageRotation;

	}

	void UpdateStageRotation(float value) {

		_rotate._rotationRate = new Vector3 (0.0f, Mathf.Lerp(0.0f, 10.0f, value) , 0.0f);

	}

}
