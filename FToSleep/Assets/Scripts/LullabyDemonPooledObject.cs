using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

//------------------------------------------------------------------------------
// class definition
//------------------------------------------------------------------------------
public class LullabyDemonPooledObject : MonoBehaviour
{
	// singleton list to hold all our projectiles
	static private List<LullabyDemonPooledObject> symbolControllers;

	private float fallSpeed;
	private Image currentImage;
	
	//--------------------------------------------------------------------------
	// static public methods
	//--------------------------------------------------------------------------
	static public LullabyDemonPooledObject Spawn (Vector3 location, float fallSpeed, int direction, Sprite[] images)
	{
		// search for the first free LullabyDemonPooledObject
		foreach (LullabyDemonPooledObject symbolController in symbolControllers) {
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
		
		foreach (LullabyDemonPooledObject symbolController in symbolControllers) {
			symbolController.gameObject.SetActive (false);
		}
	}
	
	//--------------------------------------------------------------------------
	// protected mono methods
	//--------------------------------------------------------------------------
	protected void Awake ()
	{
		// does the pool exist yet?
		if (symbolControllers == null) {
			// lazy initialize it
			symbolControllers = new List<LullabyDemonPooledObject> ();
		}
		// add myself
		symbolControllers.Add (this);
	}

	protected void OnDestroy ()
	{
		// remove myself from the pool
		symbolControllers.Remove (this);
		// was I the last one?
		if (symbolControllers.Count == 0) {
			// remove the pool itself
			symbolControllers = null;
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
