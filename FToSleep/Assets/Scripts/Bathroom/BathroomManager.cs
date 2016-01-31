using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class BathroomManager : MonoBehaviour
{
	// Singleton
	public static BathroomManager Instance {
		get {
			return instance;
		}
	}

	private static BathroomManager instance;

	private float deltaTime = 0.0f;
	private float trackingTime = 0.0f;
	private int countDownEndSeconds = 0;
	public AudioClip ambienceMusic;
	public int endCountdownTime = 60;
	public bool matchStarted;
	public bool startGameOnLaunch;

	protected void Awake ()
	{
		if (instance == null) {
			instance = this;
		}
	}

	protected void Start ()
	{
		trackingTime = Time.time;
		deltaTime = Time.time;

		RestartCountdown ();
		if (startGameOnLaunch) {
			StartGame ();
		}
	}

	protected void Update ()
	{
		if (IsMatchStarted ()) {
			// Change the remaining time
			if (Time.time - deltaTime >= 1.0f) {
				deltaTime = Time.time;

				countDownEndSeconds--;
				RemainingTimeText.SetTimeRemaining (countDownEndSeconds);
			}

			RemainingTimeText.Show (true);
			trackingTime += Time.deltaTime;

			// If the time has run down 
			if (countDownEndSeconds <= 0) {
				EndGame ();
			}
		}
	}

	public void StartGame ()
	{
		Debug.Log ("Start Bathroom Game");

		matchStarted = true;
		AudioController.PlayMusic (ambienceMusic);
	}

	public bool IsMatchStarted ()
	{
		return matchStarted;
	}

	public void EndGame ()
	{
		Debug.Log ("End Bathroom Game");

		AudioController.StopAllSounds ();
		matchStarted = false;
		MetagameController.GoToMain ();
	}

	public void GetSawed(){
		// Play some sound


		MetagameController.IncreaseInsanity();
		MetagameController.AbleToRetryPlayedGame ();
	}

	public void RestartCountdown ()
	{
		countDownEndSeconds = endCountdownTime;
		RemainingTimeText.SetTimeRemaining (countDownEndSeconds);
	}
}
