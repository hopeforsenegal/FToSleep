using UnityEngine;
using System.Collections;

public class DoorsPinPivot : MonoBehaviour {

	private float _stepAmount = 45.0f;

	[Range(0, 7)]
	public int initalRotationIndex = 0;

	// Use this for initialization
	void Start () {
		transform.eulerAngles = Vector3.forward * _stepAmount * initalRotationIndex;
	}

}
