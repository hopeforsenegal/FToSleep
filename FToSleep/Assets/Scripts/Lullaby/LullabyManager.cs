using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class LullabyManager : MonoBehaviour
{
	// Singleton
	public static LullabyManager Instance {
		get {
			return instance;
		}
	}

	private static LullabyManager instance;

	private float deltaTime = 0.0f;
	private float lastSpawnSheepTime = 0.0f;
	private float lastSpawnDemonTime = 0.0f;
	private float trackingTime = 0.0f;
	private int countDownEndSeconds = 0;
	private Canvas canvas;
	public AudioClip lullabyMusic;
	public AudioClip ambienceMusic;
	public AudioClip snore;
	public int endCountdownTime = 60;
	public bool matchStarted;
	public bool startGameOnLaunch;
	public Transform startLocation;
	public float sheepFallRate = 2.0f;
	public float sheepFallSpeed = 130.0f;
	public float demonFallRate = 1.5f;
	public float demonFallSpeed = 140.0f;
	public Sprite[] earlySheepSprites;
	public Sprite[] lateSheepSprites;
	public Sprite[] earlyDemonSprites;
	public Sprite[] lateDemonSprites;
	public int numberOfMisses;

	protected void Awake ()
	{
		if (instance == null) {
			instance = this;
		}

		GameObject tempObject;
		tempObject = GameObject.Find ("Canvas");
		if (tempObject != null) {
			canvas = tempObject.GetComponent<Canvas> ();
			canvas.gameObject.SetActive (false);
			tempObject = null;
		}
	}

	protected void Start ()
	{
		trackingTime = Time.time;
		lastSpawnSheepTime = Time.time;
		lastSpawnDemonTime = Time.time;
		deltaTime = Time.time;

		numberOfMisses = 0;

		RestartCountdown ();
		if (startGameOnLaunch) {
			StartGame ();
		}
	}

	protected void Update ()
	{
		if (IsMatchStarted ()) {
			if (trackingTime - lastSpawnSheepTime > sheepFallRate) {
				lastSpawnSheepTime = trackingTime;
				SpawnNewSheep ();
			}
			if (trackingTime - lastSpawnDemonTime > demonFallRate) {
				lastSpawnDemonTime = trackingTime;
				SpawnNewDemon ();
			}
			// Change the remaining time
			if (Time.time - deltaTime >= 1.0f) {
				deltaTime = Time.time;

				countDownEndSeconds--;
				RemainingTimeText.SetTimeRemaining (countDownEndSeconds);
			}

			RemainingTimeText.Show (true);
			trackingTime += Time.deltaTime;

			if (numberOfMisses >= 3) {
				MetagameController.IncreaseInsanity ();
				MetagameController.AbleToRetryPlayedGame ();
				EndGame ();
				return;
			}

			// If the time has run down 
			if (countDownEndSeconds <= 0) {
				EndGame ();
			}
		}
	}

	public void StartGame ()
	{
		Debug.Log ("Start Lullaby Game");

		AudioController.PlayMusic (lullabyMusic);
		AudioController.PlayMusic2 (ambienceMusic);

		matchStarted = true;
		canvas.gameObject.SetActive (true);
	}

	public bool IsMatchStarted ()
	{
		return matchStarted;
	}

	public void EndGame ()
	{
		Debug.Log ("End Lullaby Game");

		matchStarted = false;

		AudioController.StopAllSounds ();
		DespawnSymbols ();
		canvas.gameObject.SetActive (false);
		MetagameController.GoToMain ();
	}

	private void SpawnNewSheep ()
	{
		Debug.Log ("SpawnNewSheep");
		Sprite sheepImage = null;
		if (countDownEndSeconds >= endCountdownTime / 2) {
			// Start nice
			int index = Random.Range (0, earlySheepSprites.Length);
			sheepImage = earlySheepSprites [index];
		} else {
			// get hellish
			int index = Random.Range (0, lateSheepSprites.Length);
			sheepImage = lateSheepSprites [index];
		}
		Vector3 newPosition = new Vector3 (startLocation.position.x, startLocation.position.y);
		newPosition.x = Random.Range (-startLocation.position.x, startLocation.position.x);
		LullabySheepPooledObject newSymbol = LullabySheepPooledObject.Spawn (newPosition, sheepFallSpeed, sheepImage);
	}

	private void SpawnNewDemon ()
	{
		Debug.Log ("SpawnNewDemon");
		Sprite demonImage = null;
		if (countDownEndSeconds >= endCountdownTime / 2) {
			// Start nice
			int index = Random.Range (0, earlyDemonSprites.Length);
			demonImage = earlyDemonSprites [index];
		} else {
			// get hellish
			int index = Random.Range (0, lateDemonSprites.Length);
			demonImage = lateDemonSprites [index];
		}
		Vector3 newPosition = new Vector3 (startLocation.position.x, startLocation.position.y);
		newPosition.x = Random.Range (-startLocation.position.x, startLocation.position.x);
		LullabyDemonPooledObject newSymbol = LullabyDemonPooledObject.Spawn (newPosition, demonFallSpeed, demonImage);
	}

	private void DespawnSymbols ()
	{
		LullabySheepPooledObject.ResetControllers ();
		LullabyDemonPooledObject.ResetControllers ();
	}

	public void RestartCountdown ()
	{
		countDownEndSeconds = endCountdownTime;
		RemainingTimeText.SetTimeRemaining (countDownEndSeconds);
	}

	public void PlayDemonScream ()
	{
		//AudioController.PlaySoundEffect (soundEffect);
	}

	public void PlaySnore ()
	{
		if (Random.Range (0, 2) == 0) {
			AudioController.PlaySoundEffect (snore);
		}
	}
}
