using UnityEngine;
using System.Collections;

public class DoorsPin : MonoBehaviour {

	private float _speed = 5.0f;
	private Vector3 _upPos = new Vector3 (0.0f, 3.0f, 0.0f);
	private Vector3 _bouncePos = new Vector3 (0.0f, 1.7f, 0.0f);
	private Vector3 _downPos = new Vector3 (0.0f, 0.0f, 0.0f);
	private Vector3 _currentPos;
	private bool _bounce = false;

	public void SetSortingOrder( int sortingOrder ) {
		SpriteRenderer sprite = GetComponent<SpriteRenderer> ();
		if (sprite) {
			sprite.sortingOrder = sortingOrder;
		}
	}

	public void Insert () {
		_bounce = false;
		_currentPos = _downPos;
	}

	public void Bounce () {
		_bounce = true;
		_currentPos = _bouncePos;
	}

	// Use this for initialization
	void Start () {
		_currentPos = _upPos;
		UpdatePosition (false);
	}
	
	// Update is called once per frame
	void Update () {
		UpdatePosition ();
	}

	void UpdatePosition ( bool animate = true ) {
		if (animate) {
			if (_bounce && transform.localPosition == _currentPos) {
				_bounce = false;
				_currentPos = _upPos;
			}
			transform.localPosition = Vector3.Slerp (transform.localPosition, _currentPos, _speed * Time.deltaTime);
		} else {
			transform.localPosition = _currentPos;
		}
	}

}
