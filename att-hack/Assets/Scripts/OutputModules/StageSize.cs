using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSize : MonoBehaviour, IOutputModule {

	public GameObject _stage;

	public void SubscribeToInput (IInputModule input) {

		input.OnValueChange += UpdateStageSize;

	}

	public void UnsubscribeFromInput (IInputModule input) {

		input.OnValueChange -= UpdateStageSize;

	}


	void UpdateStageSize(float value) {

		// _stage.transform.localScale = new Vector3 (Mathf.Lerp(0.0f,500.0f,value), 1.0f, Mathf.Lerp(0.0f,500.0f,value));
		StartCoroutine(LerpHelper.LerpScaleWithEasing(_stage,_stage.transform.lossyScale,new Vector3 (Mathf.Lerp(0.0f,500.0f,value), 1.0f, Mathf.Lerp(0.0f,500.0f,value)),0.2f,"Linear", false, 0.0f));

	}

}
