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

	public void Play (GameObject g) {

		// instantiate at click point
		_audioSource.Play ();

		GameObject thisParticles = GameObject.Instantiate(_particles, g.transform.position, Quaternion.identity);
		ParticleSystem particles = thisParticles.GetComponent<ParticleSystem> ();
		particles.Play ();

	}


}
