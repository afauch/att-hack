using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardSpin : MonoBehaviour, IOutputModule {

	private Rotate _rotate;
	public Board _board { get; set; }

	void Start () {

		_rotate = BoardManager._instance.GetComponent<Rotate>();

	}

	public void SubscribeToInput (IInputModule input) {

		input.OnValueChange += UpdateBoardRotation;

	}

	public void UnsubscribeFromInput (IInputModule input) {

		input.OnValueChange -= UpdateBoardRotation;

	}

	void UpdateBoardRotation(float value) {

		_rotate._rotationRate = new Vector3 (0.0f, Mathf.Lerp(0.0f, 10.0f, value) , 0.0f);

	}

}
