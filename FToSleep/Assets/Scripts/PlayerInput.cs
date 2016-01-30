using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Paddle))]
[RequireComponent (typeof(Runner))]
public class PlayerInput : MonoBehaviour
{
	private Paddle paddle;
	private Runner runner;

	protected void Awake ()
	{
		paddle = GetComponent<Paddle> ();
		runner = GetComponent<Runner> ();
	}

	protected void Update ()
	{
		if (Input.GetButtonDown ("Horizontal") && Input.GetAxisRaw ("Horizontal") > 0) {
			// Move to the right
			paddle.MoveRight ();
			Debug.Log ("RIGHT was pressed");
		} else if (Input.GetButtonDown ("Horizontal") && Input.GetAxisRaw ("Horizontal") < 0) {
			// Move to the left
			paddle.MoveLeft ();
			Debug.Log ("LEFT was pressed");
		} else if (Input.GetButtonDown ("Vertical") && Input.GetAxisRaw ("Vertical") > 0) {
			// Move up
			Debug.Log ("UP was pressed");
		} else if (Input.GetButtonDown ("Vertical") && Input.GetAxisRaw ("Vertical") < 0) {
			// Move down
			Debug.Log ("DOWN was pressed");
		}
	}
}
