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
	public bool[] gamesWon = new bool[4];
	public AudioClip startSoundEffect;
	public AudioClip insanityFail;
	private string nextSceneToLoad;
	private Sprite nextSceneBackground;
	public Sprite winSprite;
	public Sprite loseSprite;

	private bool gameRunning = false;
	private float deltaTime = 0.0f;
	private float trackingTime = 0.0f;
	private int countDownEndSeconds = 0;
	public int lastPlayedGame;
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

			if (gamesWon [1] == true && gamesWon [2] == true  && gamesWon [3] == true && SceneManager.GetActiveScene().name.Contains("Main")) {
				WinGame ();
				return;
			}

			if (Input.GetButtonDown ("Cancel")) {
				Debug.Log ("Escape!!!!!!!!");
				LoseGame ();
				return;
			}

			//RemainingTimeText.Show (true);
			trackingTime += Time.deltaTime;

			// If the time has run down 
			if (countDownEndSeconds <= 0) {
				LoseGame ();
				return;
			}
		}
	}

	public void StartGame ()
	{
		Debug.Log ("Start Overall Game");
		AudioController.PlaySoundEffect (startSoundEffect);
		gamesPlayed = new bool[4]{false, false, false, false};
		gamesWon = new bool[4]{false, false, false, false};
		gameRunning = true;
	}

	public void LoseGame ()
	{
		gameRunning = false;
		Debug.Log ("End Overall Game");
		MetagameController.SetNextSceneToLoad ("Start");
		MetagameController.SetNextSplashScreenBackground (loseSprite);
		SceneManager.LoadScene ("SplashScreen");
	}

	public void WinGame ()
	{
		gameRunning = false;
		Debug.Log ("End Overall Game - Win");
		MetagameController.SetNextSceneToLoad ("Start");
		MetagameController.SetNextSplashScreenBackground (winSprite);
		SceneManager.LoadScene ("SplashScreen");
	}

	public static void GoToMain ()
	{
		if (IsActive ()) {
			//to make sure we dont load into scenes that dont exist
			string sceneToLoad = "Main" + ((GetInsanity () > 0 && GetInsanity () < 3) ? "" + GetInsanity () : "");
			if (GetInsanity () >= 3) {
				instance.LoseGame ();
				return;
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
			Debug.Log ("playing:" + game);
			instance.gamesPlayed [game] = true;
			instance.lastPlayedGame = game;
		}
	}

	public static void SetWonGame (int game)
	{
		if (IsActive ()) {
			Debug.Log ("won:" + game);
			instance.gamesWon [game] = true;
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
			Debug.Log ("able to retry:" + instance.lastPlayedGame);
		}
	}

	public static void SetNextSceneToLoad(string nextToScene){
		if (IsActive ()) {
			instance.nextSceneToLoad = nextToScene;
		}
	}

	public static void SetNextSplashScreenBackground(Sprite splashBackground){
		if (IsActive ()) {
			instance.nextSceneBackground = splashBackground;
		}
	}

	public static string GetNextSceneToLoad(){
		if (IsActive ()) {
			return instance.nextSceneToLoad;
		}

		return "";
	}

	public static Sprite GetNextSplashScreenBackground(){
		if (IsActive ()) {
			return instance.nextSceneBackground;
		}

		return null;
	}
}
