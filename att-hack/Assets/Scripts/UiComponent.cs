using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiComponent : MonoBehaviour {

	private Vector3 _referenceScale;
	private Color[] _referenceLineColors;
	private IoLine[] lines;

	private Material _linesSharedMaterial;
	private Color _linesReferenceColor;

	private float _lerpTime;

	private float _randomOffset;

	// Use this for initialization
	void Start () {

		// Subscribe to the OnUiToggle Event
		StateManager.OnUiToggle += OnUiToggle;
		_lerpTime = StateManager._instance._lerpTime;

		_randomOffset = Random.Range (0.0f,0.5f);
		
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

		// if there are lines
		if (this.gameObject.GetComponentInChildren<IoLine> () != null) {

			// Grab the shared material
			LineRenderer lr = this.gameObject.GetComponentInChildren<IoLine> ()._lr;
			print (lr);
			_linesSharedMaterial = lr.sharedMaterial;
			_linesReferenceColor = _linesSharedMaterial.color;

			StartCoroutine (LerpHelper.ColorFade (_linesSharedMaterial, Color.clear, _lerpTime, "Quintic", 0.0f));

		}

	}

	void Show () {

		StartCoroutine(LerpHelper.LerpScaleWithEasing (this.gameObject, this.gameObject.transform.localScale, _referenceScale, StateManager._instance._lerpTime, "Quintic", false, _randomOffset));

		// Fade the lines in
		StartCoroutine (LerpHelper.ColorFade (_linesSharedMaterial, _linesReferenceColor, _lerpTime, "Quintic", (0.7f * _lerpTime)));

	}

}
