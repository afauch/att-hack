using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionInteraction : MonoBehaviour {

	public static SelectionInteraction _instance;


	[Header("General")]
	[SerializeField] private AudioSource _audioSource;


	[Header("Select")]
	[SerializeField] private GameObject _particles;
	[SerializeField] private AudioClip _selectAudioClip;

	void Awake () {

		_instance = this;
		_audioSource = GetComponent<AudioSource> ();

	}

	void Start () {

		_audioSource.clip = _selectAudioClip;

	}

	public void Play () {

		// instantiate at click point
		_audioSource.Play ();

		Vector3 mousePos = Input.mousePosition;
		mousePos.z = Camera.main.nearClipPlane;
		Vector3 screenPoint = Camera.main.ScreenToWorldPoint (mousePos);
		GameObject thisParticles = GameObject.Instantiate(_particles, screenPoint, Quaternion.identity);
		ParticleSystem particles = thisParticles.GetComponent<ParticleSystem> ();
		particles.Play ();

	}


}
