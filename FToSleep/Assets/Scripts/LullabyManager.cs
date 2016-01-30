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

	private float lastSpawnTime = 0.0f;
	private float trackingTime = 0.0f;
	public bool matchStarted;
	public Transform startLocation;
	public float symbolFallRate = 2.0f;
	public float symbolFallSpeed = 130.0f;
	public Sprite[] sprites;

	protected void Awake ()
	{
		if (instance == null) {
			instance = this;
		}
	}

	protected void Start ()
	{
		trackingTime = Time.time;
		lastSpawnTime = Time.time;
	}

	protected void Update ()
	{
		if (IsMatchStarted ()) {
			if (trackingTime - lastSpawnTime > symbolFallRate) {
				lastSpawnTime = trackingTime;
				SpawnNewSymbol ();
			}

			trackingTime += Time.deltaTime;
		}
	}

	public void StartGame ()
	{
		Debug.Log ("Start Game");

		matchStarted = true;
	}

	public bool IsMatchStarted ()
	{
		return matchStarted;
	}

	public void EndGame ()
	{
		Debug.Log ("End Game");

		matchStarted = false;
	}

	private void SpawnNewSymbol ()
	{
		Debug.Log ("SpawnNewSymbol");
		Sprite image = sprites [0];
		Vector3 newPosition = new Vector3(startLocation.position.x, startLocation.position.y);
		newPosition.x = Random.Range (-startLocation.position.x, startLocation.position.x);
		LullabySheepPooledObject newSymbol = LullabySheepPooledObject.Spawn (newPosition, symbolFallSpeed, image);
	}

	private void DespawnSymbols ()
	{
	}
}
