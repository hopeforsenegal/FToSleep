using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof(BoxCollider2D))]
public class BathroomEnemy : MonoBehaviour
{
	private Knight2D mainPlayer;
	public AudioClip[] deathNoise;

	protected void Start ()
	{
		GameObject tempObject;
		tempObject = GameObject.Find ("Knight");
		if (tempObject != null) {
			mainPlayer = tempObject.GetComponent<Knight2D> ();
		}

		Debug.Assert (tempObject != null);
		Debug.Assert (mainPlayer != null);
	}

	void OnCollisionEnter2D (Collision2D coll)
	{
		Debug.Log ("Did you swing at me?");
		if (coll.gameObject.name == "Knight") {
			Debug.Log ("Et tu, Brute?");
			Debug.Assert (mainPlayer != null);
			if (mainPlayer) {
				mainPlayer.GotTouched ();
			}
		}
		if (coll.gameObject.name == "Sword") {
			Debug.Log ("Sword");
			gameObject.SetActive (false);
		}
	}

	void OnTriggerEnter2D (Collider2D otherObject)
	{
		Debug.Log ("Got hit by sword?");
		if (otherObject.name == "Sword") {
			Debug.Log ("Attack Trigger");
			AudioClip clip = deathNoise[Random.Range (0, deathNoise.Length)];
			AudioController.PlaySoundEffect(clip);
			gameObject.SetActive (false);
		}
		if (otherObject.name == "AttackTrigger") {
			Debug.Log ("Sword1");
			gameObject.SetActive (false);
		}
	}
}
