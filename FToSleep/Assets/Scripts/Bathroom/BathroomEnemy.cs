using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof(BoxCollider2D))]
public class BathroomEnemy : MonoBehaviour
{
	private Knight2D mainPlayer;

	protected void Awake ()
	{
		GameObject tempObject;
		tempObject = GameObject.Find ("Knight");
		if (tempObject != null) {
			mainPlayer = tempObject.GetComponent<Knight2D> ();
		}
	}

	void OnCollisionEnter2D (Collision2D coll)
	{
		Debug.Log ("Did you swing at me?");
		if (coll.gameObject.name == "Knight") {
			Debug.Log ("Et tu, Brute?");
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
			gameObject.SetActive (false);
		}
		if (otherObject.name == "AttackTrigger") {
			Debug.Log ("Sword");
			gameObject.SetActive (false);
		}
	}
}
