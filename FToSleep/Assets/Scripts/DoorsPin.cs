﻿using UnityEngine;
using System.Collections;

public class DoorsPin : MonoBehaviour {

	private float _speed = 5.0f;
	private Vector3 _upPos = new Vector3 (0.0f, 3.0f, 0.0f);
	private Vector3 _downPos = new Vector3 (0.0f, 0.0f, 0.0f);
	private Vector3 _currentPos;

	// Use this for initialization
	void Start () {
		_currentPos = _upPos;
		UpdatePosition (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) == true) {
			_currentPos = _downPos;
		}
		UpdatePosition ();
	}

	void UpdatePosition ( bool animate = true ) {
		if (animate) {
			transform.localPosition = Vector3.Slerp (transform.localPosition, _currentPos, _speed * Time.deltaTime);
		} else {
			transform.localPosition = _currentPos;
		}
	}

}
