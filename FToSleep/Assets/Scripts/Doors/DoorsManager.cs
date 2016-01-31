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

	public DoorsCylinderController[] cylinderControllers;
	private int _currentCylinderIndex = 0;

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
				MetagameController.IncreaseInsanity ();
				EndGame ();
			}
		}
	}

	public void StartGame ()
	{
		Debug.Log ("Start Doors Game");

		for (int index = 0; index < cylinderControllers.Length; index++) {
			cylinderControllers [index].SetSortingOrder (index);
		}

		matchStarted = true;
		cylinderControllers [_currentCylinderIndex].StartCylinderPuzzle ();
	}

	public bool IsMatchStarted ()
	{
		return matchStarted;
	}

	public void EndGame ()
	{
		Debug.Log ("End Doors Game");

		matchStarted = false;

		MetagameController.GoToMain ();
	}

	public void CylinderComplete () {
		_currentCylinderIndex++;
		if (_currentCylinderIndex == cylinderControllers.Length) {
			EndGame ();
		} else {
			cylinderControllers [_currentCylinderIndex].StartCylinderPuzzle ();
		}
	}

	public void RestartCountdown ()
	{
		countDownEndSeconds = endCountdownTime;
		RemainingTimeText.SetTimeRemaining (countDownEndSeconds);
	}
}
