using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Paddle))]
public class PlayerInput : MonoBehaviour
{
	private Paddle paddle;

	protected void Awake ()
	{
		paddle = GetComponent<Paddle> ();
	}

	protected void Update ()
	{
		if (Input.GetButtonDown ("Up")) {
			Debug.Log ("UP was pressed", gameObject);
		} else if (Input.GetButtonDown ("Right")) {
			Debug.Log ("RIGHT was pressed", gameObject);
			paddle.MoveRight ();
		} else if (Input.GetButtonDown ("Down")) {
			Debug.Log ("DOWN was pressed", gameObject);
		} else if (Input.GetButtonDown ("Left")) {
			Debug.Log ("LEFT was pressed", gameObject);
			paddle.MoveLeft ();
		}
	}
}
