using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

//------------------------------------------------------------------------------
// class definition
//------------------------------------------------------------------------------
public class LullabySheepPooledObject : MonoBehaviour
{
	// singleton list to hold all our projectiles
	static private List<LullabySheepPooledObject> objectControllers;

	private float fallSpeed;
	private Image currentImage;
	
	//--------------------------------------------------------------------------
	// static public methods
	//--------------------------------------------------------------------------
	static public LullabySheepPooledObject Spawn (Vector3 location, float fallSpeed, int direction, Sprite[] images)
	{
		// search for the first free LullabySheepPooledObject
		foreach (LullabySheepPooledObject symbolController in objectControllers) {
			// if disabled, then it's available
			if (symbolController.gameObject.activeSelf == false) {
				// set it up
				symbolController.transform.position = location;
				symbolController.gameObject.GetComponent<Image> ().sprite = images [direction];
				symbolController.fallSpeed = fallSpeed;
				
				// switch it back on
				symbolController.gameObject.SetActive (true);
				
				// return a reference to the caller
				return symbolController;
				
			}
		}
		
		Debug.LogWarning ("Don't have enough objects pre-allocated");
		// if we get here, we haven't pooled enough agents or our spawn rate is too high.

		return null;
	}

	static public void ResetControllers ()
	{
		
		foreach (LullabySheepPooledObject symbolController in objectControllers) {
			symbolController.gameObject.SetActive (false);
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
			objectControllers = new List<LullabySheepPooledObject> ();
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
	
	//--------------------------------------------------------------------------
	// private methods
	//--------------------------------------------------------------------------
}
