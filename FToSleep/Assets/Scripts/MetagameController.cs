using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
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

	private float deltaTime = 0.0f;
	private float trackingTime = 0.0f;
	private int countDownEndSeconds = 0;
	public int endCountdownTime = 300;

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

	protected void Start ()
	{
		trackingTime = Time.time;
		deltaTime = Time.time;

		RestartCountdown ();
		StartGame ();
	}

	protected void Update ()
	{
		// Change the remaining time
		if (Time.time - deltaTime >= 1.0f) {
			deltaTime = Time.time;

			countDownEndSeconds--;
			//RemainingTimeText.SetTimeRemaining (countDownEndSeconds);
		}

		if ( Input.GetButtonDown("Cancel") ) {
			Debug.Log ("Escape!!!!!!!!");
			EndGame ();
		}

		//RemainingTimeText.Show (true);
		trackingTime += Time.deltaTime;

		// If the time has run down 
		if (countDownEndSeconds <= 0) {
			EndGame ();
		}
	}

	public void StartGame ()
	{
		Debug.Log ("Start Overall Game");
	}

	public void EndGame ()
	{
		Debug.Log ("End Overall Game");
		SceneManager.LoadScene("Start");
	}

	public static bool IsActive ()
	{
		return instance != null;
	}

	public void RestartCountdown ()
	{
		countDownEndSeconds = endCountdownTime;
		//RemainingTimeText.SetTimeRemaining (countDownEndSeconds);
	}

	public static int GetInsanity(){
		if (IsActive ()) {
			Debug.Log ("GetInsanity:" + instance.insanity);
			return instance.insanity;
		}
		return 0;
	}

	public static void IncreaseInsanity(){
		if (IsActive ()) {
			Debug.Log ("IncreaseInsanity:" + instance.insanity);
			instance.insanity++;
		}
	}
}
