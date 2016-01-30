using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class InsanityController : MonoBehaviour
{
	// Singleton
	public static InsanityController Instance {
		get {
			return instance;
		}
	}

	private static InsanityController instance;

	// Can only be one
	protected void Awake ()
	{
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			DestroyObject (gameObject);
		}

		DontDestroyOnLoad (gameObject);
	}

	public int insanity = 0;

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
