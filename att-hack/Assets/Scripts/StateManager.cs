using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour {

	public static StateManager _instance;

	public float _lerpTime;

	public delegate void UiToggle(bool uiVisible);
	public static event UiToggle OnUiToggle;

	private bool _uiVisible;

	void Awake () {
		_instance = this;
	}

	void Start () {

		_uiVisible = true;

	}

	void Update () {

		if (Input.GetKeyUp (KeyCode.Space) && OnUiToggle != null) {

			OnUiToggle (_uiVisible);
			_uiVisible = !_uiVisible;

		}

	}

}
