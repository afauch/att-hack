using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour {

	public float _lifeTime;
	public bool _fadeOut;
	public float _fadeOutTime;

	void Start() {

		if (_fadeOut) {

			IEnumerator disappear = LerpHelper.LerpScaleWithEasing(this.gameObject,this.gameObject.transform.localScale,new Vector3(0.0f,0.0f,0.0f),_fadeOutTime,"Quintic",true,_lifeTime);
			StartCoroutine (disappear);

		} else {
			
			Destroy (this.gameObject, _lifeTime);

		}

	}

}
