﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

//------------------------------------------------------------------------------
// class definition
//------------------------------------------------------------------------------
[RequireComponent (typeof(BoxCollider2D))]
public class LullabyDemonPooledObject : MonoBehaviour
{
	// singleton list to hold all our projectiles
	static private List<LullabyDemonPooledObject> objectControllers;

	private float fallSpeed;
	private SpriteRenderer currentImage;

	//--------------------------------------------------------------------------
	// static public methods
	//--------------------------------------------------------------------------
	static public LullabyDemonPooledObject Spawn (Vector3 location, float fallSpeed, Sprite image)
	{
		// search for the first free LullabySheepPooledObject
		foreach (LullabyDemonPooledObject objectController in objectControllers) {
			// if disabled, then it's available
			if (objectController.gameObject.activeSelf == false) {
				// set it up
				objectController.transform.position = location;
				objectController.gameObject.GetComponent<SpriteRenderer> ().sprite = image;
				objectController.fallSpeed = fallSpeed;

				// switch it back on
				objectController.gameObject.SetActive (true);

				// return a reference to the caller
				return objectController;

			}
		}

		Debug.LogWarning ("Don't have enough objects pre-allocated");
		// if we get here, we haven't pooled enough agents or our spawn rate is too high.

		return null;
	}

	static public void ResetControllers ()
	{

		foreach (LullabyDemonPooledObject objectController in objectControllers) {
			objectController.gameObject.SetActive (false);
		}
	}

	//--------------------------------------------------------------------------
	// protected mono methods
	//--------------------------------------------------------------------------
	protected void Awake ()
	{
		// does the pool exist yet?
		if (objectControllers == null) {
			// lazy initialize it
			objectControllers = new List<LullabyDemonPooledObject> ();
		}
		// add myself
		objectControllers.Add (this);
	}

	protected void OnDestroy ()
	{
		// remove myself from the pool
		objectControllers.Remove (this);
		// was I the last one?
		if (objectControllers.Count == 0) {
			// remove the pool itself
			objectControllers = null;
		}
	}

	protected void OnDisable ()
	{
	}

	protected void OnEnable ()
	{
	}

	protected void Start ()
	{
		gameObject.SetActive (false);
	}

	protected void Update ()
	{
		// travel in a straight line at 4 units per second
		transform.position -= transform.up * (Time.deltaTime * fallSpeed);
	}

	protected void OnBecameInvisible ()
	{
		// I've left the screen. Disable myself so I'm available again
		gameObject.SetActive (false);
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.name == "Paddle") {
			LullabyManager.Instance.numberOfMisses = 4;
			LullabyManager.Instance.PlayDemonScream ();
			gameObject.SetActive (false);
		}
	}

	//--------------------------------------------------------------------------
	// private methods
	//--------------------------------------------------------------------------
}
