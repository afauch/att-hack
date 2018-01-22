using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRTK;

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

            ToggleUi();
		}

		if (Input.GetKeyUp (KeyCode.R)) {

			SceneManager.LoadScene (0);

		}

	}

    public void ToggleUi()
    {
        OnUiToggle(_uiVisible);
        _uiVisible = !_uiVisible;
    }

}
