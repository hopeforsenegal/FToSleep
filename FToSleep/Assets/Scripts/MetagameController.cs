﻿using UnityEngine;
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

	private TransformData playerTransformData;
	private int insanity = 0;
	public bool[] gamesPlayed = new bool[4];
	public AudioClip startSoundEffect;
	public AudioClip insanityFail;

	private bool gameRunning = false;
	private float deltaTime = 0.0f;
	private float trackingTime = 0.0f;
	private int countDownEndSeconds = 0;
	private int lastPlayedGame;
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

		SavePlayerPosition ();
	}

	private void SavePlayerPosition ()
	{
		GameObject tempObject;
		tempObject = GameObject.Find ("Player");
		if (tempObject != null) {
			playerTransformData = tempObject.transform.Clone ();
			tempObject = null;
			Debug.Log ("SetPlayerPosition x:" + playerTransformData.position.x + " y:" + playerTransformData.position.y);
		} else {
			Debug.LogWarning ("NOT HERE!");
		}
	}

	protected void Start ()
	{
		trackingTime = Time.time;
		deltaTime = Time.time;

		PositionYourPlayer ();
		RestartCountdown ();
		StartGame ();
	}

	protected void Update ()
	{
		if (gameRunning) {
			// Change the remaining time
			if (Time.time - deltaTime >= 1.0f) {
				deltaTime = Time.time;

				countDownEndSeconds--;
				//RemainingTimeText.SetTimeRemaining (countDownEndSeconds);
			}

			if (gamesPlayed [1] == true && gamesPlayed [2] == true && true && gamesPlayed [3] == true && SceneManager.GetActiveScene().name.Contains("Main")) {
				
				Debug.Break();
			}

			if (Input.GetButtonDown ("Cancel")) {
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
	}

	public void StartGame ()
	{
		Debug.Log ("Start Overall Game");
		AudioController.PlaySoundEffect (startSoundEffect);
		gamesPlayed = new bool[4]{false, false, false, false};
		gameRunning = true;
	}

	public void EndGame ()
	{
		gameRunning = false;
		Debug.Log ("End Overall Game");
		SceneManager.LoadScene ("Start");
	}

	public static void GoToMain ()
	{
		if (IsActive ()) {
			//to make sure we dont load into scenes that dont exist
			string sceneToLoad = "Main" + ((GetInsanity () > 0 && GetInsanity () < 3) ? "" + GetInsanity () : "");
			if (GetInsanity () >= 3) {
				sceneToLoad = "Start";
			}

			Debug.Log ("GoToMain:" + sceneToLoad);

			SceneManager.LoadScene (sceneToLoad);
		}
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

	public static int GetInsanity ()
	{
		if (IsActive ()) {
			Debug.Log ("GetInsanity:" + instance.insanity);
			return instance.insanity;
		}
		return 0;
	}

	public static void IncreaseInsanity ()
	{
		if (IsActive ()) {
			Debug.Log ("IncreaseInsanity:" + instance.insanity);
			instance.insanity++;
		}
	}

	public static void PlayInsanitySound ()
	{
		if (IsActive ()) {
			AudioController.PlaySoundEffect (instance.insanityFail);
		}
	}

	public static void PositionYourPlayer ()
	{
		if (IsActive ()) {
			Debug.Log ("PositionYourPlayer");

			GameObject tempObject;
			tempObject = GameObject.Find ("Player");
			if (tempObject != null) {
				Transform transform = tempObject.GetComponent<Transform> ();
				transform.position = instance.playerTransformData.position;
				transform.rotation = instance.playerTransformData.rotation;
				Debug.Log ("PositionYourPlayer x:" + transform.position.x + " y:" + transform.position.y);
			}
		}
	}

	public static void RecordPlayerPosition ()
	{
		if (IsActive ()) {
			Debug.Log ("RecordPlayerPosition");
			instance.SavePlayerPosition ();
		}
	}

	public static void SetPlayedGame (int game)
	{
		if (IsActive ()) {
			instance.gamesPlayed [game] = true;
			instance.lastPlayedGame = game;
		}
	}

	public static bool HasPlayedGame (int game)
	{
		if (IsActive ()) {
			return instance.gamesPlayed [game];
		}
		return false;
	}

	public static void AbleToRetryPlayedGame ()
	{
		if (IsActive ()) {
			instance.gamesPlayed [instance.lastPlayedGame] = false;
		}
	}
}
