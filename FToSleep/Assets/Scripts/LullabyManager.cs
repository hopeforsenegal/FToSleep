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

	public RectTransform startLocation;
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
	}

	protected void Update ()
	{
	}

	private void SpawnNewSymbol ()
	{
		LullabySheepPooledObject newSymbol = LullabySheepPooledObject.Spawn (startLocation.position, symbolFallSpeed, Random.Range (0, 4), sprites);
	}

	private void DespawnSymbols ()
	{
	}
}
