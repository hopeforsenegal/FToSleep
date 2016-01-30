/**
All material in this application solution and source is, unless otherwise stated, 
the property of Kamau Vassall, Jorge Munoz, Oliver Plunket, Jeremy Bader 
Copyright and other intellectual property laws protect these materials. 
Reproduction or retransmission of the materials, in whole or in part, 
in any manner, without the prior written consent of the copyright holder,
is a violation of copyright law.

Originating Author: Kamau Vassall, Jorge Munoz, Oliver Plunket, Jeremy Bader 

*----------------------------------------------------------------
* SymbolController.cs : Handles the creation for the falling symbols
*----------------------------------------------------------------
*/
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
	static private List<LullabySheepPooledObject> symbolControllers;
	
	public int currentDirection = 0;
	public bool paused = false;
	private float fallSpeed;
	private Image currentImage;
	
	//--------------------------------------------------------------------------
	// static public methods
	//--------------------------------------------------------------------------
	static public LullabySheepPooledObject Spawn( Vector3 location, float fallSpeed, int direction, Sprite[] images )
	{
		// search for the first free LullabySheepPooledObject
		foreach( LullabySheepPooledObject symbolController in symbolControllers )
		{
			// if disabled, then it's available
			if( symbolController.gameObject.activeSelf == false )
			{
				// set it up
				symbolController.transform.position = location;
				symbolController.gameObject.GetComponent<Image>().sprite = images[direction];
				symbolController.currentDirection = direction;
				symbolController.fallSpeed = fallSpeed;
				
				// switch it back on
				symbolController.gameObject.SetActive(true);
				
				// return a reference to the caller
				return symbolController;
				
			}
		}
		
		Debug.LogWarning ("Don't have enough objects pre-allocated");
		// if we get here, we haven't pooled enough agents or our spawn rate is too high.

		return null;
	}

	static public void ResetControllers(){
		
		foreach (LullabySheepPooledObject symbolController in symbolControllers) {
			symbolController.gameObject.SetActive(false);
		}
	}
	
	//--------------------------------------------------------------------------
	// protected mono methods
	//--------------------------------------------------------------------------
	protected void Awake()
	{
		// does the pool exist yet?
		if( symbolControllers == null )
		{
			// lazy initialize it
			symbolControllers = new List<LullabySheepPooledObject>();
		}
		// add myself
		symbolControllers.Add(this);
	}
	
	protected void OnDestroy()
	{
		// remove myself from the pool
		symbolControllers.Remove(this);
		// was I the last one?
		if(symbolControllers.Count == 0)
		{
			// remove the pool itself
			symbolControllers = null;
		}
	}
	
	protected void OnDisable()
	{
	}
	
	protected void OnEnable()
	{
	}
	
	protected void Start()
	{
		gameObject.SetActive(false);
	}
	
	protected void Update()
	{
		if (!paused) {
			// travel in a straight line at 4 units per second
			transform.position -= transform.up * (Time.deltaTime * fallSpeed);
		}
	}
	
	protected void OnBecameInvisible()
	{
		// I've left the screen. Disable myself so I'm available again
		gameObject.SetActive(false);
	}
	
	//--------------------------------------------------------------------------
	// private methods
	//--------------------------------------------------------------------------
}
