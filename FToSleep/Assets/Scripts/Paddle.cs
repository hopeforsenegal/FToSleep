using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody2D))]
public class Paddle : MonoBehaviour
{
	private float maxMoveSpeed;
	private float moveAcceleration;
	private float deceleration;
	private float slowMoveSpeedRatio;
	private float fastMoveSpeedRatio;

	private float currentMoveSpeed;

	protected void Awake ()
	{
	}

	protected void Start ()
	{
	}

	protected void Update ()
	{
		rigidbody2D.velolcity = new Vector2 (currentMoveSpeed, 0);
	}

	public void MoveRight ()
	{
	}

	public void MoveLeft ()
	{
	}
}
