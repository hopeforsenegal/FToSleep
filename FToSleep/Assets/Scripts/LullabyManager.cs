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
		if (trackingTime - lastSpawnTime > symbolFallRate) {
			lastSpawnTime = trackingTime;
			SpawnNewSymbol ();
		}

		trackingTime += Time.deltaTime;
	}

	private void SpawnNewSymbol ()
	{
		Sprite image = sprites [0];
		LullabySheepPooledObject newSymbol = LullabySheepPooledObject.Spawn (startLocation.position, symbolFallSpeed, image);
	}

	private void DespawnSymbols ()
	{
	}
}
