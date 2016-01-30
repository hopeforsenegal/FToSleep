using UnityEngine;
using System.Collections;

public class DoorsManager : MonoBehaviour {

	// Singleton
	public static DoorsManager Instance {
		get {
			return instance;
		}
	}

	private static DoorsManager instance;

	private float deltaTime = 0.0f;
	private float trackingTime = 0.0f;
	private int countDownEndSeconds = 0;
	public int endCountdownTime = 30;
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
		Debug.Log ("Start Doors Game");

		matchStarted = true;
	}

	public bool IsMatchStarted ()
	{
		return matchStarted;
	}

	public void EndGame ()
	{
		Debug.Log ("End Doors Game");

		matchStarted = false;
	}

	public void RestartCountdown ()
	{
		countDownEndSeconds = endCountdownTime;
		RemainingTimeText.SetTimeRemaining (countDownEndSeconds);
	}
}
