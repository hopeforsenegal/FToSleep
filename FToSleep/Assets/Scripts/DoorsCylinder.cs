using UnityEngine;
using System.Collections;

public class DoorsCylinder : MonoBehaviour {

	private float _currentStep = 0.0f;
	private float _stepAmount = 45.0f;
	private float _speed = 5.0f;

	// Use this for initialization
	void Start () {
		_currentStep = (int) Random.Range (0.0f, 7.0f);
		UpdateRotation (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.LeftArrow) == true || Input.GetKeyDown(KeyCode.RightArrow) == true) {
			if (Input.GetAxis ("Horizontal") > 0) {
				_currentStep--;
			} else {
				_currentStep++;
			}
		}
		UpdateRotation ();
	}

	void UpdateRotation ( bool animate = true ) {
		if (_currentStep > 7.0f) {
			_currentStep = 0.0f;
		} else if (_currentStep < 0.0f) {
			_currentStep = 7.0f;
		}
		Vector3 angle = new Vector3 (0.0f, 0.0f, _currentStep * _stepAmount);
		Quaternion rotation = Quaternion.Euler (angle);
		if (animate) {
			transform.rotation = Quaternion.Slerp (transform.rotation, rotation, _speed * Time.deltaTime);
		} else {
			transform.rotation = rotation;
		}
	}
		
}
