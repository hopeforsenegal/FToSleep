using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof(Rigidbody2D))]
public class Paddle : MonoBehaviour
{
	public float maxMoveSpeed;
	private float moveDeadZone;
	public float moveAcceleration;
	private float deceleration;
	private float slowMoveSpeedRatio;
	private float fastMoveSpeedRatio;

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
		}

		moved = false;
	}

	public void MoveLeft ()
	{
		moved = true;
		currentMoveSpeed -= moveAcceleration * Time.deltaTime;
		currentMoveSpeed = Mathf.Max (-1 * maxMoveSpeed, currentMoveSpeed);
	}

	public void MoveRight ()
	{
		moved = true;
		currentMoveSpeed += moveAcceleration * Time.deltaTime;
		currentMoveSpeed = Mathf.Min (maxMoveSpeed, currentMoveSpeed);
	}
}
