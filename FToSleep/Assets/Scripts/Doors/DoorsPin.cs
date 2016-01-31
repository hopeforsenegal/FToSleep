using UnityEngine;
using System.Collections;

public class DoorsPin : MonoBehaviour {

	private float _speed = 5.0f;
	private float _upPos = 4.0f;
	private float _bouncePos =  3.4f;
	private float _downPos = 1.5f;
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
		_currentPos.y = _downPos;
	}

	public void Bounce () {
		_bounce = true;
		_currentPos.y = _bouncePos;
	}

	// Use this for initialization
	void Start () {
		_currentPos = transform.localPosition;
		_currentPos.y = _upPos;
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
				_currentPos.y = _upPos;
			}
			transform.localPosition = Vector3.Lerp (transform.localPosition, _currentPos, _speed * Time.deltaTime);
		} else {
			transform.localPosition = _currentPos;
		}
	}

}
