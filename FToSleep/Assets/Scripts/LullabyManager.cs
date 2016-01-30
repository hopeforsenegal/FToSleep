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
	private float lastSpawnTime = 0.0f;
	private float trackingTime = 0.0f;
	private int countDownEndSeconds = 0;
	private Canvas canvas;
	public int endCountdownTime = 60;
	public bool matchStarted;
	public bool startGameOnLaunch;
	public Transform startLocation;
	public float symbolFallRate = 2.0f;
	public float symbolFallSpeed = 130.0f;
	public Sprite[] sprites;
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
		lastSpawnTime = Time.time;
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
			if (trackingTime - lastSpawnTime > symbolFallRate) {
				lastSpawnTime = trackingTime;
				SpawnNewSymbol ();
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
				// increase instanity here
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
		Debug.Log ("Start Game");

		matchStarted = true;
		canvas.gameObject.SetActive (true);
	}

	public bool IsMatchStarted ()
	{
		return matchStarted;
	}

	public void EndGame ()
	{
		Debug.Log ("End Game");

		matchStarted = false;

		canvas.gameObject.SetActive (false);
	}

	private void SpawnNewSymbol ()
	{
		Debug.Log ("SpawnNewSymbol");
		Sprite image = sprites [0];
		Vector3 newPosition = new Vector3 (startLocation.position.x, startLocation.position.y);
		newPosition.x = Random.Range (-startLocation.position.x, startLocation.position.x);
		LullabySheepPooledObject newSymbol = LullabySheepPooledObject.Spawn (newPosition, symbolFallSpeed, image);
	}

	private void DespawnSymbols ()
	{
	}

	public void RestartCountdown ()
	{
		countDownEndSeconds = endCountdownTime;
		RemainingTimeText.SetTimeRemaining (countDownEndSeconds);
	}
}
