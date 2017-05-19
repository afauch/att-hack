using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiComponent : MonoBehaviour {

	private Vector3 _referenceScale;
	private Color[] _referenceLineColors;
	private IoLine[] lines;

	public Handle _handle;
	public NodeConnector _nodeConnector;
	private Material _linesSharedMaterial;
	private Color _linesReferenceColor;

	private float _lerpTime;
	private float _randomOffset;

	// Use this for initialization
	void Start () {

		// Subscribe to the OnUiToggle Event
		StateManager.OnUiToggle += OnUiToggle;
		_lerpTime = StateManager._instance._lerpTime;

		_randomOffset = Random.Range (0.0f,0.3f);
		_nodeConnector = GetComponentInChildren<NodeConnector> ();
		
	}

	void OnUiToggle(bool uiVisible) {

		if (uiVisible) {

			// if it's visible, then hide it
			Hide ();

		} else {

			// if it's hiddne, then show it
			Show ();

		}

	}

	void Hide () {
			

		// first, save the current scale
		_referenceScale = this.gameObject.transform.localScale;
		// Make the UI disappear
		StartCoroutine (LerpHelper.LerpScaleWithEasing (this.gameObject, this.gameObject.transform.localScale, Vector3.zero, _lerpTime, "Quintic", false, (0.7f * _lerpTime)+_randomOffset));

	}

	void Show () {


		StartCoroutine(LerpHelper.LerpScaleWithEasing (this.gameObject, this.gameObject.transform.localScale, _referenceScale, StateManager._instance._lerpTime, "Quintic", false, _randomOffset));

	}

}
