using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour {

	public GameObject _particlePrefab;
	public Material _particleMaterial;

	#region BoardParams
	// there's a better way to do this:
	// transform velocity and pitch into a normalize float
	// and then assign them as modifiers
	public bool _velocityToSize;
	public bool _velocityToColor;
	public bool _velocityToOpacity;
	public bool _velocityToWeight;
	public bool _noteToScale;
	public bool _noteToWeight;
	#endregion



}
