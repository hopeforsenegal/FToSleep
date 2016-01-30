using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof(BoxCollider2D))]
public class BathroomEnemy : MonoBehaviour
{
	void OnCollisionEnter2D(Collision2D coll) {
		Debug.Log ("What up tho?");
		if (coll.gameObject.name == "Sword") {
			Debug.Log ("Et tu, Brute?");
			gameObject.SetActive (false);
		}
	}
}
