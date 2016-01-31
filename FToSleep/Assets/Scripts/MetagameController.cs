using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

// Keeps track of what screen you are on and need to go back to
public class MetagameController : MonoBehaviour
{
	// Singleton
	public static MetagameController Instance {
		get {
			return instance;
		}
	}

	private static MetagameController instance;

	private Transform playerTransform;
	private int insanity = 0;

	protected void Awake ()
	{
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			DestroyObject (gameObject);
			return;
		}

		DontDestroyOnLoad (gameObject);

		GameObject tempObject;
		tempObject = GameObject.Find ("Player");
		if (tempObject != null) {
			playerTransform = tempObject.GetComponent<Transform> ();
			tempObject = null;
		}
	}

	public static bool IsActive ()
	{
		return instance != null;
	}

	public static int GetInsanity(){
		if (IsActive ()) {
			Debug.Log ("GetInsanity");
			return instance.insanity;
		}
		return 0;
	}

	public static void IncreaseInsanity(){
		if (IsActive ()) {
			Debug.Log ("IncreaseInsanity");
			instance.insanity++;
		}
	}
}
