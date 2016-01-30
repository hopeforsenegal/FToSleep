using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent (typeof(PlayerInput))]
public class Paddle : MonoBehaviour
{
	public float moveSpeed;
	public float moveDeadZone;
	public float deceleration;

	private bool moved;
	private float currentMoveSpeed;


	protected void Awake ()
	{
	}

	protected void Start ()
	{
	}

	protected void Update ()
	{
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (currentMoveSpeed, 0);

		if (!moved) {
			if (Mathf.Abs (currentMoveSpeed) < moveDeadZone) {
				currentMoveSpeed = 0;
			} else if (currentMoveSpeed < 0) {
				currentMoveSpeed += deceleration * Time.deltaTime;
			} else {
				currentMoveSpeed -= deceleration * Time.deltaTime;
			}

			Vector3 pos = Camera.main.WorldToViewportPoint (transform.position);
			pos.x = Mathf.Clamp(pos.x, 0.0f, 0.92f);
			transform.position = Camera.main.ViewportToWorldPoint(pos);
		}

		moved = false;
	}

	public void MoveLeft ()
	{
		moved = true;
		currentMoveSpeed = -moveSpeed;
	}

	public void MoveRight ()
	{
		moved = true;
		currentMoveSpeed = moveSpeed;
	}
}
