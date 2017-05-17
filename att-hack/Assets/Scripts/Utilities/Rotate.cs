using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	public Vector3 _rotationRate;
	public bool _lookAtCamera;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		if (_lookAtCamera) {
			gameObject.transform.LookAt (Camera.main.transform);
		} else {
			gameObject.transform.Rotate (_rotationRate);
		}

	}
}
